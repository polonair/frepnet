using System;
using System.Collections.Generic;
using System.Text;

namespace frep2
{
    partial class Fund
    {
        private double _TotalBondSales = double.NaN;
        private double _ValueResearchRating = double.NaN;
        private double _YesterdayNav = double.NaN;
        private double _TodayNav = double.NaN;
        private double _ChangeInNAV = double.NaN;
        private double _PercentageChangeInNAV = double.NaN;
        private double _PerformanceScore = double.NaN;
        private double _PerformanceScore20 = double.NaN;
        private double _ValueResearchRating20 = double.NaN;
        private double _TotalBondSales20 = double.NaN;
        private double _PerformanceImprovementPercentage = double.NaN;
        private double _PreviousNav = double.NaN;
        private double _LowestNAV = double.NaN;
        private double _HighestNAV = double.NaN;
        private double _ChangeInNavLong = double.NaN;
        private double _PercentageChangeInNAVLong = double.NaN;
        /*private int _PerformanceScoreRank = 0;
        private int _PerformanceImprovementPercentageRank = 0;
        private int _HighestRatingRank = 0;
        private int _OverallScore = 0;
        private int _OverallScoreRank = 0;*/

        public string note1 { get { return this._Notes[0]; } }
        public string note2 { get { return this._Notes[1]; } }
        public string note3 { get { return this._Notes[2]; } }
        public string note4 { get { return this._Notes[3]; } }
        public string note5 { get { return this._Notes[4]; } }
        public string note6 { get { return this._Notes[5]; } }
        public string note7 { get { return this._Notes[6]; } }
        public DateTime fundLaunchDate { get { return this._LaunchDate; } }
        public string fundName { get { return this._Name; } }
        public double totalBondSales { get { return this._TotalBondSales; } }
        public double yesterdayNAV { get { return this._YesterdayNav; } }
        public double todayNAV { get { return this._TodayNav; } }
        public double changeInNAV { get { return this._ChangeInNAV; } }
        public double percentageChangeInNAV { get { return this._PercentageChangeInNAV; } }
        public double performanceScore { get { return this._PerformanceScore; } }
        public double valueResearchRating { get { return this._ValueResearchRating; } }
        public double todayRating { get { return this._ValueResearchRating; } }
        public double todaySales { get { return this._TotalBondSales; } }
        public double performanceScore20 { get { return this._PerformanceScore20; } }
        public double valueResearchRating20 { get { return this._ValueResearchRating20; } }
        public double totalBondSales20 { get { return this._TotalBondSales20; } }
        public double performanceImprovementPercentage { get { return this._PerformanceImprovementPercentage; } }
        public double previousNAV { get { return this._PreviousNav; } }
        public double lowestNAV { get { return this._LowestNAV; } }
        public double highestNAV { get { return this._HighestNAV; } }
        public double navChange { get { return this._ChangeInNAV; } }
        public double navChangePercentage { get { return this._PercentageChangeInNAV; } }
        public double navChangeLong { get { return this._ChangeInNavLong; } }
        public double navChangeLongPercentage { get { return this._PercentageChangeInNAVLong; } }

        public RankType overallScoreRank
        {
            get
            {
                if (this._OverallScoreRanks.ContainsKey(this._DataBase.Category))
                    return RankType.FromInt(this._OverallScoreRanks[this._DataBase.Category]);
                else
                    return RankType.NA;                
            }
        }
        public RankType performanceScoreRank
        {
            get
            {
                if (this._PerformanceScoreRanks.ContainsKey(this._DataBase.Category))
                    return RankType.FromInt(this._PerformanceScoreRanks[this._DataBase.Category]);
                else
                    return RankType.NA;                
            }
        }
        public RankType highestRatingRank
        {
            get
            {
                if (this._HighestRatingRanks.ContainsKey(this._DataBase.Category))
                    return RankType.FromInt(this._HighestRatingRanks[this._DataBase.Category]);
                else
                    return RankType.NA;                
            }
        }
        public RankType performanceImprovementPercentageRank
        {
            get
            {
                if (this._PerformanceImprovementPercentageRanks.ContainsKey(this._DataBase.Category))
                    return RankType.FromInt(this._PerformanceImprovementPercentageRanks[this._DataBase.Category]);
                else
                    return RankType.NA;                
            }
        }
        public RankType valueResearchRatingRank
        {
            get
            {
                if (this._HighestRatingRanks.ContainsKey(this._DataBase.Category))
                    return RankType.FromInt(this._HighestRatingRanks[this._DataBase.Category]);
                else
                    return RankType.NA;                
            }
        }
        public RankType overallScore
        {
            get
            {
                if (this._OverallScores.ContainsKey(this._DataBase.Category))
                    return RankType.FromInt(this._OverallScores[this._DataBase.Category]);
                else
                    return RankType.NA;
            }
        }


        public string FundID { get { return this._Id; } }
        public string FundName { get { return this._Name; } }
        public DateTime FundLaunchDate { get { return this._LaunchDate; } }
        public int daysSinceLaunch { get { return DateTime.Now.Subtract(this._LaunchDate).Days; } }
        public int daysSinceLaunch20 { get { return DateTime.Now.Subtract(this._LaunchDate).Days - 20; } }

        public DateTime day1date { get { return DateTime.Now; } }
        public DateTime day2date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(1)); } }
        public DateTime day3date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(2)); } }
        public DateTime day4date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(3)); } }
        public DateTime day5date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(4)); } }
        public DateTime day6date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(5)); } }
        public DateTime day7date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(6)); } }
        public DateTime day8date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(7)); } }
        public DateTime day9date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(8)); } }
        public DateTime day10date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(9)); } }
        public DateTime day11date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(10)); } }
        public DateTime day12date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(11)); } }
        public DateTime day13date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(12)); } }
        public DateTime day14date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(13)); } }
        public DateTime day15date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(14)); } }
        public DateTime day16date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(15)); } }
        public DateTime day17date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(16)); } }
        public DateTime day18date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(17)); } }
        public DateTime day19date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(18)); } }
        public DateTime day20date { get { return DateTime.Now.Subtract(TimeSpan.FromDays(19)); } }

        public string Note1 { get { return this._Notes[0]; } }
        public string Note2 { get { return this._Notes[1]; } }
        public string Note3 { get { return this._Notes[2]; } }
        public string Note4 { get { return this._Notes[3]; } }
        public string Note5 { get { return this._Notes[4]; } }
        public string Note6 { get { return this._Notes[5]; } }
        public string Note7 { get { return this._Notes[6]; } }

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
        private string __getDayNav(int shift)
        {
            if (shift >= this.History.Length) return "None";
            if (this._History[shift] == null) return "None";
            if (double.IsNaN(this._History[shift].Nav)) return "None";
            return this._History[shift].Nav.ToString();
        }
    }
}
