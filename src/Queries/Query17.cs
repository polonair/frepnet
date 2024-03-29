using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query17 : Query
    {
        public Query17(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q17; }
        public override IEnumerable<QueryResult> GetResult()
        {
            string category = "All";
            List<QueryResult> result = new List<QueryResult>();
            List<string> keys = new List<string>();
            foreach (string id in this._DataBase.Data.Keys)
                if (this._DataBase.Data[id].IsConsidered(this._Settings, QueryType.Q13) &&
                    this._DataBase.Data[id].IsConsidered(this._Settings, QueryType.Q14) &&
                    this._DataBase.Data[id].IsConsidered(this._Settings, QueryType.Q15) &&
                    this._DataBase.Data[id].IsConsidered(this._Settings, QueryType.Q17))
                    keys.Add(id);
            keys = new List<string>(keys);
            keys.Sort(new Comparison<string>(delegate (string a, string b)
            {
                double x = this._DataBase.Data[a].overallScoreRank[category];
                double y = this._DataBase.Data[b].overallScoreRank[category];
                return x.CompareTo(y);
            }));
            result.Add(new QueryResult(QueryType.Q17, null, keys));
            return result;
        }
    }
}
