namespace LaSaforIT.Web.Contact;

public enum ContactSubmissionStatus
{
    Sent,
    NotConfigured,
    Failed
}

public sealed record ContactSubmissionResult(ContactSubmissionStatus Status)
{
    public static ContactSubmissionResult Sent() => new(ContactSubmissionStatus.Sent);

    public static ContactSubmissionResult NotConfigured() => new(ContactSubmissionStatus.NotConfigured);

    public static ContactSubmissionResult Failed() => new(ContactSubmissionStatus.Failed);
}
