using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query18: Query
    {
        public Query18(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q18; }
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
                double x = this._DataBase.Data[a].todayNAV;
                double y = this._DataBase.Data[b].todayNAV;
                //return x.CompareTo(y);
                return y.CompareTo(x);
            }));
            result.Add(new QueryResult(QueryType.Q18, null, keys));
            return result;
        }
    }
}