using System;

namespace ServersApp.Infrastructure
{
    /// <summary>
    /// Чтобы не вызывать везде ToString(dd.MM.yyyy HH:mm:ss) - сделаем расширение
    /// </summary>
    public static class DateTimeExtensions
    {
        public static string FormatDate(this DateTime date)
        {
            return date.ToString("dd.MM.yyyy HH:mm:ss");
        }

        public static string FormatDate(this DateTime? date)
        {
            if (date.HasValue) return date.Value.FormatDate();
            else return string.Empty;
        }

        public static string FormatTimeSpan(this TimeSpan span)
        {
            return span.ToString(@"hh\:mm\:ss");
        }
    }
}