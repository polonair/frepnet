using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace frepnet
{
	class DataBase
	{
		private Settings _Settings;
		private string _Category = null;
		private Dictionary<string, Fund> _Data = new Dictionary<string, Fund>();
		private Dictionary<string, List<string>> _DataByCategory = new Dictionary<string, List<string>>();

		public Dictionary<string, Fund> Data { get { return this._Data; } }

		public DataBase(Settings settings)
		{
			this._Settings = settings;
			if (File.Exists(this._Settings.Standard))
			{
				string[] content = File.ReadAllLines(this._Settings.Standard);
				string header = content[0];
				int lines2load = content.Length;
				//int lines2load = 100;
				for (int i = 1; i < lines2load; i++)
				{
					Fund f = Fund.Create(this, header, content[i], this._Settings.Separator);
					if (f != null)
					{
						if (this._Data.ContainsKey(f.Id))
						{
							if (!this.Data[f.Id].Category.Contains(f.Category[0]))
								this.Data[f.Id].Category.Add(f.Category[0]);
						}
						else this._Data.Add(f.Id, f);
					}
				}
			}
			else throw new Exception(string.Format("File \"{0}\" doesn't exist", this._Settings.Standard));
			if (Directory.Exists(this._Settings.DateWiseDirectory))
			{
				string[] files = Directory.GetFiles(this._Settings.DateWiseDirectory, "*.csv");
				foreach (string file in files)
				{
					string d = file
						.Substring(file.IndexOf("Input_", StringComparison.InvariantCulture))
						.Replace("Input_", "")
						.Replace(".csv", "")
						.Replace("_", " ");
					DateTime date;
					try { date = DataBase.ParseOrdinalDateTime(d); }
					catch { continue; }

					if (DateTime.Now.Subtract(date).Days < 31)
					{
						string[] content = File.ReadAllLines(file);
						string header = content[0];
						for (int i = 1; i < content.Length; i++)
						{
							string fid = History.GetFundId(header, content[i], this._Settings.Separator);
							if (this._Data.ContainsKey(fid))
							{
								this._Data[fid].AddHistory(History.Create(date, header, content[i], this._Data[fid], this._Settings.Separator), this._Settings.Shift);
							}
						}
					}
				}
			}
			else throw new Exception(string.Format("Directory \"{0}\" doesn't exist", this._Settings.DateWiseDirectory));
			this._Ranking();
		}
		void _Ranking()
		{
            /*this.Sort_HighestRatingRank();
            this.Sort_PerformanceScoreRank();
            this.Sort_PerformanceImprovementPercentageRank();
			ths.Sort_OverallScoreRank();*/
		}

		public static DateTime ParseOrdinalDateTime(string dt)
		{
			dt = dt.Replace("0th", "0")
				.Replace("1st", "1")
				.Replace("2nd", "2")
				.Replace("3rd", "3")
				.Replace("11th", "11")
				.Replace("12th", "12")
				.Replace("13th", "13")
				.Replace("4th", "4")
				.Replace("5th", "5")
				.Replace("6th", "6")
				.Replace("7th", "7")
				.Replace("8th", "8")
				.Replace("9th", "9");

			try { return DateTime.Parse(dt, null, DateTimeStyles.None); }
			catch (Exception e) { throw new InvalidOperationException("Not a valid DateTime string", e); }
		}
		private Stack<string> _CategoryStack = new Stack<string>();
		internal void SetCategory(string category)
		{
			this._CategoryStack.Push(this._Category);
			this._Category = category;
		}
		internal void ResetCategory()
		{
			if (this._CategoryStack.Count > 0) this._Category = this._CategoryStack.Pop();
			else this._Category = null;
		}
		internal IEnumerable<QueryResult> Query(QueryType queryType)
		{
            int iqt = (int)queryType;
            if (iqt >=1 && iqt <=10) return this._QueryByCategory(queryType);
            if (iqt >=11 && iqt <=20) return this._QueryOverAll(queryType);
            throw new ArgumentOutOfRangeException();
		}
		private IEnumerable<QueryResult> _QueryByCategory(QueryType queryType)
		{
			Dictionary<string, List<string>> splitted = new Dictionary<string, List<string>>();
			foreach (string fid in this._Data.Keys)
			{
				if (this._Data[fid].IsConsidered(queryType))
				{
					foreach (string category in this._Data[fid].Category)
					{
						if (splitted.ContainsKey(category)) splitted[category].Add(fid);
						else splitted.Add(category, new List<string>(new string[] { fid }));
					}
					//if (splitted.ContainsKey(this._Data[fid].Category)) splitted[this._Data[fid].Category].Add(fid);
					//else splitted.Add(this._Data[fid].Category, new List<string>());
				}
			}
			List<QueryResult> result = new List<QueryResult>();
			foreach (string category in splitted.Keys)
			{
				this.SetCategory(category);
				List<string> keys = new List<string>(splitted[category]);
				keys.Sort((string a, string b) =>
				{
					return Fund.Comparise(this._Data[a], this._Data[b]);
				});
				result.Add(new QueryResult(queryType, category, keys));
				this.ResetCategory();
			}
			return result;
		}
		private IEnumerable<QueryResult> _QueryOverAll(QueryType queryType)
		{
			List<string> splitted = new List<string>();
			foreach (string fid in this._Data.Keys) if (this._Data[fid].IsConsidered(queryType)) splitted.Add(fid);
			List<QueryResult> result = new List<QueryResult>();
			splitted = new List<string>(splitted);
			splitted.Sort((string a, string b) =>
			{
				return Fund.Comparise(this._Data[a], this._Data[b]);
			});
			result.Add(new QueryResult(queryType, null, splitted));
			return result;
		}
        #region PerformanceScoreRank
        private Dictionary<string, List<string>> _PerformanceScoreRankByCategory;
		private List<string> _PerformanceScoreRankOverall;
		private bool _PerformanceScoreRank_Sorted = false;
		private Dictionary<string, Dictionary<string, int>> _PerformanceScoreRankByCategory_dict;
		private Dictionary<string, int> _PerformanceScoreRankOverall_dict;

		private void Sort_PerformanceScoreRank()
		{
			this._PerformanceScoreRankOverall = new List<string>(this._Data.Keys);
			this._PerformanceScoreRankOverall_dict = new Dictionary<string, int>();
			this._PerformanceScoreRankOverall.Sort((string x, string y) =>
			{
				if (x == y) return 0;
                return this._Data[y].PerformanceScore.CompareTo(this._Data[x].PerformanceScore);
                //return (this._Data[x].PerformanceScore <= this._Data[y].PerformanceScore) ? 1 : -1;
			});
			for (int i = 0; i < this._PerformanceScoreRankOverall.Count; i++)
			{
				this._PerformanceScoreRankOverall_dict.Add(this._PerformanceScoreRankOverall[i], i);
			}
			this._PerformanceScoreRankByCategory = new Dictionary<string, List<string>>();
			this._PerformanceScoreRankByCategory_dict = new Dictionary<string, Dictionary<string, int>>();
			foreach (string id in this._PerformanceScoreRankOverall)
			{
				foreach (string category in this._Data[id].Category)
				{
					if (this._PerformanceScoreRankByCategory.ContainsKey(category)) this._PerformanceScoreRankByCategory[category].Add(id);
					else
					{
						this._PerformanceScoreRankByCategory.Add(category, new List<string>());
						this._PerformanceScoreRankByCategory[category].Add(id);
					}
				}
				//string category = this._Data[id].Category;
				//if (this._PerformanceScoreRankByCategory.ContainsKey(category)) this._PerformanceScoreRankByCategory[category].Add(id);
				//else
				//{
				//	this._PerformanceScoreRankByCategory.Add(category, new List<string>());
				//	this._PerformanceScoreRankByCategory[category].Add(id);
				//}
			}
			foreach (string category in this._PerformanceScoreRankByCategory.Keys)
			{
				this._PerformanceScoreRankByCategory_dict.Add(category, new Dictionary<string, int>());
				for (int i = 0; i < this._PerformanceScoreRankByCategory[category].Count; i++)
				{
					try
					{
						this._PerformanceScoreRankByCategory_dict[category].Add(this._PerformanceScoreRankByCategory[category][i], i);
					}
					catch (Exception ex)
					{
						Fund f = this.Data[this._PerformanceScoreRankByCategory[category][i]];
						Console.WriteLine("here {1} \r\n\r\n{0}", ex, f.PrintDebug());
						Console.ReadLine();
					}
				}
			}
			this._PerformanceScoreRank_Sorted = true;
		}
		public int GetPerformanceScoreRankByCategory(string fid)
		{
			try
			{
				if (!this._PerformanceScoreRank_Sorted) this.Sort_PerformanceScoreRank();
				//return 1+this._PerformanceScoreRankByCategory[this._Data[fid].Category].IndexOf(fid);
				if (this.Data[fid].Category.Contains(this._Category))
				//if (Array.Exists<string>(this.Data[fid].Category, (string obj) => { return obj == this._Category; }))
				{
					return this._PerformanceScoreRankByCategory_dict[this._Category][fid] + 1;
				}
				else
				{
					throw new InvalidOperationException();
				}
				//return this._PerformanceScoreRankByCategory_dict[this._Data[fid].Category][fid] + 1;
			}
			catch (Exception e)
			{
				Console.Write(e.ToString());
				throw e;
			}
		}
		public int GetPerformanceScoreRankOverAll(string fid)
		{
			if (!this._PerformanceScoreRank_Sorted) this.Sort_PerformanceScoreRank();
			//return 1+this._PerformanceScoreRankOverall.IndexOf(fid);
			return this._PerformanceScoreRankOverall_dict[fid] + 1;
        }
        #endregion
        #region OverallScoreRank
        private Dictionary<string, List<string>> _OverallScoreRankByCategory;
        private List<string> _OverallScoreRankOverall;
		private bool _OverallScoreRank_Sorted = false;
		private Dictionary<string, Dictionary<string, int>> _OverallScoreRankByCategory_dict;
		private Dictionary<string, int> _OverallScoreRankOverall_dict;
		private void Sort_OverallScoreRank()
		{
			this._OverallScoreRankOverall = new List<string>(this._Data.Keys);
			this._OverallScoreRankOverall_dict = new Dictionary<string, int>();
			this._OverallScoreRankOverall.Sort((string x, string y) =>
				{
					int xpsr = this.GetPerformanceScoreRankOverAll(x);
					int ypsr = this.GetPerformanceScoreRankOverAll(y);
					int xpipr = this.GetPerformanceImprovementPercentageRankOverAll(x);
					int ypipr = this.GetPerformanceImprovementPercentageRankOverAll(y);
					int xhrr = this.GetHighestRatingRankOverAll(x);
					int yhrr = this.GetHighestRatingRankOverAll(y);
					int xo = xpsr + xpipr + xhrr;
					int yo = ypsr + ypipr + yhrr;
					if (x == y) return 0;
                    return xo.CompareTo(yo);
					//return (xo >= yo) ? 1 : -1;
				});
			for (int i = 0; i < this._OverallScoreRankOverall.Count; i++)
			{
				this._OverallScoreRankOverall_dict.Add(this._OverallScoreRankOverall[i], i);
			}
			this._OverallScoreRankByCategory = new Dictionary<string, List<string>>();
			this._OverallScoreRankByCategory_dict = new Dictionary<string, Dictionary<string, int>>();

			foreach (string id in this._OverallScoreRankOverall)
			{
				foreach (string category in this._Data[id].Category)
				{
					if (this._OverallScoreRankByCategory.ContainsKey(category)) this._OverallScoreRankByCategory [category].Add(id);
					else this._OverallScoreRankByCategory.Add(category, new List<string>(new string[] { id }));
				}
			}

			foreach (string category in this._OverallScoreRankByCategory.Keys)
			{
				this.SetCategory(category);
				this._OverallScoreRankByCategory[category].Sort((string x, string y) => 
				{
					int xpsr = this.GetPerformanceScoreRankByCategory(x);
					int ypsr = this.GetPerformanceScoreRankByCategory(y);
					int xpipr = this.GetPerformanceImprovementPercentageRankByCategory(x);
					int ypipr = this.GetPerformanceImprovementPercentageRankByCategory(y);
					int xhrr = this.GetHighestRatingRankByCategory(x);
					int yhrr = this.GetHighestRatingRankByCategory(y);
					int xo = xpsr + xpipr + xhrr;
					int yo = ypsr + ypipr + yhrr;
					if (x == y) return 0;
                    return xo.CompareTo(yo);
					//return (xo >= yo) ? 1 : -1;
				});
				this._OverallScoreRankByCategory_dict.Add(category, new Dictionary<string, int>());
				for (int i = 0; i< this._OverallScoreRankByCategory[category].Count; i++)
				{
					this._OverallScoreRankByCategory_dict[category].Add(this._OverallScoreRankByCategory[category][i], i);
				}
                this.ResetCategory();
			}
			this._OverallScoreRank_Sorted = true;
		}
        public int GetOverallScoreRankByCategory(string fid)
		{
			try{
	            if (!this._OverallScoreRank_Sorted) this.Sort_OverallScoreRank();
	            //return 1 + this._OverallScoreRankByCategory[this._Data[fid].Category].IndexOf(fid);
				if (this.Data[fid].Category.Contains(this._Category))
				//if (Array.Exists<string>(this.Data[fid].Category, (string obj) => { return obj == this._Category; }))
				{
					return this._OverallScoreRankByCategory_dict[this._Category][fid] + 1;
				}
				else
				{
					throw new InvalidOperationException();
				}
				//return this._OverallScoreRankByCategory_dict[this._Data[fid].Category][fid] + 1;
			}
			catch (Exception e)
			{
				Console.Write(e.ToString());
				throw e;
			}
		}
        public int GetOverallScoreRankOverAll(string fid)
		{
            if (!this._OverallScoreRank_Sorted) this.Sort_OverallScoreRank();
            //return 1 + this._OverallScoreRankOverall.IndexOf(fid);
			return this._OverallScoreRankOverall_dict[fid] + 1;
        }
        #endregion
        #region HighestRatingRank
        private Dictionary<string, List<string>> _HighestRatingRankByCategory;
        private List<string> _HighestRatingRankOverall;
		private bool _HighestRatingRank_Sorted = false;
		private Dictionary<string, Dictionary<string, int>> _HighestRatingRankByCategory_dict;
		private Dictionary<string, int> _HighestRatingRankOverall_dict;
        private void Sort_HighestRatingRank()
		{
           	this._HighestRatingRankOverall = new List<string>(this._Data.Keys);
            this._HighestRatingRankOverall_dict = new Dictionary<string, int>();
			this._HighestRatingRankOverall.Sort((string x, string y) =>
			{
				if (x == y) return 0;
                return this._Data[y].ValueResearchRating.CompareTo(this._Data[x].ValueResearchRating);
				//return (this._Data[x].ValueResearchRating <= this._Data[y].ValueResearchRating) ? 1 : -1;
			});
			for (int i = 0; i< this._HighestRatingRankOverall.Count; i++)
			{
               	this._HighestRatingRankOverall_dict.Add(this._HighestRatingRankOverall[i], i);
			}
            this._HighestRatingRankByCategory = new Dictionary<string, List<string>>();
            this._HighestRatingRankByCategory_dict = new Dictionary<string, Dictionary<string, int>>();
			foreach (string id in this._HighestRatingRankOverall)
			{
				foreach (string category in this._Data[id].Category)
				{
					if (this._HighestRatingRankByCategory.ContainsKey(category)) this._HighestRatingRankByCategory[category].Add(id);
					else
					{
						this._HighestRatingRankByCategory.Add(category, new List<string>());
						this._HighestRatingRankByCategory[category].Add(id);
					}
				}
			}
			foreach (string category in this._HighestRatingRankByCategory.Keys)
			{
               	this._HighestRatingRankByCategory_dict.Add(category, new Dictionary<string, int>());
				for (int i = 0; i < this._HighestRatingRankByCategory[category].Count; i++)
				{
					this._HighestRatingRankByCategory_dict[category].Add(this._HighestRatingRankByCategory[category][i], i);
				}
			}
			this._HighestRatingRank_Sorted = true;
		}
		public int GetHighestRatingRankByCategory(string fid)
		{
			if (!this._HighestRatingRank_Sorted) this.Sort_HighestRatingRank();
			//return 1 + this._HighestRatingRankByCategory[this._Data[fid].Category].IndexOf(fid);
			if (this.Data[fid].Category.Contains(this._Category))
			//if (Array.Exists<string>(this.Data[fid].Category, (string obj) => { return obj == this._Category; }))
			{
				return this._HighestRatingRankByCategory_dict[this._Category][fid] + 1;
			}
			else
			{
				throw new InvalidOperationException();
			}
			//return this._HighestRatingRankByCategory_dict[this._Data[fid].Category][fid] + 1;
        }
        public int GetHighestRatingRankOverAll(string fid)
        {
            if (!this._HighestRatingRank_Sorted) this.Sort_HighestRatingRank();
            //return 1 + this._HighestRatingRankOverall.IndexOf(fid);
			return this._HighestRatingRankOverall_dict[fid] + 1;
        }
        #endregion
        #region PerformanceImprovementPercentageRank
        private Dictionary<string, List<string>> _PerformanceImprovementPercentageRankByCategory;
        private List<string> _PerformanceImprovementPercentageRankOverall;
		private bool _PerformanceImprovementPercentageRank_Sorted = false;
		private Dictionary<string, Dictionary<string, int>> _PerformanceImprovementPercentageRankByCategory_dict;
		private Dictionary<string, int> _PerformanceImprovementPercentageRankOverall_dict;
        private void Sort_PerformanceImprovementPercentageRank()
		{
			this._PerformanceImprovementPercentageRankOverall = new List<string>(this._Data.Keys);
            this._PerformanceImprovementPercentageRankOverall_dict = new Dictionary<string, int>();
			this._PerformanceImprovementPercentageRankOverall.Sort((string x, string y) =>
			{
				if (x == y) return 0;
                return this._Data[y].PerformanceImprovementPercentage.CompareTo(this._Data[x].PerformanceImprovementPercentage);
				//return (this._Data[x].PerformanceImprovementPercentage <= this._Data[y].PerformanceImprovementPercentage) ? 1 : -1;
			});
			for (int i = 0; i< this._PerformanceImprovementPercentageRankOverall.Count; i++)
			{
                this._PerformanceImprovementPercentageRankOverall_dict.Add(this._PerformanceImprovementPercentageRankOverall[i], i);
			}
            this._PerformanceImprovementPercentageRankByCategory = new Dictionary<string, List<string>>();
            this._PerformanceImprovementPercentageRankByCategory_dict = new Dictionary<string, Dictionary<string, int>>();
			foreach (string id in this._PerformanceImprovementPercentageRankOverall)
			{
				foreach (string category in this._Data[id].Category)
				{
					if (this._PerformanceImprovementPercentageRankByCategory.ContainsKey(category)) this._PerformanceImprovementPercentageRankByCategory[category].Add(id);
					else
					{
						this._PerformanceImprovementPercentageRankByCategory.Add(category, new List<string>());
						this._PerformanceImprovementPercentageRankByCategory[category].Add(id);
					}
				}
			}
			foreach (string category in this._PerformanceImprovementPercentageRankByCategory.Keys)
			{
                this._PerformanceImprovementPercentageRankByCategory_dict.Add(category, new Dictionary<string, int>());
				for (int i = 0; i < this._PerformanceImprovementPercentageRankByCategory[category].Count; i++)
				{
                    this._PerformanceImprovementPercentageRankByCategory_dict[category].Add(this._PerformanceImprovementPercentageRankByCategory[category][i], i);
				}
			}
			this._PerformanceImprovementPercentageRank_Sorted = true;
		}
		public int GetPerformanceImprovementPercentageRankByCategory(string fid)
		{
			if (!this._PerformanceImprovementPercentageRank_Sorted) this.Sort_PerformanceImprovementPercentageRank();
			//return 1 + this._PerformanceImprovementPercentageRankByCategory[this._Data[fid].Category].IndexOf(fid);
			if (this.Data[fid].Category.Contains(this._Category))
			//if (Array.Exists<string>(this.Data[fid].Category, (string obj) => { return obj == this._Category; }))
			{
				return this._PerformanceImprovementPercentageRankByCategory_dict[this._Category][fid] + 1;
			}
			else
			{
				throw new InvalidOperationException();
			}
			//return this._PerformanceImprovementPercentageRankByCategory_dict[this._Data[fid].Category][fid] + 1;
        }
        public int GetPerformanceImprovementPercentageRankOverAll(string fid)
        {
            if (!this._PerformanceImprovementPercentageRank_Sorted) this.Sort_PerformanceImprovementPercentageRank();
            //return 1 + this._PerformanceImprovementPercentageRankOverall.IndexOf(fid);
			return this._PerformanceImprovementPercentageRankOverall_dict[fid] + 1;
        }
        #endregion
    }
}
