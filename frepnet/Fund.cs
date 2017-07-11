using System;
using System.Collections.Generic;
using System.Text;
using DotLiquid;

namespace frepnet
{
	partial class Fund : Drop
	{
		const int HISTORY_LENGTH = 33;

		private QueryType _Type;
		private DataBase _DataBase;
		private string _Header;
		private string _Id;
		private History[] _History;
		private string _Category;
		private string _Name;
		private DateTime _LaunchDate;
		private string[] _Notes;
		private bool[] _IncludeIn;

		public string Id { get { return this._Id; } }
		public string Category { get { return this._Category; } }
		public double ValueResearchRating
		{
			get
			{
				if (this._History[0] != null && !double.IsNaN(this._History[0].ValueResearchLevel)) return this._History[0].ValueResearchLevel;
				else
				{
					double cnt = 0;
					double result = 0;

					for (int i = 1; i < 11; i++)
					{
						if (this._History[i] != null)
						{
							cnt += 1;
							result += this._History[i].ValueResearchLevel;
						}
					}
					if (cnt > 0) return result / cnt;
					else return double.NaN;
				}
			}
		}
		public double TotalBondSales
		{
			get
			{
				if (this._History[0] != null && !double.IsNaN(this._History[0].TotalBondSales)) return this._History[0].TotalBondSales;
				else
				{
					double cnt = 0;
					double result = 0;

					for (int i = 1; i < 11; i++)
					{
						if (this._History[i] != null)
						{
							cnt += 1;
							result += this._History[i].TotalBondSales;
						}
					}
					if (cnt > 0) return result / cnt;
					else return double.NaN;
				}
			}
		}
		//private int _PerformanceScoreRank_ByCategory = int.MaxValue;
		//private int _PerformanceScoreRank_Overall = int.MaxValue;
		public int PerformanceScoreRank
		{
			get
			{
				int iqt = (int)this._Type;
				if (iqt >= 1 && iqt <= 10)
				{
					//if (this._PerformanceScoreRank_ByCategory == int.MaxValue) this._PerformanceScoreRank_ByCategory = this._DataBase.GetPerformanceScoreRankByCategory(this._Id);
					//return this._PerformanceScoreRank_ByCategory;
					return this._DataBase.GetPerformanceScoreRankByCategory(this._Id);
				}
				if (iqt >= 11 && iqt <= 20)
				{
					//if (this._PerformanceScoreRank_Overall == int.MaxValue) this._PerformanceScoreRank_Overall =  this._DataBase.GetPerformanceScoreRankOverAll(this._Id);
					//return this._PerformanceScoreRank_Overall;
					return this._DataBase.GetPerformanceScoreRankOverAll(this._Id);
				}
				throw new ArgumentOutOfRangeException();
			}
		}


