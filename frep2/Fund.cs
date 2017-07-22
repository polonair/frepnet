using System;
using System.Collections.Generic;

namespace frep2
{
    internal partial class Fund
    {
        private DataBase _DataBase;
        private string _Header;
        private History[] _History;
        private string _Id;
        private string _Name;
        private List<string> _Categories;
        private DateTime _LaunchDate;
        private string[] _Notes;
        private bool[] _IncludeIn;

        private double _TotalBondSales;

        public string Id { get { return this._Id; } }
        public List<string> Categories { get { return this._Categories; } }

        internal static Fund Create(DataBase dataBase, string header, string line, string separator)
        {
            Fund result = new Fund();
            result._DataBase = dataBase;
            result._Header = header;
            result._History = new History[] { };
            string[] data = line.Split(new string[] { separator }, StringSplitOptions.None);
            result._Id = data[0].Trim();
            if (result._Id.Length < 1) return null;
            result._Name = data[1].Trim();
            if (result._Name.Length < 1) return null;
            if (data[2].Trim().Length < 1) return null;
            result._Categories = new List<string>(new string[] { data[2].Trim() });
            try { result._LaunchDate = DateTime.Parse(data[3].Trim()); }
            catch { return null; }
            result._Notes = new string[7];
            for (int i = 0; i < 7; i++) result._Notes[i] = data[i + 4].Trim();
            result._IncludeIn = new bool[20];
            for (int i = 0; i < 20; i++) result._IncludeIn[i] = (data[i + 11].ToUpperInvariant().Trim() == "YES");
            return result;
        }
        internal void AddHistory(History history, int shift)
        {
            if (history != null)
            {
                int di = DateTime.Now.Subtract(history.Date).Days - shift;
                if ((this._History.Length-1) < di) Array.Resize<History>(ref this._History, di + 1);
                this._History[di] = history;
            }
        }
    }
}