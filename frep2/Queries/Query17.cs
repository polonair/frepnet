using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query17: Query
    {
        public Query17(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q17; }
        public override IEnumerable<QueryResult> GetResult()
        {
            List<QueryResult> result = new List<QueryResult>();
            List<string> keys = new List<string>();
            foreach (string id in this._DataBase.Data.Keys) if (this.IsConsidered(id)) keys.Add(id);
            keys = new List<string>(keys);
            this.CalculateRanks(keys);
            result.Add(new QueryResult(QueryType.Q17, null, keys));
            return result;
        }
        protected override bool IsConsidered(string id)
        {
            Fund f = this._DataBase.Data[id];

            if (!base.IsConsidered(id)) return false;

            if ((!f.IncludedIn(QueryType.Q17)) ||
                (!f.IncludedIn(QueryType.Q13)) ||
                (!f.IncludedIn(QueryType.Q14)) ||
                (!f.IncludedIn(QueryType.Q15)) ||
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