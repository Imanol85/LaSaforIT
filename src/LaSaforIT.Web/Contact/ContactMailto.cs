using System.Text;
using LaSaforIT.Web.Site;

namespace LaSaforIT.Web.Contact;

/// <summary>
/// Construye enlaces mailto como alternativa cuando el envío desde la web no está disponible.
/// </summary>
public static class ContactMailto
{
    public static string Simple() => $"mailto:{SiteInfo.Email}";

    public static string FromRequest(ContactRequest request, string subject)
    {
        var body = new StringBuilder();
        body.Append("Nombre: ").Append(request.Name.Trim()).Append("\r\n");
        body.Append("Correo: ").Append(request.Email.Trim()).Append("\r\n");

        if (!string.IsNullOrWhiteSpace(request.Phone))
        {
            body.Append("Teléfono: ").Append(request.Phone.Trim()).Append("\r\n");
        }

        body.Append("\r\n").Append(request.Message.Trim());

        return $"mailto:{SiteInfo.Email}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body.ToString())}";
    }
}
