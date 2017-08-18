using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace frep2
{
    class Report
    {
        private string _Template = null;
        private List<QueryResult> _Datas = new List<QueryResult>();
        private DataBase _DataBase;

        public string Template { get { return this._Template; } set { this._Template = value; } }

        public Report(DataBase database) { this._DataBase = database; }
        internal void AddResult(QueryResult r) { this._Datas.Add(r); }
        public void Save(Settings settings)
        {
            if (this._Template != null)
            {
                DotLiquid.Template.NamingConvention = new DotLiquid.NamingConventions.CSharpNamingConvention();
                DotLiquid.Template template = DotLiquid.Template.Parse(this._Template);

                foreach (QueryResult data in this._Datas)
                {
                    int length = data.Funds.Count;
                    if (length < 1) continue;
                    int pages = Math.Min((length / 50) + 1, 3);

                    for (int i = 0; i < pages; i++)
                    {
                        string category = string.IsNullOrEmpty(data.Category) ? "All" : data.Category;
                        string replace = "";

                        switch (data.Type)
                        {
                            case QueryType.Q1:
                            case QueryType.Q11: replace = "loss-makers-today-on-bse"; break;
                            case QueryType.Q2:
                            case QueryType.Q12: replace = "loss-makers-last-20-days-on-bse"; break;
                            case QueryType.Q3:
                            case QueryType.Q13: replace = "popular-funds-on-bse"; break;
                            case QueryType.Q4:
                            case QueryType.Q14: replace = "trending-funds-on-bse"; break;
                            case QueryType.Q5:
                            case QueryType.Q15: replace = "highest-rated-funds-on-bse"; break;
                            case QueryType.Q6:
                            case QueryType.Q16: replace = "newly-launched-funds-on-bse"; break;
                            case QueryType.Q7:
                            case QueryType.Q17: replace = "overall-best-funds-on-bse"; break;
                            case QueryType.Q8:
                            case QueryType.Q18: replace = "most-expensive-mutual-funds-on-bse"; break;
                            case QueryType.Q9:
                            case QueryType.Q19: replace = "cheapest-mutual-funds-on-bse"; break;
                            case QueryType.Q10:
                            case QueryType.Q20: replace = "trending-new-funds-on-bse"; break;
                        }
#if DEBUG
                        string fn = string.Format("{3}-{0}-{1}-page{2}.html", category, replace, i + 1, data.Type);
#else
                        string fn = string.Format("{0}-{1}-page{2}.html", category, replace, i + 1);
#endif

                        fn = this.EscapeFileName(fn);
                        //this._DataBase.Category = category;
                        Dictionary<string, object> env = new Dictionary<string, object>();

                        env.Add("fundCategory", category);
                        env.Add("FundCategory", category);
                        env.Add("mutualFunds", data.GetSlice(this._DataBase, i * 50, 50));
                        env.Add("currentPage", i + 1);
                        env.Add("currentPageNumber", i + 1);
                        env.Add("nextPage", ((i + 1) >= pages) ? (1) : (i + 2));
                        env.Add("nextPageNumber", ((i + 1) >= pages) ? (1) : (i + 2));
                        env.Add("totalPages", pages);
                        env.Add("date", DateTime.Now);
                        env.Add("datestamp", DateTime.Now);
                        env.Add("timestamp", string.Format("{0:hh.mm tt }", DateTime.Now));

                        string content = template.Render(DotLiquid.Hash.FromDictionary(env));

                        if (!Directory.Exists(settings.ExportDirectory)) Directory.CreateDirectory(settings.ExportDirectory);
                        File.WriteAllText(string.Format("{0}/{1}", settings.ExportDirectory, fn), content);
                    }
                }
            }
        }
        string EscapeFileName(string fn)
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
