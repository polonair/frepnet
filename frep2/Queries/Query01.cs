using System;
using System.Collections.Generic;
using System.Text;

namespace frep2.Queries
{
    class Query01 : Query
    {
        public Query01(DataBase database) : base(database) { }
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
                keys.Sort(new Comparison<string>(delegate(string a, string b)
                {
                    double x = this._DataBase.Data[a].percentageChangeInNAV;
                    double y = this._DataBase.Data[b].percentageChangeInNAV;
                    //return x.CompareTo(y);
                    return y.CompareTo(x);
                }));
                result.Add(new QueryResult(QueryType.Q1, category, keys));
            }

            return result;
        }
        protected override bool IsConsidered(string id)
        {
            Fund f = this._DataBase.Data[id];

            if ((f.History.Length < 1) ||
                (!f.IncludedIn(QueryType.Q1)) ||
                (
                    double.IsNaN(f.valueResearchRating) && 
                    double.IsNaN(f.totalBondSales) && 
                    double.IsNaN(f.todayNAV)
                ) ||
                (f.percentageChangeInNAV <= 0) ||
                (
                    (f.History.Length > 0) && 
                    ((f.History[0] == null) || (double.IsNaN(f.History[0].Nav)))
                )) 
                return false;
            return true;
        }
    }
}
