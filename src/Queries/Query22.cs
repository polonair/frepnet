using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frep2.Queries
{
    class Query22:Query
    {
        public Query22(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q22; }
        public override IEnumerable<QueryResult> GetResult()
        {
            List<QueryResult> result = new List<QueryResult>();
            List<string> keys = new List<string>();
            foreach (string id in this._DataBase.Data.Keys)
                if (this._DataBase.Data[id].IsConsidered(this._Settings, this._QueryType))
                    keys.Add(id);
            keys = new List<string>(keys);
            keys.Sort(new Comparison<string>(delegate (string a, string b)
            {
                double x = this._DataBase.Data[a].percentageChangeInNAVNew;
                double y = this._DataBase.Data[b].percentageChangeInNAVNew;
                return y.CompareTo(x);
            }));
            result.Add(new QueryResult(QueryType.Q22, null, keys));
            return result;
        }
    }
}
