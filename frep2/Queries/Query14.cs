using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query14: Query
    {
        public Query14(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q14; }
        public override IEnumerable<QueryResult> GetResult()
        {
            this._DataBase.Category = "All";
            List<QueryResult> result = new List<QueryResult>();
            List<string> keys = new List<string>();
            foreach (string id in this._DataBase.Data.Keys)
                if (this._DataBase.Data[id].IsConsidered(this._Settings, this._QueryType))
                    keys.Add(id);
            keys = new List<string>(keys);
            //this.CalculateRanks(keys);
            keys.Sort(new Comparison<string>(delegate(string a, string b)
            {
                double x = this._DataBase.Data[a].performanceImprovementPercentage;
                double y = this._DataBase.Data[b].performanceImprovementPercentage;
                //return x.CompareTo(y);
                return y.CompareTo(x);
            }));
            result.Add(new QueryResult(QueryType.Q14, null, keys));
            return result;
        }
    }
}
