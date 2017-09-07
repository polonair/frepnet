using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query07 : Query
    {
        public Query07(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q7; }
        public override IEnumerable<QueryResult> GetResult()
        {
            Dictionary<string, List<string>> byCategory = new Dictionary<string, List<string>>();
            foreach (string id in this._DataBase.Data.Keys)
            {
                if (this._DataBase.Data[id].IsConsidered(this._Settings, QueryType.Q3) &&
                    this._DataBase.Data[id].IsConsidered(this._Settings, QueryType.Q4) &&
                    this._DataBase.Data[id].IsConsidered(this._Settings, QueryType.Q5) &&
                    this._DataBase.Data[id].IsConsidered(this._Settings, QueryType.Q7))
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
                List<string> keys = new List<string>(byCategory[category]);
                keys.Sort(new Comparison<string>(delegate (string a, string b)
                {
                    double x = this._DataBase.Data[a].overallScoreRank[category];
                    double y = this._DataBase.Data[b].overallScoreRank[category];
                    return x.CompareTo(y);
                }));
                result.Add(new QueryResult(QueryType.Q7, category, keys));
            }
            return result;
        }
    }
}
