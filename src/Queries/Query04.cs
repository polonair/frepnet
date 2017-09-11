using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query04 : Query
    {
        public Query04(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q4; }
        public override IEnumerable<QueryResult> GetResult()
        {
            Dictionary<string, List<string>> byCategory = this.SplitByCategories();
            List<QueryResult> result = new List<QueryResult>();

            foreach (string category in byCategory.Keys)
            {
                List<string> keys = new List<string>(byCategory[category]);
                keys.Sort(new Comparison<string>(delegate (string a, string b)
                {
                    double x = this._DataBase.Data[a].performanceImprovementPercentageRank[category];
                    double y = this._DataBase.Data[b].performanceImprovementPercentageRank[category];
                    return x.CompareTo(y);
                }));
                result.Add(new QueryResult(QueryType.Q4, category, keys));
            }

            return result;
        }
    }
}
