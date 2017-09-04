using System;
using System.Collections.Generic;

namespace frep2
{
    internal partial class Fund : DotLiquid.Drop
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

        public string Id { get { return this._Id; } }
        public List<string> Categories { get { return this._Categories; } }
        public History[] History { get { return this._History; } }

        internal static Fund Create(DataBase dataBase, string header, string line, string separator)
        {
            Fund result = new Fund();
            result._DataBase = dataBase;
            result._Header = header;
            result._History = new History[] { };
            line = line.Replace('�', ' '); //NBSP -> SP
            string[] data = line.Split(new string[] { separator }, StringSplitOptions.None);
            result._Id = data[0].Trim();
            if (result._Id.Length < 1) return null;
            result._Name = data[1].Trim();
            if (result._Name.Length < 1) return null;
            if (data[2].Trim().Length < 1) return null;
            result._Categories = new List<string>(new string[] { data[2].Trim() });
            string[] splitted = data[3].Trim().Split("-".ToCharArray(), StringSplitOptions.None);
            if (splitted.Length == 3)
            {
                int y, m, d;
                if (int.TryParse(splitted[0], out d) &&
                    int.TryParse(splitted[1], out m) &&
                    int.TryParse(splitted[2], out y))
                {
                    result._LaunchDate = new DateTime(y, m, d);
                }
                else return null;
            }
            else return null;
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
        internal void Calculate()
        {
            this.calculateTotalBondSales();
            this.calculateTotalBondSales20();
            this.calculateValueResearchRating();
            this.calculateValueResearchRating20();
            this.calculateYesterdayNav();
            this.calculateTodayNav();
            this.calculatePerformanceScore();
            this.calculatePerformanceScore20();
            this.calculatePerformanceImprovementPercentage();
            this.calculatePreviousNav();
            this.calculateLowestNav();
            this.calculateLowestNavNew();
            this.calculateHighestNav();
            this.calculateChangeInNavLong();
            this.calculatePercentageChangeInNAVLong();
            this.calculateChangeInNav();
            this.calculateChangeInNavNew();
            this.calculatePercentageChangeInNAV();
            this.calculatePercentageChangeInNAVNew();
        }
        internal bool IncludedIn(QueryType queryType)
        {
            int qi = (int)queryType;
            return this._IncludeIn[qi - 1];
        }
    }
}