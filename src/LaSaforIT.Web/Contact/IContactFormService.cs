namespace LaSaforIT.Web.Contact;

/// <summary>
/// Contrato de envío del formulario de contacto, independiente del proveedor concreto.
/// </summary>
public interface IContactFormService
{
    bool IsConfigured { get; }

    Task<ContactSubmissionResult> SendAsync(ContactRequest request, CancellationToken cancellationToken = default);
}
