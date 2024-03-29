﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frep2
{
    static class FrepFilters
    {
        public static string FrepNavFormat(object input)
        {
            string value = input.ToString();
            if (value == double.NaN.ToString()) return "NA";
            if (double.TryParse(value, out double v)) return string.Format("Rs {0:F2}", v);
            return "NA";
        }
        public static string FrepNavRoundFormat(object input)
        {
            string value = input.ToString();
            if (value == double.NaN.ToString()) return "NA";
            if (double.TryParse(value, out double v)) return string.Format("Rs {0:F0}", v);
            return "NA";
        }
        public static string FrepPIPFormat(object input)
        {
            string value = input.ToString();
            if (double.TryParse(value, out double v)) 
            {
                if (v > 0) return string.Format("{0:F2}%", v);
            }
            return "-";
        }
        public static string FrepFnEscape(object input)
        {
            string value = input.ToString().Trim();
            string result = "";
            foreach (char c in value)
            {
                if (char.IsLetterOrDigit(c) || c == '.') result += c;
                else result += '-';
                while (result != result.Replace("--", "-")) result = result.Replace("--", "-");
            }
            return result.ToLowerInvariant().Trim('-');
        }
    }
}
