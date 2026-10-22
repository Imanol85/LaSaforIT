namespace LaSaforIT.Web.Site;

/// <summary>
/// Opciones del sitio enlazadas desde la sección "Site" de appsettings.json.
/// </summary>
public sealed class SiteOptions
{
    public const string SectionName = "Site";

    public List<SocialLink> SocialLinks { get; set; } = [];
}