		public double TodayNav
		{
			get
			{
				if (this._History[0] != null) return this._History [0].Nav;
				else
				{
					double cnt = 0;
					double result = 0;
					for (int i = 1; i < 11; i++)
					{
						if (this._History[i] != null)
						{
							cnt += 1;
							result += this._History[i].Nav;
						}
					}
					if (cnt > 0) return result / cnt;
					else return double.NaN;
				}
			}
		}
		public double YesterdayNav
		{
			get
			{
				if (this._History[1] != null) return this._History[1].Nav;
				else
				{
					double cnt = 0;
					double result = 0;
					for (int i = 2; i < 12; i++)
					{
						if (this._History[i] != null)
						{
							cnt += 1;
							result += this._History[i].Nav;
						}
					}
					if (cnt > 0) return result / cnt;
					else return double.NaN;
				}
			}
		}
		public double PercentageChangeInNAV
		{
			get
			{
				if (this.YesterdayNav == 0) return 0;
				else return 100 * this.ChangeInNAV / this.YesterdayNav;
			}
		}
		public double PercentageChangeInNAVLong
		{
			get
			{
				if (this.PreviousNav == 0 || double.IsNaN(this.PreviousNav)) return 0;
				return 100 * this.ChangeInNavLong / this.PreviousNav;
			}
		}
		public int OverallScore
		{
			get
			{
				return this.PerformanceScoreRank + this.PerformanceImprovementPercentageRank + this.HighestRatingRank;
			}
		}
		public double ValueResearchRating20
		{
			get
			{

				if (this._History[20] != null) return this._History[20].Nav;
				else
				{
					double cnt = 0;
					double result = 0;
					for (int i = 21; i < 31; i++)
					{
						if (this._History[i] != null)
						{
							cnt += 1;
							result = this._History[i].Nav;
						}
					}
					if (cnt > 0) return result / cnt;
					else return double.NaN;
				}
			}
		}
		public double TotalBondSales20
		{
			get
			{

				if (this._History[20] != null) return this._History[20].TotalBondSales;
				else
				{
					double cnt = 0;
					double result = 0;
					for (int i = 21; i < 31; i++)
					{
						if (this._History[i] != null)
						{
							cnt += 1;
							result = this._History[i].TotalBondSales;
						}
					}
					if (cnt > 0) return result / cnt;
					else return double.NaN;
				}
			}
		}
		public double PerformanceScore20
		{
			get
			{
				return this.ValueResearchRating20 * this.TotalBondSales20 / this.DaysSinceLaunch20;
			}
		}
		public double PerformanceImprovementPercentage
		{
			get
			{
					double ps20 = this.PerformanceScore20;
					if (ps20 != 0 && !double.IsNaN(ps20)) return 100 * this.PerformanceScore / ps20;
					return 0;
			}
		}
		public int PerformanceImprovementPercentageRank
		{
			get
			{

				int iqt = (int)this._Type;
				if (iqt >= 1 && iqt <= 10) return this._DataBase.GetPerformanceImprovementPercentageRankByCategory(this._Id);
				if (iqt >= 11 && iqt <= 20) return this._DataBase.GetPerformanceImprovementPercentageRankOverAll(this._Id);
				throw new ArgumentOutOfRangeException();
			}
		}
		public int HighestRatingRank
		{
			get
			{

				int iqt = (int)this._Type;
				if (iqt >= 1 && iqt <= 10) return this._DataBase.GetHighestRatingRankByCategory(this._Id);
				if (iqt >= 11 && iqt <= 20) return this._DataBase.GetHighestRatingRankOverAll(this._Id);
				throw new ArgumentOutOfRangeException();

			}
		}
		public int OverallScoreRank
		{
			get
			{
				int iqt = (int)this._Type;
				if (iqt >= 1 && iqt <= 10) return this._DataBase.GetOverallScoreRankByCategory(this._Id);
				if (iqt >= 11 && iqt <= 20) return this._DataBase.GetOverallScoreRankOverAll(this._Id);
				throw new ArgumentOutOfRangeException();
			}
		}
		public double ChangeInNAV
		{
			get
			{
				//return this.TodayNav - this.YesterdayNav;
				return this.YesterdayNav - this.TodayNav;
			}
		}
		public double PerformanceScore
		{
			get
			{
				if (this.DaysSinceLaunch == 0) return 0;
				return (this.ValueResearchRating * this.TotalBondSales) / this.DaysSinceLaunch;
			}
		}
		public int DaysSinceLaunch
		{
			get
			{
				return DateTime.Now.Subtract(this._LaunchDate).Days;
			}
		}
		public int DaysSinceLaunch20
		{
			get
			{
				return DateTime.Now.Subtract(this._LaunchDate).Days-20;
			}
		}
		public double PreviousNav
		{
			get
			{
				if (this._History[20] == null) return double.NaN;
				return this._History[20].Nav;
			}
		}
		public double ChangeInNavLong
		{
			get 
			{
				return this.TodayNav - this.PreviousNav;
			}
		}
		public double LowestNAV
		{
			get
			{
				double result = double.MaxValue;
				int cnt = 0;

				for (int i = 0; i < 20; i++)
				{
					if (this._History[i] != null && !double.IsNaN(this._History[i].Nav))
					{
						cnt++;
						if (this._History[i].Nav < result) result = this._History[i].Nav;
					}
				}
				if (cnt > 0) return result;
				return double.NaN;
			}
		}
		public double HighestNAV
		{
			get
			{
				double result = double.MaxValue;
				int cnt = 0;

				for (int i = 0; i < 20; i++)
				{
					if (this._History[i] != null && !double.IsNaN(this._History[i].Nav))
					{
						cnt++;
						if (this._History[i].Nav > result) result = this._History[i].Nav;
					}
				}
				if (cnt > 0) return result;
				return double.NaN;
			}
		}

