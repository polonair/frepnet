using System;
using System.Collections.Generic;
using System.Text;

namespace frep2
{
    partial class Fund
    {
        private RankType _PerformanceScoreRanks = new RankType();
        private RankType _PerformanceImprovementPercentageRanks = new RankType();
        private RankType _HighestRatingRanks = new RankType();
        private RankType _OverallScores = new RankType();
        private RankType _OverallScoreRanks = new RankType();

        private void calculatePercentageChangeInNAVLong()
        {
            double result = double.NaN;
            if (double.IsNaN(this.navChangeLong)) result = double.NaN;
            else if (this.previousNAV == 0) result = double.NaN;
            else result = 100 * this.navChangeLong / this.previousNAV;
            this._PercentageChangeInNAVLong = result;
        }
        private void calculateChangeInNavLong()
        {
            double result = this.previousNAV - this.todayNAV;
            this._ChangeInNavLong = result;
        }
        private void calculateHighestNav()
        {
            double result = double.MinValue;
            int cnt = 0;
            int countTo = Math.Min(this.History.Length, 20);
            for (int i = 0; i < countTo; i++)
            {
                if (this.History[i] != null && !double.IsNaN(this.History[i].Nav))
                {
                    cnt++;
                    if (this.History[i].Nav > result) result = this.History[i].Nav;
                }
            }
            if (cnt < 1) result = double.NaN;
            this._HighestNAV = result;
        }
        private void calculateLowestNav()
        {
            double result = double.MaxValue;
            int cnt = 0;
            int countTo = Math.Min(this.History.Length, 20);
            for (int i = 0; i < countTo; i++)
            {
                if (this.History[i] != null && !double.IsNaN(this.History[i].Nav))
                {
                    cnt++;
                    if (this.History[i].Nav < result) result = this.History[i].Nav;
                }
            }
            if (cnt < 1) result = double.NaN;
            this._LowestNAV = result;
        }
        private void calculateLowestNavNew()
        {
            double result = double.MaxValue;
            int cnt = 0;
            int countTo = Math.Min(this.History.Length, 20);
            for (int i = 1; i < countTo; i++)
            {
                if (this.History[i] != null && !double.IsNaN(this.History[i].Nav))
                {
                    cnt++;
                    if (this.History[i].Nav < result) result = this.History[i].Nav;
                }
            }
            if (cnt < 1) result = double.NaN;
            this._LowestNAVNew = result;
        }
        private void calculatePreviousNav()
        {
            double result = double.NaN;
            if ((this.History.Length > 20) &&
                this.History[20] != null &&
                !double.IsNaN(this.History[20].Nav))
            {
                result = this.History[20].Nav;
            }
            else
            {
                double average = 0;
                int count = 0;
                int countFrom = Math.Min(this.History.Length - 1, 20);
                for (int i = countFrom; i > 10 && count < 5; i--)
                {
                    if (this.History[i] != null && !double.IsNaN(this.History[i].Nav))
                    {
                        average += this.History[i].Nav;
                        count += 1;
                    }
                }
                if (count == 5) result = average / 5;
            }
            this._PreviousNav = result;
        }
        private void calculatePerformanceImprovementPercentage()
        {
            double result = double.NaN;
            double ps20 = this.performanceScore20;
            if (ps20 != 0 && !double.IsNaN(ps20)) result = 100 * this.performanceScore / ps20;
            this._PerformanceImprovementPercentage = result;
        }
        private void calculateTotalBondSales20()
        {
            double result = 0;
            for (int i = 20; i < this.History.Length; i++)
            {
                if (this.History[i] != null && !double.IsNaN(this.History[i].TotalBondSales))
                {
                    result = this.History[i].TotalBondSales;
                    break;
                }
            }
            this._TotalBondSales20 = result;
        }
        private void calculateValueResearchRating20()
        {
            double result = 0;
            for (int i = 20; i < this.History.Length; i++)
            {
                if (this.History[i] != null && !double.IsNaN(this.History[i].ValueResearchRating))
                {
                    result = this.History[i].ValueResearchRating;
                    break;
                }
            }
            this._ValueResearchRating20 = result;
        }
        private void calculatePerformanceScore20()
        {
            double result = double.NaN;
            if (this.daysSinceLaunch == 0) result = 0;
            else result = (this.valueResearchRating20 * this.totalBondSales20) / this.daysSinceLaunch20;
            this._PerformanceScore20 = result;
        }
        private void calculatePerformanceScore()
        {
            double result = double.NaN;
            for (int i = 10; i > 0; i++)
            {
                if (!double.IsNaN(this.History[i].TotalBondSales))
                {
                    result = (this.valueResearchRating * (this.totalBondSales - this.History[i].TotalBondSales)) / i;
                    break;
                }
            }
            this._PerformanceScore = result;
        }
        private void calculatePercentageChangeInNAV()
        {
            double result = double.NaN;
            if (double.IsNaN(this.changeInNAV)) result = double.NaN;
            else if (this.yesterdayNAV == 0) result = double.NaN;
            else result = 100 * this.changeInNAV / this.yesterdayNAV;
            this._PercentageChangeInNAV = result;
        }
        private void calculatePercentageChangeInNAVNew()
        {
            double result = double.NaN;
            if (double.IsNaN(this.changeInNAVNew)) result = double.NaN;
            else if (this.lowestNAVNew == 0) result = double.NaN;
            else result = 100 * this.changeInNAVNew / this.lowestNAVNew;
            this._PercentageChangeInNAVNew = result;
        }
        private void calculateChangeInNav()
        {
            double result = this.yesterdayNAV - this.todayNAV;
            this._ChangeInNAV = result;
        }
        private void calculateChangeInNavNew()
        {
            double result = this.lowestNAVNew - this.todayNAV;
            this._ChangeInNAVNew = result;
        }
        private void calculateTodayNav()
        {
            double result = double.NaN;
            if ((this.History.Length > 0) &&
                this.History[0] != null &&
                !double.IsNaN(this.History[0].Nav))
            {
                result = this.History[0].Nav;
            }
            else
            {
                if (this.History.Length > 1)
                {
                    double average = 0;
                    int count = 0;
                    int countTo = Math.Min(this.History.Length, 11);
                    for (int i = 1; i < countTo && count < 5; i++)
                    {
                        if (this.History[i] != null && !double.IsNaN(this.History[i].Nav))
                        {
                            average += this.History[i].Nav;
                            count += 1;
                        }
                    }
                    if (count == 5) result = average / 5;
                }
            }
            this._TodayNav = result;
        }
        private void calculateYesterdayNav()
        {
            double result = double.NaN;
            if ((this.History.Length > 1) &&
                this.History[1] != null &&
                !double.IsNaN(this.History[1].Nav))
            {
                result = this.History[1].Nav;
            }
            else
            {
                if (this.History.Length > 2)
                {
                    double average = 0;
                    int count = 0;
                    int countTo = Math.Min(this.History.Length, 12);
                    for (int i = 2; i < countTo && count < 5; i++)
                    {
                        if (this.History[i] != null && !double.IsNaN(this.History[i].Nav))
                        {
                            average += this.History[i].Nav;
                            count += 1;
                        }
                    }
                    if (count == 5) result = average / 5;
                }
            }
            this._YesterdayNav = result;
        }
        private void calculateTotalBondSales()
        {
            double result = 0;
            for (int i = 0; i < this.History.Length; i++)
            {
                if (this.History[i] != null && !double.IsNaN(this.History[i].TotalBondSales))
                {
                    result = this.History[i].TotalBondSales;
                    break;
                }
            }
            this._TotalBondSales = result;
        }
        private void calculateValueResearchRating()
        {
            double result = 0;
            for (int i = 0; i < this.History.Length; i++)
            {
                if (this.History[i] != null && !double.IsNaN(this.History[i].ValueResearchRating))
                {
                    result = this.History[i].ValueResearchRating;
                    break;
                }
            }
            this._ValueResearchRating = result;
        }
    }
}
