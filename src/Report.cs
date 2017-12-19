using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace frep2
{
    class Report
    {
        protected string _Template = null;
        private List<QueryResult> _Datas = new List<QueryResult>();
        protected DataBase _DataBase;

        public string Template { get { return this._Template; } set { this._Template = value; } }

        public Report(DataBase database) { this._DataBase = database; }
        internal void AddResult(QueryResult r) { this._Datas.Add(r); }
        public virtual void Save(Settings settings)
        {
            if (this._Template != null)
            {
                DotLiquid.Template.NamingConvention = new DotLiquid.NamingConventions.CSharpNamingConvention();
                DotLiquid.Template template = DotLiquid.Template.Parse(this._Template);

                foreach (QueryResult data in this._Datas)
                {
                    int length = data.Funds.Count;
                    //if (length < 1) continue;
                    int pages = Math.Min((length / 50) + 1, 3);

                    for (int i = 0; i < pages; i++)
                    {
                        string category = string.IsNullOrEmpty(data.Category) ? "All" : data.Category;
                        string replace = "";

                        switch (data.Type)
                        {
                            case QueryType.Q1:
                            case QueryType.Q11: replace = "ignore-this-old-top-price-drops-today"; break;
                            case QueryType.Q2:
                            case QueryType.Q12: replace = "best-price-drops-in-last-20days-on-amazon"; break;
                            case QueryType.Q3:
                            case QueryType.Q13: replace = "highest-selling-on-amazon"; break;
                            case QueryType.Q4:
                            case QueryType.Q14: replace = "fast-raisers-on-amazon"; break;
                            case QueryType.Q5:
                            case QueryType.Q15: replace = "highest-rated-on-amazon"; break;
                            case QueryType.Q6:
                            case QueryType.Q16: replace = "newest-launches-on-amazon"; break;
                            case QueryType.Q7:
                            case QueryType.Q17: replace = "overall-best-on-amazon"; break;
                            case QueryType.Q8:
                            case QueryType.Q18: replace = "costliest-on-amazon"; break;
                            case QueryType.Q9:
                            case QueryType.Q19: replace = "cheapest-on-amazon"; break;
                            case QueryType.Q10:
                            case QueryType.Q20: replace = "trending-new-launches-on-amazon"; break;
                            case QueryType.Q21:
                            case QueryType.Q22: replace = "real-price-drops-today-on-amazon"; break;
                        }
#if DEBUG
                        string fn = string.Format("{3}-{0}-{1}-page{2}.html", category, replace, i + 1, data.Type);
#else
                        string fn = string.Format("{0}-{1}-page{2}.html", category, replace, i + 1);
#endif

                        fn = this.EscapeFileName(fn);
                        VirtualFundList mfs = data.GetSlice(this._DataBase, i * 50, 50);
                        Dictionary<string, object> env = new Dictionary<string, object>
                        {
                            { "fundCategory", category },
                            { "FundCategory", category },
                            { "mutualFunds", mfs },
                            { "size", mfs.Count },
                            { "currentPage", i + 1 },
                            { "currentPageNumber", i + 1 },
                            { "nextPage", ((i + 1) >= pages) ? (1) : (i + 2) },
                            { "nextPageNumber", ((i + 1) >= pages) ? (1) : (i + 2) },
                            { "nextPageName", ((i + 1) >= pages) ? ("No more results") : ("See Next Page") },
                            { "totalPages", pages },
                            { "date", DateTime.Now },
                            { "datestamp", DateTime.Now },
                            { "timestamp", string.Format("{0:hh.mm tt }", DateTime.Now) }
                        };
                        DotLiquid.Hash h = DotLiquid.Hash.FromDictionary(env);
                        settings.ReferenceMap.Fill(category, h);
                        string content = template.Render(h);

                        if (!Directory.Exists(settings.ExportDirectory)) Directory.CreateDirectory(settings.ExportDirectory);
                        File.WriteAllText(string.Format("{0}/{1}", settings.ExportDirectory, fn), content);
                    }
                }
            }
        }
        protected string EscapeFileName(string fn)
        {
            string result = "";
            foreach (char c in fn)
            {
                if (char.IsLetterOrDigit(c) || c == '.') result += c;
                else result += '-';
                while (result != result.Replace("--", "-")) result = result.Replace("--", "-");
            }
            return result.ToLowerInvariant();
        }
    }
}
