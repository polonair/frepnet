using System;
using System.Globalization;

namespace frep2
{
    internal class UTIL
    {
        internal static DateTime ParseOrdinalDateTime(string datetime)
        {
            datetime = datetime.Replace("0th", "0")
                .Replace("1st", "1")
                .Replace("2nd", "2")
                .Replace("3rd", "3")
                .Replace("11th", "11")
                .Replace("12th", "12")
                .Replace("13th", "13")
                .Replace("4th", "4")
                .Replace("5th", "5")
                .Replace("6th", "6")
                .Replace("7th", "7")
                .Replace("8th", "8")
                .Replace("9th", "9");

            try { return DateTime.Parse(datetime, null, DateTimeStyles.None); }
            catch (Exception e) { throw new InvalidOperationException("Not a valid DateTime string", e); }
        }
    }
}