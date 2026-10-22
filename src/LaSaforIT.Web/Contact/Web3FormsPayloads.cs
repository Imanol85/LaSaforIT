using System.Text.Json.Serialization;

namespace LaSaforIT.Web.Contact;

public sealed record Web3FormsRequest(
    [property: JsonPropertyName("access_key")] string AccessKey,
    [property: JsonPropertyName("subject")] string Subject,
    [property: JsonPropertyName("from_name")] string FromName,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("phone")] string? Phone,
    [property: JsonPropertyName("message")] string Message);

public sealed record Web3FormsResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("message")] string? Message);

/// <summary>
/// Contexto de serialización generado en compilación: evita reflexión y avisos de recorte.
/// </summary>
[JsonSerializable(typeof(Web3FormsRequest))]
[JsonSerializable(typeof(Web3FormsResponse))]
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
internal sealed partial class Web3FormsJsonContext : JsonSerializerContext;
