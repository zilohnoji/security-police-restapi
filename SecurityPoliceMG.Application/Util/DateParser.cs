namespace SecurityPoliceMG.Util;

public static class DateParser
{
    public static DateOnly ParseDateOnly(string date)
    {
        if (!TryParse(date, out DateOnly parsedDate))
        {
            throw new ArgumentException("Data inválida!");
        }

        return DateOnly.Parse(parsedDate.ToString("MM/dd/yyyy"));
    }

    public static DateTime ParseDateTime(string date)
    {
        if (!TryParse(date, out DateTime parsedDate))
        {
            throw new ArgumentException("Data inválida!");
        }

        return DateTime.SpecifyKind(parsedDate, DateTimeKind.Utc);
    }

    private static bool TryParse(string date, out DateOnly output)
    {
        if (string.IsNullOrEmpty(date))
        {
            output = new DateOnly();
            return false;
        }

        DateOnly.TryParse(date, out output);
        return true;
    }

    private static bool TryParse(string date, out DateTime output)
    {
        if (string.IsNullOrEmpty(date))
        {
            output = new DateTime();
            return false;
        }

        DateTime.TryParse(date, out output);
        return true;
    }
}