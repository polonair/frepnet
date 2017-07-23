using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query12: Query
    {
        public Query12(DataBase database) : base(database) { }
        public override IEnumerable<QueryResult> GetResult()
        {
            List<QueryResult> result = new List<QueryResult>();
            List<string> keys = new List<string>();
            foreach (string id in this._DataBase.Data.Keys) if (this.IsConsidered(id)) keys.Add(id);
            keys = new List<string>(keys);
            this.CalculateRanks(keys);
            keys.Sort(new Comparison<string>(delegate(string a, string b)
            {
                double x = this._DataBase.Data[a].navChangeLongPercentage;
                double y = this._DataBase.Data[b].navChangeLongPercentage;
                //return x.CompareTo(y);
                return y.CompareTo(x);
            }));
            result.Add(new QueryResult(QueryType.Q12, null, keys));
            return result;
        }
        protected override bool IsConsidered(string id)
        {
            Fund f = this._DataBase.Data[id];

            if ((f.History.Length < 1) ||
                (!f.IncludedIn(QueryType.Q12)) ||
                (
                    double.IsNaN(f.valueResearchRating) &&
                    double.IsNaN(f.totalBondSales) &&
                    double.IsNaN(f.todayNAV)
                ) ||
                (f.percentageChangeInNAV <= 0) ||
                (
                    (f.History.Length > 1) &&
                    ((f.History[0] == null) || (double.IsNaN(f.History[0].Nav)))
                ))
                return false;
            return true;
        }
    }
}