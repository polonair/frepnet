using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query09 : Query
    {
        public Query09(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q9; }
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
                    return x.CompareTo(y);
                }));
                result.Add(new QueryResult(QueryType.Q9, category, keys));
            }

            return result;
        }
    }
}
