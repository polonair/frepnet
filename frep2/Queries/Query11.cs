using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query11: Query
    {
        public Query11(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q11; }
        public override IEnumerable<QueryResult> GetResult()
        {
            List<QueryResult> result = new List<QueryResult>();
            List<string> keys = new List<string>();
            foreach (string id in this._DataBase.Data.Keys) if (this.IsConsidered(id)) keys.Add(id);
            keys = new List<string>(keys);
            this.CalculateRanks(keys);
            keys.Sort(new Comparison<string>(delegate(string a, string b)
            {
                double x = this._DataBase.Data[a].percentageChangeInNAV;
                double y = this._DataBase.Data[b].percentageChangeInNAV;
                //return x.CompareTo(y);
                return y.CompareTo(x);
            }));
            result.Add(new QueryResult(QueryType.Q11, null, keys));
            return result;
        }
        protected override bool IsConsidered(string id)
        {
            Fund f = this._DataBase.Data[id];

            if (!base.IsConsidered(id)) return false;

            if ((f.History.Length < 1) ||
                (!f.IncludedIn(QueryType.Q11)) ||
                (
                    double.IsNaN(f.valueResearchRating) &&
                    double.IsNaN(f.totalBondSales) &&
                    double.IsNaN(f.todayNAV)
                ) ||
                (f.percentageChangeInNAV <= 0) ||
                double.IsNaN(f.percentageChangeInNAV) ||
                (
                    (f.History.Length > 0) &&
                    ((f.History[0] == null) || (double.IsNaN(f.History[0].Nav)))
                ))
                return false;
            return true;
        }
    }
}
