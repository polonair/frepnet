using System;
using System.Globalization;

namespace frepnet
{
	public class History
	{
		private DateTime _Date;
		private string _Header;
		private Fund _Fund;
		private string _FundId;
		private double _Nav;
		private double _Value;
		private double _Total;

		public DateTime Date { get { return this._Date; } }
		public double Nav { get { return this._Nav; } }
		public double ValueResearchLevel { get { return this._Value; } }
		public double TotalBondSales { get { return this._Total; } }

		public History(){}
		internal static string GetFundId(string header, string v, string separator)
		{
			string[] line = v.Split(new string[] { separator }, StringSplitOptions.None);
			return line[0].Trim();
		}
		internal static History Create(DateTime date, string header, string v, Fund fund, string separator)
		{
			History result = new History();
			result._Date = date;
			result._Header = header;
			result._Fund = fund;
			string[] data = v.Split(new string[] { separator }, StringSplitOptions.None);

			result._FundId = data[0].Trim();

			result._Nav = double.NaN;
			double.TryParse(data[1].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out result._Nav);
			result._Value = double.NaN;
			double.TryParse(data[2].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out result._Value);
			result._Total = double.NaN;
			double.TryParse(data[3].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out result._Total);

			return result;
		}
		internal string PrintDump()
		{
			return string.Format(
@"
	--------------------
		date: {0},
		nav: {1},
		value: {2},
		total: {3}
	--------------------
", 
			this._Date, this._Nav, this._Value, this._Total);
		}
	}
}
