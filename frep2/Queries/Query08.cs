using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query08: Query
    {
        public Query08(DataBase database) : base(database) { }
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
                    double x = this._DataBase.Data[a].todayNAV;
                    double y = this._DataBase.Data[b].todayNAV;
                    //return x.CompareTo(y);
                    return y.CompareTo(x);
                }));
                result.Add(new QueryResult(QueryType.Q8, category, keys));
            }

            return result;
        }
        protected override bool IsConsidered(string id)
        {
            Fund f = this._DataBase.Data[id];

            if ((!f.IncludedIn(QueryType.Q8)) ||
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