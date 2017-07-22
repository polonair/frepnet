using System;
using System.Globalization;

namespace frep2
{
    internal class History
    {
        private DateTime _Date;
        private string _Header;
        private Fund _Fund;
        private string _FundId;
        private double _Nav;
        private double _Value;
        private double _Total;

        public DateTime Date { get { return this._Date; } }

        internal static string GetFundId(string header, string line, string separator)
        {
            return (line.Split(new string[] { separator }, StringSplitOptions.None))[0].Trim();
        }
        internal static History Create(DateTime date, string header, string line, Fund fund, string separator)
        {
            History result = new History();
            result._Date = date;
            result._Header = header;
            result._Fund = fund;
            string[] data = line.Split(new string[] { separator }, StringSplitOptions.None);
            result._FundId = data[0].Trim();
            result._Nav = double.NaN;
            double.TryParse(data[1].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out result._Nav);
            result._Value = double.NaN;
            double.TryParse(data[2].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out result._Value);
            result._Total = double.NaN;
            double.TryParse(data[3].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out result._Total);

            return result;
        }
    }
}