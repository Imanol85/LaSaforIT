namespace LaSaforIT.Web.Contact;

/// <summary>
/// Configuración del servicio de envío del formulario, enlazada desde la sección "ContactForm".
/// </summary>
public sealed class ContactFormOptions
{
    public const string SectionName = "ContactForm";

    /// <summary>Valor que indica que la clave de acceso todavía no se ha configurado.</summary>
    public const string PendingMarker = "[PENDIENTE]";

    public string Endpoint { get; set; } = string.Empty;
    public string AccessKey { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
    public int TimeoutSeconds { get; set; } = 15;

    public bool IsConfigured =>
        Uri.TryCreate(Endpoint, UriKind.Absolute, out _) &&
        !string.IsNullOrWhiteSpace(AccessKey) &&
        AccessKey != PendingMarker;
}
