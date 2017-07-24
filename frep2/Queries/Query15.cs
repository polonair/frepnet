using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query15: Query
    {
        public Query15(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q15; }
        public override IEnumerable<QueryResult> GetResult()
        {
            List<QueryResult> result = new List<QueryResult>();
            List<string> keys = new List<string>();
            foreach (string id in this._DataBase.Data.Keys) if (this.IsConsidered(id)) keys.Add(id);
            keys = new List<string>(keys);
            this.CalculateRanks(keys);
            keys.Sort(new Comparison<string>(delegate(string a, string b)
            {
                double x = this._DataBase.Data[a].valueResearchRating;
                double y = this._DataBase.Data[b].valueResearchRating;
                int r = y.CompareTo(x);
                if (r != 0) return r;
                x = this._DataBase.Data[a].totalBondSales;
                y = this._DataBase.Data[b].totalBondSales;
                r = y.CompareTo(x);
                if (r != 0) return r;
                x = this._DataBase.Data[a].daysSinceLaunch;
                y = this._DataBase.Data[b].daysSinceLaunch;
                r = x.CompareTo(y);
                return r;
            }));
            result.Add(new QueryResult(QueryType.Q15, null, keys));
            return result;
        }
        protected override bool IsConsidered(string id)
        {
            Fund f = this._DataBase.Data[id];

            if (!base.IsConsidered(id)) return false;

            if ((!f.IncludedIn(QueryType.Q15)) ||
                double.IsNaN(f.todayNAV) ||
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
