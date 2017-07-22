using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query17: Query
    {
        public Query17(DataBase database) : base(database) { }
        public override IEnumerable<QueryResult> GetResult()
        {
            List<string> keys = new List<string>();
            foreach (string id in this._DataBase.Data.Keys) if (this.IsConsidered(id)) keys.Add(id);
            keys = new List<string>(keys);
            List<QueryResult> result = new List<QueryResult>();
            keys.Sort(new Comparison<string>(delegate(string a, string b)
            {
                // BIG TODO
                return 0;
            }));
            result.Add(new QueryResult(QueryType.Q17, null, keys));
            return result;
        }
        protected override bool IsConsidered(string id)
        {
            Fund f = this._DataBase.Data[id];

            if ((!f.IncludedIn(QueryType.Q17)) ||
                (
                    double.IsNaN(f.valueResearchRating) &&
                    double.IsNaN(f.totalBondSales) &&
                    double.IsNaN(f.todayNAV)
                ))
                return false;
            return true;
        }
    }
}