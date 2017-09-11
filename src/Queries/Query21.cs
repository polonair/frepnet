using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query21 : Query
    {
        public Query21(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q21; }
        public override IEnumerable<QueryResult> GetResult()
        {
            Dictionary<string, List<string>> byCategory = this.SplitByCategories();
            List<QueryResult> result = new List<QueryResult>();

            foreach (string category in byCategory.Keys)
            {
                List<string> keys = new List<string>(byCategory[category]);
                keys.Sort(new Comparison<string>(delegate (string a, string b)
                {
                    double x = this._DataBase.Data[a].percentageChangeInNAVNew;
                    double y = this._DataBase.Data[b].percentageChangeInNAVNew;
                    return y.CompareTo(x);
                }));
                result.Add(new QueryResult(QueryType.Q21, category, keys));
            }

            return result;
        }
    }
}
