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
                double x = this._DataBase.Data[a].highestRatingRank.Value;
                double y = this._DataBase.Data[b].highestRatingRank.Value;
                return x.CompareTo(y);
                /*
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
                */
            }));
            result.Add(new QueryResult(QueryType.Q15, null, keys));
            return result;
        }
    }
}