		internal bool IsConsidered(QueryType queryType)
		{
			this._Type = queryType;
			switch (this._Type)
			{
				case QueryType.Q1:
					if (!this._IncludeIn[0]) return false;
                	if (this.PercentageChangeInNAV <= 0) return false;
					if (this._History [0] == null) return false;
					if (double.IsNaN(this._History [0].Nav)) return false;
					return true;
				case QueryType.Q11:
					if (!this._IncludeIn[10]) return false;
                	if (this.PercentageChangeInNAV <= 0) return false;
					if (this._History [10] == null) return false;
					if (double.IsNaN(this._History [10].Nav)) return false;
					return true;
				case QueryType.Q2:
					if (!this._IncludeIn[1]) return false;
                	if (this.PercentageChangeInNAV <= 0) return false;
					if (this._History [1] == null) return false;
					if (double.IsNaN(this._History [1].Nav)) return false;
					return true;
				case QueryType.Q12:
					if (!this._IncludeIn[11]) return false;
                	if (this.PercentageChangeInNAV <= 0) return false;
					if (this._History [11] == null) return false;
					if (double.IsNaN(this._History [11].Nav)) return false;
					return true;
				case QueryType.Q3:
					if (!this._IncludeIn[2]) return false;
					return true;
				case QueryType.Q13:
					if (!this._IncludeIn[12]) return false;
					return true;
				case QueryType.Q4:
					if (!this._IncludeIn[3]) return false;
					return true;
				case QueryType.Q10:
					if (!this._IncludeIn[9]) return false;
					return true;
				case QueryType.Q14:
					if (!this._IncludeIn[13]) return false;
					return true;
				case QueryType.Q20:
					if (!this._IncludeIn[19]) return false;
					return true;
				case QueryType.Q5:
					if (!this._IncludeIn[4]) return false;
					return true;
				case QueryType.Q15:
					if (!this._IncludeIn[14]) return false;
					return true;
				case QueryType.Q6:
					if (!this._IncludeIn[5]) return false;
					return true;
				case QueryType.Q16:
					if (!this._IncludeIn[15]) return false;
					return true;
				case QueryType.Q7:
					if (!this._IncludeIn[6]) return false;
					return true;
				case QueryType.Q17:
					if (!this._IncludeIn[16]) return false;
					return true;
				case QueryType.Q8:
					if (!this._IncludeIn[7]) return false;
					return true;
				case QueryType.Q18:
					if (!this._IncludeIn[17]) return false;
					return true;
				case QueryType.Q9:
					if (!this._IncludeIn[8]) return false;
					return true;
				case QueryType.Q19:
					if (!this._IncludeIn[18]) return false;
					return true;
				default: return false;
			}
		}
		internal static int Comparise(Fund fund, Fund fund_2)
		{
			/*if (fund == null && fund_2 == null) return 0;
			if (fund == null) return 1;
			if (fund_2 == null) return -1;*/
			if (fund._Type != fund_2._Type) return 0;
			switch (fund._Type)
			{
				case QueryType.Q1:
				case QueryType.Q11:
					return (fund.PercentageChangeInNAV <= fund_2.PercentageChangeInNAV) ? (1) : (-1);
				case QueryType.Q2:
				case QueryType.Q12:
					return (fund.PercentageChangeInNAVLong <= fund_2.PercentageChangeInNAVLong)?(1):(-1);
				case QueryType.Q3:
				case QueryType.Q13:
                	return (fund.PerformanceScoreRank >= fund_2.PerformanceScoreRank)?(1):(-1);
				case QueryType.Q4:
				case QueryType.Q10:
				case QueryType.Q14:
				case QueryType.Q20:
					return (fund.PerformanceImprovementPercentageRank >= fund_2.PerformanceImprovementPercentageRank)?(1):(-1);
				case QueryType.Q5:
				case QueryType.Q15:
                	return (fund.HighestRatingRank >= fund_2.HighestRatingRank)?(1):(-1);
				case QueryType.Q6:
				case QueryType.Q16:
                	return (fund.DaysSinceLaunch >= fund_2.DaysSinceLaunch)?(1):(-1);
				case QueryType.Q7:
				case QueryType.Q17:
					return (fund.OverallScoreRank >= fund_2.OverallScoreRank)?(1):(-1);
				case QueryType.Q8:
				case QueryType.Q18:
					return (fund.TodayNav <= fund_2.TodayNav)?(1):(-1);
				case QueryType.Q9:
				case QueryType.Q19:
					return (fund.TodayNav >= fund_2.TodayNav)?(1):(-1);
				default: return 0;
			}
		}
		internal static Fund Create(DataBase dataBase, string header, string v, string separator)
		{
			Fund result = new Fund();
			result._DataBase = dataBase;
			result._Header = header;
			result._History = new History[HISTORY_LENGTH];
			string[] data = v.Split(new string[] { separator }, StringSplitOptions.None);
			result._Id = data[0].Trim();
			if (result._Id.Length < 1) return null;
			result._Name = data[1].Trim();
			if (result._Name.Length < 1) return null;
			result._Category = data[2].Trim();
			if (result._Category.Length < 1) return null;
			try { result._LaunchDate = DateTime.Parse(data[3].Trim()); }
			catch { return null; }
			result._Notes = new string[7];
			for (int i = 0; i < 7; i++) result._Notes[i] = data[i + 4].Trim();
			result._IncludeIn = new bool[20];
			for (int i = 0; i < 20; i++) result._IncludeIn[i] = (data[i + 11].ToUpper().Trim() == "YES");
			return result;
		}
		internal void AddHistory(History v, int shift)
		{
			if (v != null)
			{
				int di = DateTime.Now.Subtract(v.Date).Days - shift;
				if (di >= 0 && di < this._History.Length) this._History[di] = v;
			}
		}
		internal string PrintDebug()
		{
			string history = "";
			for (int i = 0; i < this._History.Length; i++)
			{
				if (this._History[i] == null) history += "[null]";
				else history += this._History[i].PrintDump();
			}
			return string.Format(
@"
--------------------
	id: {0},
	query_type: {1},
	category: {2},
	name: {3},
	launch_date: {4},
	notes: -,
	include: -,
	history: {5}
--------------------
", 
			this._Id, this._Type, this._Category, _Name, this._LaunchDate, history);
		}
	}
}
