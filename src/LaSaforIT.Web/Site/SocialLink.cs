namespace LaSaforIT.Web.Site;

/// <summary>
/// Enlace a un perfil en una red social que se muestra en el pie de página.
/// </summary>
public sealed class SocialLink
{
    public string Name { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;
}
