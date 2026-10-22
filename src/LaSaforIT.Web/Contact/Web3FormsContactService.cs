using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LaSaforIT.Web.Contact;

/// <summary>
/// Envía el formulario a Web3Forms. Los registros nunca incluyen datos personales.
/// </summary>
public sealed class Web3FormsContactService : IContactFormService
{
    private readonly HttpClient _httpClient;
    private readonly ContactFormOptions _options;
    private readonly ILogger<Web3FormsContactService> _logger;

    public Web3FormsContactService(
        HttpClient httpClient,
        IOptions<ContactFormOptions> options,
        ILogger<Web3FormsContactService> logger)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _logger = logger;
    }

    public bool IsConfigured => _options.IsConfigured;

    public async Task<ContactSubmissionResult> SendAsync(ContactRequest request, CancellationToken cancellationToken = default)
    {
        // Honeypot relleno: se simula éxito para que el bot no reintente.
        if (!string.IsNullOrWhiteSpace(request.Website))
        {
            return ContactSubmissionResult.Sent();
        }

        if (!_options.IsConfigured)
        {
            return ContactSubmissionResult.NotConfigured();
        }

        var phone = request.Phone?.Trim();
        var payload = new Web3FormsRequest(
            _options.AccessKey,
            _options.Subject,
            _options.FromName,
            request.Name.Trim(),
            request.Email.Trim(),
            string.IsNullOrEmpty(phone) ? null : phone,
            request.Message.Trim());

        using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cts.CancelAfter(TimeSpan.FromSeconds(_options.TimeoutSeconds));

        try
        {
            using var message = new HttpRequestMessage(HttpMethod.Post, new Uri(_options.Endpoint, UriKind.Absolute))
            {
                Content = JsonContent.Create(payload, Web3FormsJsonContext.Default.Web3FormsRequest)
            };
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var response = await _httpClient.SendAsync(message, cts.Token);
            var body = await response.Content.ReadFromJsonAsync(Web3FormsJsonContext.Default.Web3FormsResponse, cts.Token);

            if (response.IsSuccessStatusCode && body is { Success: true })
            {
                return ContactSubmissionResult.Sent();
            }

            _logger.LogWarning(
                "Web3Forms rechazó el envío. Código HTTP: {StatusCode}. Mensaje: {ProviderMessage}",
                (int)response.StatusCode,
                body?.Message);
            return ContactSubmissionResult.Failed();
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException or JsonException)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw;
            }

            _logger.LogWarning(ex, "No se pudo completar el envío a Web3Forms.");
            return ContactSubmissionResult.Failed();
        }
    }
}
