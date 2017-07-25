using System;
using System.Collections.Generic;
using System.Text;
using frep2.Queries;

namespace frep2
{
    abstract class Query
    {
        protected Settings _Settings;
        protected DataBase _DataBase;
        protected QueryType _QueryType;

        public static Query Create(Settings settings, DataBase database, QueryType queryType)
        {
            switch (queryType)
            {
                case QueryType.Q1: return new Query01(settings, database);
                case QueryType.Q2: return new Query02(settings, database);
                case QueryType.Q3: return new Query03(settings, database);
                case QueryType.Q4: return new Query04(settings, database);
                case QueryType.Q5: return new Query05(settings, database);
                case QueryType.Q6: return new Query06(settings, database);
                case QueryType.Q7: return new Query07(settings, database);
                case QueryType.Q8: return new Query08(settings, database);
                case QueryType.Q9: return new Query09(settings, database);
                case QueryType.Q10: return new Query10(settings, database);
                case QueryType.Q11: return new Query11(settings, database);
                case QueryType.Q12: return new Query12(settings, database);
                case QueryType.Q13: return new Query13(settings, database);
                case QueryType.Q14: return new Query14(settings, database);
                case QueryType.Q15: return new Query15(settings, database);
                case QueryType.Q16: return new Query16(settings, database);
                case QueryType.Q17: return new Query17(settings, database);
                case QueryType.Q18: return new Query18(settings, database);
                case QueryType.Q19: return new Query19(settings, database);
                case QueryType.Q20: return new Query20(settings, database);
                default: throw new ArgumentException();
            }
        }
        public Query(Settings settings, DataBase database)
        {
            this._Settings = settings;
            this._DataBase = database;
        }
        public abstract IEnumerable<QueryResult> GetResult();
    }
}
