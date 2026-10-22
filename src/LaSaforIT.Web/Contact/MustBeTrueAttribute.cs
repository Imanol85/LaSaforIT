using System.ComponentModel.DataAnnotations;

namespace LaSaforIT.Web.Contact;

/// <summary>
/// Exige que un booleano sea verdadero (casillas de aceptación obligatoria).
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public sealed class MustBeTrueAttribute : ValidationAttribute
{
    public override bool IsValid(object? value) => value is true;
}
