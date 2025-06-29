namespace AMI.EduWork._2025.Domain.Helpers;

public static class DateExtension
{
    public static DateTime GetDateOnly(DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
    }
}
