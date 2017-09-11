using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query01 : Query
    {
        public Query01(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q1; }
        public override IEnumerable<QueryResult> GetResult()
        {
            Dictionary<string, List<string>> byCategory = this.SplitByCategories();
            List<QueryResult> result = new List<QueryResult>();

            foreach (string category in byCategory.Keys)
            {
                List<string> keys = new List<string>(byCategory[category]);
                keys.Sort(new Comparison<string>(delegate (string a, string b)
                {
                    double x = this._DataBase.Data[a].percentageChangeInNAV;
                    double y = this._DataBase.Data[b].percentageChangeInNAV;
                    return y.CompareTo(x);
                }));
                result.Add(new QueryResult(QueryType.Q1, category, keys));
            }

            return result;
        }
    }
}
