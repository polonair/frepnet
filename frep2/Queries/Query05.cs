using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query05: Query
    {
        public Query05(Settings settings, DataBase database) : base(settings, database) { this._QueryType = QueryType.Q5; }
        public override IEnumerable<QueryResult> GetResult()
        {
            Dictionary<string, List<string>> byCategory = new Dictionary<string, List<string>>();
            foreach (string id in this._DataBase.Data.Keys)
            {
                if (this.IsConsidered(id))
                {
                    foreach (string category in this._DataBase.Data[id].Categories)
                    {
                        if (byCategory.ContainsKey(category)) byCategory[category].Add(id);
                        else byCategory.Add(category, new List<string>(new string[] { id }));
                    }
                }
            }
            List<QueryResult> result = new List<QueryResult>();

            foreach (string category in byCategory.Keys)
            {
                List<string> keys = new List<string>(byCategory[category]);
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
                    r= x.CompareTo(y);
                    return r;
                }));
                //int i = 1;
                //foreach (string key in keys) this._DataBase.Data[key].SetHighestRatingRank(i++);
                result.Add(new QueryResult(QueryType.Q5, category, keys));
            }

            return result;
        }
        protected override bool IsConsidered(string id)
        {
            Fund f = this._DataBase.Data[id];

            if (!base.IsConsidered(id)) return false;

            if ((!f.IncludedIn(QueryType.Q5)) ||
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
