using System;
using System.Collections.Generic;
using System.Text;

namespace frep2
{
    partial class DataBase
    {
        private void CalculateRanks()
        {
            this._CalculatePerformanceScoreRank();
            this._CalculatePerformanceImprovementPercentageRank();
            this._CalculateHighestRatingRank();
            this._CalculateOverallScore();
            this._CalculateOverallScoreRank();
        }
        private void _CalculatePerformanceScoreRank()
        {
            Dictionary<string, List<string>> keys = new Dictionary<string, List<string>> { { "All", new List<string>() } };
            foreach (string key in this.Data.Keys)
            {
                if (this.Data[key].IsConsidered(this._Settings, QueryType.Q3))
                {
                    foreach (string category in this.Data[key].Categories)
                    {
                        if (keys.ContainsKey(category)) keys[category].Add(key);
                        else keys.Add(category, new List<string>(new string[] { key }));
                    }
                }
                if (this.Data[key].IsConsidered(this._Settings, QueryType.Q13))
                {
                    keys["All"].Add(key);
                }
            }

            foreach (string category in keys.Keys)
            {
                keys[category].Sort(new Comparison<string>(delegate (string a, string b)
                {
                    double x = this.Data[a].performanceScore;
                    double y = this.Data[b].performanceScore;
                    return y.CompareTo(x);
                }));
                int i = 1;
                foreach (string id in keys[category])
                {
                    this.Data[id].performanceScoreRank[category] = i++;
                }
            }
        }
        private void _CalculatePerformanceImprovementPercentageRank()
        {
            Dictionary<string, List<string>> keys = new Dictionary<string, List<string>> { { "All", new List<string>() } };
            foreach (string key in this.Data.Keys)
            {
                if (this.Data[key].IsConsidered(this._Settings, QueryType.Q4))
                {
                    foreach (string category in this.Data[key].Categories)
                    {
                        if (keys.ContainsKey(category)) keys[category].Add(key);
                        else keys.Add(category, new List<string>(new string[] { key }));
                    }
                }
                if (this.Data[key].IsConsidered(this._Settings, QueryType.Q14))
                {
                    keys["All"].Add(key);
                }
            }

            foreach (string category in keys.Keys)
            {
                keys[category].Sort(new Comparison<string>(delegate (string a, string b)
                {
                    double x = this.Data[a].performanceImprovementPercentage;
                    double y = this.Data[b].performanceImprovementPercentage;
                    return y.CompareTo(x);
                }));
                int i = 1;
                foreach (string id in keys[category])
                {
                    this.Data[id].performanceImprovementPercentageRank[category] = i++;
                }
            }
        }
        private void _CalculateHighestRatingRank()
        {
            Dictionary<string, List<string>> keys = new Dictionary<string, List<string>> { { "All", new List<string>() } };
            foreach (string key in this.Data.Keys)
            {
                if (this.Data[key].IsConsidered(this._Settings, QueryType.Q5))
                {
                    foreach (string category in this.Data[key].Categories)
                    {
                        if (keys.ContainsKey(category)) keys[category].Add(key);
                        else keys.Add(category, new List<string>(new string[] { key }));
                    }
                }
                if (this.Data[key].IsConsidered(this._Settings, QueryType.Q15))
                {
                    keys["All"].Add(key);
                }
            }

            foreach (string category in keys.Keys)
            {
                keys[category].Sort(new Comparison<string>(delegate (string a, string b)
                {
                    double x = this.Data[a].valueResearchRating;
                    double y = this.Data[b].valueResearchRating;
                    int r = y.CompareTo(x);
                    if (r != 0) return r;
                    x = this.Data[a].totalBondSales;
                    y = this.Data[b].totalBondSales;
                    r = y.CompareTo(x);
                    if (r != 0) return r;
                    x = this.Data[a].daysSinceLaunch;
                    y = this.Data[b].daysSinceLaunch;
                    r = x.CompareTo(y);
                    return r;
                }));
                int i = 1;
                foreach (string id in keys[category])
                {
                    this.Data[id].highestRatingRank[category] = i++;
                }
            }
        }
        private void _CalculateOverallScore()
        {
            Dictionary<string, List<string>> keys = new Dictionary<string, List<string>> { { "All", new List<string>() } };
            foreach (string key in this.Data.Keys)
            {
                if (this.Data[key].IsConsidered(this._Settings, QueryType.Q3) &&
                    this.Data[key].IsConsidered(this._Settings, QueryType.Q4) &&
                    this.Data[key].IsConsidered(this._Settings, QueryType.Q5) &&
                    this.Data[key].IsConsidered(this._Settings, QueryType.Q7))
                {
                    foreach (string category in this.Data[key].Categories)
                    {
                        if (keys.ContainsKey(category)) keys[category].Add(key);
                        else keys.Add(category, new List<string>(new string[] { key }));
                    }
                }
                if (this.Data[key].IsConsidered(this._Settings, QueryType.Q13) &&
                    this.Data[key].IsConsidered(this._Settings, QueryType.Q14) &&
                    this.Data[key].IsConsidered(this._Settings, QueryType.Q15) &&
                    this.Data[key].IsConsidered(this._Settings, QueryType.Q17))
                {
                    keys["All"].Add(key);
                }
            }

            foreach (string category in keys.Keys)
            {
                foreach (string id in keys[category])
                {
                    this.Data[id].overallScore[category] =
                        this.Data[id].performanceImprovementPercentageRank[category] +
                        this.Data[id].performanceScoreRank[category] +
                        this.Data[id].highestRatingRank[category];
                }
            }
        }
        private void _CalculateOverallScoreRank()
        {
            Dictionary<string, List<string>> keys = new Dictionary<string, List<string>> { { "All", new List<string>() } };
            foreach (string key in this.Data.Keys)
            {
                if (this.Data[key].IsConsidered(this._Settings, QueryType.Q3) &&
                    this.Data[key].IsConsidered(this._Settings, QueryType.Q4) &&
                    this.Data[key].IsConsidered(this._Settings, QueryType.Q5) &&
                    this.Data[key].IsConsidered(this._Settings, QueryType.Q7))
                {
                    foreach (string category in this.Data[key].Categories)
                    {
                        if (keys.ContainsKey(category)) keys[category].Add(key);
                        else keys.Add(category, new List<string>(new string[] { key }));
                    }
                }
                if (this.Data[key].IsConsidered(this._Settings, QueryType.Q13) &&
                    this.Data[key].IsConsidered(this._Settings, QueryType.Q14) &&
                    this.Data[key].IsConsidered(this._Settings, QueryType.Q15) &&
                    this.Data[key].IsConsidered(this._Settings, QueryType.Q17))
                {
                    keys["All"].Add(key);
                }
            }

            foreach (string category in keys.Keys)
            {
                keys[category].Sort(new Comparison<string>(delegate (string a, string b)
                {
                    double x = this.Data[a].overallScore[category];
                    double y = this.Data[b].overallScore[category];
                    return x.CompareTo(y);
                }));
                int i = 1;
                foreach (string id in keys[category])
                {
                    this.Data[id].overallScoreRank[category] = i++;
                }
            }
        }
    }
}
