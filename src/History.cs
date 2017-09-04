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
        private double _ValueResearchRating;
        private double _TotalBondSales;

        public DateTime Date { get { return this._Date; } }
        public double Nav { get { return this._Nav; } }
        public double TotalBondSales { get { return this._TotalBondSales; } }
        public double ValueResearchRating { get { return this._ValueResearchRating; } }

        internal static string GetFundId(string header, string line, string separator)
        {
            return (line.Split(new string[] { separator }, StringSplitOptions.None))[0].Trim();
        }
        internal static History Create(DateTime date, string header, string line, Fund fund, string separator)
        {
            double value;
            History result = new History();
            result._Date = date;
            result._Header = header;
            result._Fund = fund;
            string[] data = line.Split(new string[] { separator }, StringSplitOptions.None);
            result._FundId = data[0].Trim();
            result._Nav = double.NaN;
            result._ValueResearchRating = double.NaN;
            result._TotalBondSales = double.NaN;
            if (double.TryParse(data[1].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out value)) result._Nav = value;
            if (double.TryParse(data[2].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out value)) result._ValueResearchRating = value;
            if (double.TryParse(data[3].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out value)) result._TotalBondSales = value;

            return result;
        }
    }
}