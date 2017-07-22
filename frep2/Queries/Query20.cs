using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query20: Query
    {
        public Query20(DataBase database) : base(database) { }
        public override IEnumerable<QueryResult> GetResult()
        {
            List<string> keys = new List<string>();
            foreach (string id in this._DataBase.Data.Keys) if (this.IsConsidered(id)) keys.Add(id);
            keys = new List<string>(keys);
            List<QueryResult> result = new List<QueryResult>();
            keys.Sort(new Comparison<string>(delegate(string a, string b)
            {
                double x = this._DataBase.Data[a].performanceImprovementPercentage;
                double y = this._DataBase.Data[b].performanceImprovementPercentage;
                //return x.CompareTo(y);
                return y.CompareTo(x);
            }));
            result.Add(new QueryResult(QueryType.Q20, null, keys));
            return result;
        }
        protected override bool IsConsidered(string id)
        {
            Fund f = this._DataBase.Data[id];

            if ((!f.IncludedIn(QueryType.Q20)) ||
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
