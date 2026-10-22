using System.ComponentModel.DataAnnotations;

namespace LaSaforIT.Web.Contact;

/// <summary>
/// Datos del formulario de contacto con sus reglas de validación y mensajes en español.
/// </summary>
public sealed class ContactRequest
{
    [Required(ErrorMessage = "Escribe tu nombre.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Escribe tu correo electrónico para que pueda responderte.")]
    [EmailAddress(ErrorMessage = "Revisa el correo electrónico: parece que no es válido.")]
    [StringLength(254, ErrorMessage = "El correo electrónico es demasiado largo.")]
    public string Email { get; set; } = string.Empty;

    [RegularExpression(@"^[0-9+()\s.-]{6,30}$", ErrorMessage = "Revisa el teléfono: usa solo números, espacios y el prefijo +.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Cuéntame brevemente qué necesitas.")]
    [StringLength(4000, MinimumLength = 20, ErrorMessage = "El mensaje debe tener entre 20 y 4000 caracteres.")]
    public string Message { get; set; } = string.Empty;

    [MustBeTrue(ErrorMessage = "Para enviar el mensaje tienes que aceptar la política de privacidad.")]
    public bool PrivacyAccepted { get; set; }

    // Campo trampa: invisible para personas; si llega relleno, el envío se descarta.
    public string? Website { get; set; }
}
