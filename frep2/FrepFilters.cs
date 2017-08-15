using System;
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
            double v;
            if (value == double.NaN.ToString()) return "NA";
            if (double.TryParse(value, out v)) return string.Format("Rs {0:F2}", v);
            return "NA";
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
