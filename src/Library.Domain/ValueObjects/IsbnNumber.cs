using System.Text.RegularExpressions;

namespace Library.Domain.ValueObjects;

public sealed record class IsbnNumber
{
    public IsbnNumber(string value)
    {
        if (!IsValid(value))
            throw new InvalidDataException();
        Value = value;
    }

    public string Value { get; private init; }

    private static bool IsValid(string isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn))
            return false;

        // Remove common separators
        isbn = isbn.Replace("-", "").Replace(" ", "");

        if (isbn.Length == 10)
            return IsValidIsbn10(isbn);

        if (isbn.Length == 13)
            return IsValidIsbn13(isbn);

        return false;
    }

    private static bool IsValidIsbn10(string isbn)
    {
        int sum = 0;

        for (int i = 0; i < 10; i++)
        {
            int digit;

            if (i == 9 && isbn[i] == 'X')
                digit = 10;
            else if (char.IsDigit(isbn[i]))
                digit = isbn[i] - '0';
            else
                return false;

            sum += digit * (10 - i);
        }

        return sum % 11 == 0;
    }

    private static bool IsValidIsbn13(string isbn)
    {
        if (!isbn.All(char.IsDigit))
            return false;

        int sum = 0;

        for (int i = 0; i < 12; i++)
        {
            int digit = isbn[i] - '0';
            sum += digit * (i % 2 == 0 ? 1 : 3);
        }

        int checkDigit = (10 - (sum % 10)) % 10;

        return checkDigit == isbn[12] - '0';
    }
}
