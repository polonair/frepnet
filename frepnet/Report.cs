using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace frepnet
{
	class Report
	{
		private string _Template = null;
		private List<QueryResult> _Datas = new List<QueryResult>();
		private DataBase _DataBase;

		public string Template { get { return this._Template; } set { this._Template = value; } }

		public Report(DataBase dataBase)
		{
			this._DataBase = dataBase;
		}
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
						string fn = string.Format("Query_{0}_{1}_{2}_of_{3}.html",
												  (int)data.Type, data.Category, i + 1, pages);
						fn = this.EscapeFileName(fn);

						Dictionary<string, object> env = new Dictionary<string, object>();

						env.Add("fundCategory", data.Category);
						env.Add("FundCategory", data.Category);
						env.Add("mutualFunds", data.GetSlice(this._DataBase, i * 50, 50));
						env.Add("currentPage", i + 1);
						env.Add("currentPageNumber", i + 1);
						env.Add("nextPage", ((i + 1) >= pages) ? (0) : (i + 2));
						env.Add("nextPageNumber", ((i + 1) >= pages) ? (0) : (i + 2));
						env.Add("totalPages", pages);
						env.Add("date", DateTime.Now);
						env.Add("datestamp", string.Format("{0:dd MMMM yyyy}", DateTime.Now));
						env.Add("timestamp", string.Format("{0:hh.mm tt }", DateTime.Now));

						string content = template.Render(DotLiquid.Hash.FromDictionary(env));

						if (!Directory.Exists(settings.ExportDirectory)) Directory.CreateDirectory(settings.ExportDirectory);
						File.WriteAllText(string.Format("{0}/{1}", settings.ExportDirectory, fn), content);
						/*string dbg = "";
						foreach (Fund f in data.GetSlice(this._DataBase, i * 50, 50)) dbg += f.PrintDebug();
						File.WriteAllText(string.Format("{0}/{1}.txt", settings.ExportDirectory, fn), dbg);*/
					}
				}
			}
		}
		string EscapeFileName(string fn)
		{
			string result = "";
			foreach (char c in fn)
			{
				if (char.IsLetterOrDigit(c) || c == '_' || c == '.') result += c;
				else result += '_';
				while (result != result.Replace("__", "_")) result = result.Replace("__", "_");
			}
			return result;
		}

		internal void AddResult(QueryResult r) { this._Datas.Add(r); }
	}
}
