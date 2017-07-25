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
            Dictionary<string, List<string>> keys = new Dictionary<string, List<string>>();
            keys.Add("All", new List<string>());

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
                keys[category].Sort(new Comparison<string>(delegate(string a, string b)
                {
                    double x = this.Data[a].performanceScore;
                    double y = this.Data[b].performanceScore;
                    //return x.CompareTo(y);
                    return y.CompareTo(x);// 
                }));
                int i = 1;
                foreach (string id in keys[category])
                {
                    this.Data[id].SetPerformanceScoreRank(i++, category);
                }
            }
        }
        private void _CalculatePerformanceImprovementPercentageRank()
        {
            Dictionary<string, List<string>> keys = new Dictionary<string, List<string>>();
            keys.Add("All", new List<string>());

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
                keys[category].Sort(new Comparison<string>(delegate(string a, string b)
                {
                    double x = this.Data[a].performanceImprovementPercentage;
                    double y = this.Data[b].performanceImprovementPercentage;
                    //return x.CompareTo(y);
                    return y.CompareTo(x);// 
                }));
                int i = 1;
                foreach (string id in keys[category])
                {
                    this.Data[id].SetPerformanceImprovementPercentageRank(i++, category);
                }
            }
        }
        private void _CalculateHighestRatingRank()
        {
            Dictionary<string, List<string>> keys = new Dictionary<string, List<string>>();
            keys.Add("All", new List<string>());

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
                keys[category].Sort(new Comparison<string>(delegate(string a, string b)
                {
                    double x = this.Data[a].valueResearchRating;
                    double y = this.Data[b].valueResearchRating;
                    //return x.CompareTo(y);
                    return y.CompareTo(x);// 
                }));
                int i = 1;
                foreach (string id in keys[category])
                {
                    this.Data[id].SetHighestRatingRank(i++, category);
                }
            }
        }
        private void _CalculateOverallScore()
        {
            Dictionary<string, List<string>> keys = new Dictionary<string, List<string>>();
            keys.Add("All", new List<string>());

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
                this.Category = category;
                foreach (string id in keys[category])
                {
                    this.Data[id].SetOverallScore(
                        this.Data[id].performanceImprovementPercentageRank + 
                        this.Data[id].performanceScoreRank + 
                        this.Data[id].highestRatingRank,
                        category);
                }
                this.Category = "All";
            }
        }
        private void _CalculateOverallScoreRank()
        {
            Dictionary<string, List<string>> keys = new Dictionary<string, List<string>>();
            keys.Add("All", new List<string>());

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
                this.Category = category;
                keys[category].Sort(new Comparison<string>(delegate(string a, string b)
                {
                    double x = this.Data[a].overallScore;
                    double y = this.Data[b].overallScore;
                    return x.CompareTo(y);
                    //return y.CompareTo(x);// 
                }));
                this.Category = "All";
                int i = 1;
                foreach (string id in keys[category])
                {
                    this.Data[id].SetOverallScoreRank(i++, category);
                }
            }
        }
    }
}
