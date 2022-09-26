using NodaTime;

namespace OpenExam.Application.Common;

public static class DateTimeConverter
{
    public static LocalDateTime ConvertFromDateTimeToLocalDateTime(DateTime dt)
    {
        var localDate = new LocalDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, CalendarSystem.Gregorian);
        // localDate.Date = dt.Date
        return localDate;
    }
}