using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query13 : Query
    {
        public Query13(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q13; }
        public override IEnumerable<QueryResult> GetResult()
        {
            //string category = "All";
            //this._DataBase.Category = "All";
            List<QueryResult> result = new List<QueryResult>();
            List<string> keys = new List<string>();
            foreach (string id in this._DataBase.Data.Keys)
                if (this._DataBase.Data[id].IsConsidered(this._Settings, this._QueryType))
                    keys.Add(id);
            keys = new List<string>(keys);
            //this.CalculateRanks(keys);
            keys.Sort(new Comparison<string>(delegate(string a, string b)
            {
                double x = this._DataBase.Data[a].performanceScore;
                double y = this._DataBase.Data[b].performanceScore;
                //return x.CompareTo(y);
                return y.CompareTo(x);
            }));
            result.Add(new QueryResult(QueryType.Q13, null, keys));
            return result;
        }
    }
}
