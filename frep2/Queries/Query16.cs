using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query16: Query
    {
        public Query16(DataBase database) : base(database) { }
        public override IEnumerable<QueryResult> GetResult()
        {
            List<QueryResult> result = new List<QueryResult>();
            List<string> keys = new List<string>();
            foreach (string id in this._DataBase.Data.Keys) if (this.IsConsidered(id)) keys.Add(id);
            keys = new List<string>(keys);
            this.CalculateRanks(keys);
            keys.Sort(new Comparison<string>(delegate(string a, string b)
            {
                double x = this._DataBase.Data[a].daysSinceLaunch;
                double y = this._DataBase.Data[b].daysSinceLaunch;
                return x.CompareTo(y);
                //return y.CompareTo(x);
            }));
            result.Add(new QueryResult(QueryType.Q16, null, keys));
            return result;
        }
        protected override bool IsConsidered(string id)
        {
            Fund f = this._DataBase.Data[id];

            if ((!f.IncludedIn(QueryType.Q16)) ||
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
