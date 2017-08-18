using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query10: Query
    {
        public Query10(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q10; }
        public override IEnumerable<QueryResult> GetResult()
        {
            Dictionary<string, List<string>> byCategory = new Dictionary<string, List<string>>();
            foreach (string id in this._DataBase.Data.Keys)
            {
                if (this._DataBase.Data[id].IsConsidered(this._Settings, this._QueryType))
                {
                    foreach (string category in this._DataBase.Data[id].Categories)
                    {
                        if (byCategory.ContainsKey(category)) byCategory[category].Add(id);
                        else byCategory.Add(category, new List<string>(new string[] { id }));
                    }
                }
            }
            List<QueryResult> result = new List<QueryResult>();

            foreach (string category in byCategory.Keys)
            {
                //string category = "All";
                //this._DataBase.Category = category;
                List<string> keys = new List<string>(byCategory[category]);
                //this.CalculateRanks(keys);
                keys.Sort(new Comparison<string>(delegate(string a, string b)
                {
                    double x = this._DataBase.Data[a].performanceImprovementPercentage;
                    double y = this._DataBase.Data[b].performanceImprovementPercentage;
                    //return x.CompareTo(y);
                    return y.CompareTo(x);
                }));
                //int i = 1;
                //foreach (string key in keys) this._DataBase.Data[key].SetPerformanceImprovementPercentageRank(i++);
                result.Add(new QueryResult(QueryType.Q10, category, keys));
                //this._DataBase.Category = "All";
            }

            return result;
        }
    }
}
