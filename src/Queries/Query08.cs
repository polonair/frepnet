using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query08 : Query
    {
        public Query08(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q8; }
        public override IEnumerable<QueryResult> GetResult()
        {
            Dictionary<string, List<string>> byCategory = this.SplitByCategories();
            List<QueryResult> result = new List<QueryResult>();

            foreach (string category in byCategory.Keys)
            {
                List<string> keys = new List<string>(byCategory[category]);
                keys.Sort(new Comparison<string>(delegate (string a, string b)
                {
                    double x = this._DataBase.Data[a].todayNAV;
                    double y = this._DataBase.Data[b].todayNAV;
                    return y.CompareTo(x);
                }));
                result.Add(new QueryResult(QueryType.Q8, category, keys));
            }

            return result;
        }
    }
}
