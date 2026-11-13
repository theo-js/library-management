namespace Library.Domain.ValueObjects;

public sealed record class EmailAddress
{
    public string Value { get; }

    public EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email is required.");

        if (value.Length > 254)
            throw new ArgumentException("Email is too long.");

        Value = value;
    }
}
