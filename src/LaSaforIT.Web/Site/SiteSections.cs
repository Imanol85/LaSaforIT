namespace LaSaforIT.Web.Site;

/// <summary>
/// Identificadores de ancla de las secciones de la home y elementos de navegación.
/// </summary>
public static class SiteSections
{
    public const string Hero = "inicio";
    public const string Services = "servicios";
    public const string Ai = "ia";
    public const string Method = "metodo";
    public const string Process = "proceso";
    public const string About = "sobre-mi";
    public const string Contact = "contacto";
    public const string MainContent = "contenido";

    // Enlace a una sección de la home resuelto contra <base href>: "./#servicios".
    public static string Href(string sectionId) => $"./#{sectionId}";

    public static IReadOnlyList<NavItem> Navigation { get; } =
    [
        new(Services, "Servicios"),
        new(Ai, "IA"),
        new(Method, "Método"),
        new(Process, "Proceso"),
        new(About, "Sobre mí"),
        new(Contact, "Contacto"),
    ];
}

public sealed record NavItem(string SectionId, string Label);
