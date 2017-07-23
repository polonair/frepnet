using System;
using System.Collections.Generic;
using System.Text;
using frep2.Queries;

namespace frep2
{
    abstract class Query
    {
        protected DataBase _DataBase;

        public static Query Create(DataBase database, QueryType queryType)
        {
            switch (queryType)
            {
                case QueryType.Q1: return new Query01(database);
                case QueryType.Q2: return new Query02(database);
                case QueryType.Q3: return new Query03(database);
                case QueryType.Q4: return new Query04(database);
                case QueryType.Q5: return new Query05(database);
                case QueryType.Q6: return new Query06(database);
                case QueryType.Q7: return new Query07(database);
                case QueryType.Q8: return new Query08(database);
                case QueryType.Q9: return new Query09(database);
                case QueryType.Q10: return new Query10(database);
                case QueryType.Q11: return new Query11(database);
                case QueryType.Q12: return new Query12(database);
                case QueryType.Q13: return new Query13(database);
                case QueryType.Q14: return new Query14(database);
                case QueryType.Q15: return new Query15(database);
                case QueryType.Q16: return new Query16(database);
                case QueryType.Q17: return new Query17(database);
                case QueryType.Q18: return new Query18(database);
                case QueryType.Q19: return new Query19(database);
                case QueryType.Q20: return new Query20(database);
                default: throw new ArgumentException();
            }
        }
        public Query(DataBase database)
        {
            this._DataBase = database;
        }
        public abstract IEnumerable<QueryResult> GetResult();
        protected virtual bool IsConsidered(string id) { return false; }
        protected void CalculateRanks(List<string> keys)
        {
            int i;
            keys.Sort(new Comparison<string>(delegate (string a, string b)
            {
                double x = this._DataBase.Data[a].performanceScore;
                double y = this._DataBase.Data[b].performanceScore;
                //return x.CompareTo(y);
                return y.CompareTo(x);
            }));
            i = 1;
            foreach (string key in keys) this._DataBase.Data[key].SetPerformanceScoreRank(i++);
            //--
            keys.Sort(new Comparison<string>(delegate (string a, string b)
            {
                double x = this._DataBase.Data[a].performanceImprovementPercentage;
                double y = this._DataBase.Data[b].performanceImprovementPercentage;
                //return x.CompareTo(y);
                return y.CompareTo(x);
            }));
            i = 1;
            foreach (string key in keys) this._DataBase.Data[key].SetPerformanceImprovementPercentageRank(i++);
            //--
            keys.Sort(new Comparison<string>(delegate (string a, string b)
            {
                double x = this._DataBase.Data[a].valueResearchRating;
                double y = this._DataBase.Data[b].valueResearchRating;
                //return x.CompareTo(y);
                return y.CompareTo(x);
            }));
            i = 1;
            foreach (string key in keys) this._DataBase.Data[key].SetHighestRatingRank(i++);
            //--
            foreach (string key in keys)
                this._DataBase.Data[key].SetOverallScore(
                    this._DataBase.Data[key].performanceScoreRank +
                    this._DataBase.Data[key].performanceImprovementPercentageRank +
                    this._DataBase.Data[key].highestRatingRank
                    );
            //==
            keys.Sort(new Comparison<string>(delegate (string a, string b)
            {
                double x = this._DataBase.Data[a].overallScore;
                double y = this._DataBase.Data[b].overallScore;
                return x.CompareTo(y);
                //return y.CompareTo(x);
            }));
            i = 1;
            foreach (string key in keys) this._DataBase.Data[key].SetOverallScoreRank(i++);
        }
    }
}
