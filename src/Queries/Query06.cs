using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query06 : Query
    {
        public Query06(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q6; }
        public override IEnumerable<QueryResult> GetResult()
        {
            Dictionary<string, List<string>> byCategory = this.SplitByCategories();
            List<QueryResult> result = new List<QueryResult>();

            foreach (string category in byCategory.Keys)
            {
                List<string> keys = new List<string>(byCategory[category]);
                keys.Sort(new Comparison<string>(delegate (string a, string b)
                {
                    double x = this._DataBase.Data[a].daysSinceLaunch;
                    double y = this._DataBase.Data[b].daysSinceLaunch;
                    return x.CompareTo(y);
                }));
                result.Add(new QueryResult(QueryType.Q6, category, keys));
            }

            return result;
        }
    }
}
