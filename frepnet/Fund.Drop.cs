using System;
namespace frepnet
{
	partial class Fund
	{
		public string note1 { get { return this._Notes[0]; } }
		public string note2 { get { return this._Notes[1]; } }
		public string note3 { get { return this._Notes[2]; } }
		public string note4 { get { return this._Notes[3]; } }
		public string note5 { get { return this._Notes[4]; } }
		public string note6 { get { return this._Notes[5]; } }
		public string note7 { get { return this._Notes[6]; } }
		public string fundName { get { return this._Name; } }
		public double valueResearchRating { get { return this.ValueResearchRating; } }
		public double totalBondSales { get { return this.TotalBondSales; } }
		public int performanceScoreRank { get { return this.PerformanceScoreRank; } }
		public double yesterdayNAV { get { return this.YesterdayNav; } }
		public double todayNAV { get { return this.TodayNav; } }
		public double changeInNAV { get { return this.ChangeInNAV; } }
		public double percentageChangeInNAV { get { return this.PercentageChangeInNAV; } }
		public int daysSinceLaunch { get { return this.DaysSinceLaunch; } }
		public double performanceScore { get { return this.PerformanceScore; } }
		public double performanceImprovementPercentage { get { return this.PerformanceImprovementPercentage; } }
		public DateTime fundLaunchDate { get { return this._LaunchDate; } }
		public int performanceImprovementPercentageRank { get { return this.PerformanceImprovementPercentageRank; } }
		public int valueResearchRatingRank { get { return this.HighestRatingRank; } }
		public double overallScore { get { return this.OverallScore; } }
		public int highestRatingRank { get { return this.HighestRatingRank; } }
		//--
		public string Note1 { get { return this._Notes[0]; } }
		public string Note2 { get { return this._Notes[1]; } }
		public string Note3 { get { return this._Notes[2]; } }
		public string Note4 { get { return this._Notes[3]; } }
		public string Note5 { get { return this._Notes[4]; } }
		public string Note6 { get { return this._Notes[5]; } }
		public string Note7 { get { return this._Notes[6]; } }

		public string FundID { get { return this._Id; } }
		public string FundName { get { return this._Name; } }
		public string FundLaunchDate { get { return string.Format("{0:dd MMMM yyyy}", this._LaunchDate); } }
		public double previousNAV { get { return this.PreviousNav; } }
		public double lowestNAV { get { return this.LowestNAV; } }
		public double highestNAV { get { return this.HighestNAV; } }
		public double todayRating { get { return this.ValueResearchRating; } }
		public double todaySales { get { return this.TotalBondSales; } }
		public double navChange { get { return this.ChangeInNAV; } }
		public double navChangePercentage { get { return this.PercentageChangeInNAV; } }
		public double navChangeLong { get { return this.ChangeInNavLong; } }
		public double navChangeLongPercentage { get { return this.PercentageChangeInNAVLong; } }
		public double overallScoreRank { get { return this.OverallScoreRank; } }

		public string day1date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now); } }
		public string day2date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(1))); } }
		public string day3date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(2))); } }
		public string day4date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(3))); } }
		public string day5date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(4))); } }
		public string day6date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(5))); } }
		public string day7date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(6))); } }
		public string day8date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(7))); } }
		public string day9date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(8))); } }
		public string day10date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(9))); } }
		public string day11date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(10))); } }
		public string day12date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(11))); } }
		public string day13date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(12))); } }
		public string day14date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(13))); } }
		public string day15date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(14))); } }
		public string day16date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(15))); } }
		public string day17date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(16))); } }
		public string day18date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(17))); } }
		public string day19date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(18))); } }
		public string day20date { get { return string.Format("{0:dd MMMM yyyy}", DateTime.Now.Subtract(TimeSpan.FromDays(19))); } }

		private string __getDayNav(int shift)
		{
			if (this._History[shift] == null) return "None";
			if (double.IsNaN(this._History[shift].Nav)) return "None";
			return this._History[shift].Nav.ToString();
		}

		public string day1NAV { get { return this.__getDayNav(0); } }
		public string day2NAV { get { return this.__getDayNav(1); } }
		public string day3NAV { get { return this.__getDayNav(2); } }
		public string day4NAV { get { return this.__getDayNav(3); } }
		public string day5NAV { get { return this.__getDayNav(4); } }
		public string day6NAV { get { return this.__getDayNav(5); } }
		public string day7NAV { get { return this.__getDayNav(6); } }
		public string day8NAV { get { return this.__getDayNav(7); } }
		public string day9NAV { get { return this.__getDayNav(8); } }
		public string day10NAV { get { return this.__getDayNav(9); } }
		public string day11NAV { get { return this.__getDayNav(10); } }
		public string day12NAV { get { return this.__getDayNav(11); } }
		public string day13NAV { get { return this.__getDayNav(12); } }
		public string day14NAV { get { return this.__getDayNav(13); } }
		public string day15NAV { get { return this.__getDayNav(14); } }
		public string day16NAV { get { return this.__getDayNav(15); } }
		public string day17NAV { get { return this.__getDayNav(16); } }
		public string day18NAV { get { return this.__getDayNav(17); } }
		public string day19NAV { get { return this.__getDayNav(18); } }
		public string day20NAV { get { return this.__getDayNav(19); } }
	}
}
