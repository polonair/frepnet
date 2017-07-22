using System;
using System.Collections.Generic;
using System.IO;

namespace frep2
{
    internal partial class DataBase
    {
        private Settings _Settings;
        private Dictionary<string, Fund> _Data = new Dictionary<string, Fund>();
        private string _Category = null;
        private Stack<string> _CategoryStack = new Stack<string>();

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
                            if (!this._Data[f.Id].Categories.Contains(f.Categories[0]))
                                this._Data[f.Id].Categories.Add(f.Categories[0]);
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
                    try { date = UTIL.ParseOrdinalDateTime(d); }
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
            this.Calculate();
        }
        private void Calculate()
        {
            foreach (string id in this._Data.Keys)
            {
                this._Data[id].Calculate();
            }
        }
        internal IEnumerable<QueryResult> Query(QueryType queryType)
        {
            return frep2.Query.Create(this, queryType).GetResult();
        }
    }
}