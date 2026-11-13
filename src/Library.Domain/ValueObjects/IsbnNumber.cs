using System.Text.RegularExpressions;

namespace Library.Domain.ValueObjects;

public sealed record class IsbnNumber
{
    public IsbnNumber (string value) {
        if (!IsValid(value)) throw new InvalidDataException();
        Value = value;
    }

    public string Value { get; private init; }

    private static bool IsValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        var digits = Regex.Replace(value, @"[^0-9]", "");

        if (digits.Length != 13)
            return false;

        if (!digits.StartsWith("978") && !digits.StartsWith("979"))
            return false;

        int sum = 0;

        for (int i = 0; i < 12; i++)
        {
            sum += (digits[i] - '0') * (i % 2 == 0 ? 1 : 3);
        }

        int checkDigit = (10 - (sum % 10)) % 10;

        return checkDigit == digits[12] - '0';
    }
}
