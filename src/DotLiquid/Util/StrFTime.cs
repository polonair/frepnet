using System;
using System.Collections.Generic;
using System.Globalization;

namespace DotLiquid.Util
{
    public static class StrFTime
    {
        public delegate string DateTimeDelegate(DateTime dateTime);

        private static readonly Dictionary<string, DateTimeDelegate> Formats = new Dictionary<string, DateTimeDelegate>
        {
            { "a", (dateTime) => dateTime.ToString("ddd", CultureInfo.CurrentCulture) },
            { "A", (dateTime) => dateTime.ToString("dddd", CultureInfo.CurrentCulture) },
            { "b", (dateTime) => dateTime.ToString("MMM", CultureInfo.CurrentCulture) },
            { "B", (dateTime) => dateTime.ToString("MMMM", CultureInfo.CurrentCulture) },
            { "c", (dateTime) => dateTime.ToString("ddd MMM dd HH:mm:ss yyyy", CultureInfo.CurrentCulture) },
            { "d", (dateTime) => dateTime.ToString("dd", CultureInfo.CurrentCulture) },
            { "e", (dateTime) => dateTime.ToString("%d", CultureInfo.CurrentCulture).PadLeft(2, ' ') },
            { "H", (dateTime) => dateTime.ToString("HH", CultureInfo.CurrentCulture) },
            { "I", (dateTime) => dateTime.ToString("hh", CultureInfo.CurrentCulture) },
            { "j", (dateTime) => dateTime.DayOfYear.ToString().PadLeft(3, '0') },
            { "m", (dateTime) => dateTime.ToString("MM", CultureInfo.CurrentCulture) },
            { "M", (dateTime) => dateTime.Minute.ToString().PadLeft(2, '0') },
            { "p", (dateTime) => dateTime.ToString("tt", CultureInfo.CurrentCulture).ToUpper() },
            { "S", (dateTime) => dateTime.ToString("ss", CultureInfo.CurrentCulture) },
            { "U", (dateTime) => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dateTime, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, DayOfWeek.Sunday).ToString().PadLeft(2, '0') },
            { "W", (dateTime) => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dateTime, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, DayOfWeek.Monday).ToString().PadLeft(2, '0') },
            { "w", (dateTime) => ((int) dateTime.DayOfWeek).ToString() },
            { "x", (dateTime) => dateTime.ToString("d", CultureInfo.CurrentCulture) },
            { "X", (dateTime) => dateTime.ToString("T", CultureInfo.CurrentCulture) },
            { "y", (dateTime) => dateTime.ToString("yy", CultureInfo.CurrentCulture) },
            { "Y", (dateTime) => dateTime.ToString("yyyy", CultureInfo.CurrentCulture) },
            { "Z", (dateTime) => dateTime.ToString("zzz", CultureInfo.CurrentCulture) },
            { "%", (dateTime) => "%" }
        };

        public static string ToStrFTime(this DateTime dateTime, string pattern)
        {
            string output = "";

            int n = 0;

            while (n < pattern.Length)
            {
                string s = pattern.Substring(n, 1);

                if (n + 1 >= pattern.Length)
                    output += s;
                else
                    output += s == "%"
                        ? Formats.ContainsKey(pattern.Substring(++n, 1)) ? Formats[pattern.Substring(n, 1)].Invoke(dateTime) : "%" + pattern.Substring(n, 1)
                        : s;
                n++;
            }

            return output;
        }
    }
}
