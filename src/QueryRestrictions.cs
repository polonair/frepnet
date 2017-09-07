using System;
using System.Collections.Generic;

namespace frep2
{
    internal class QueryRestrictions
    {
        private Dictionary<QueryType, QueryRestrictor> _InnerDictionary = new Dictionary<QueryType, QueryRestrictor>();

        public QueryRestrictor this[QueryType type]
        {
            get
            {
                if (this._InnerDictionary.ContainsKey(type)) return this._InnerDictionary[type];
                else return null;
            }
        }

        internal void Add(QueryType q, QueryRestrictor r)
        {
            if (this._InnerDictionary.ContainsKey(q)) this._InnerDictionary[q] = r;
            else this._InnerDictionary.Add(q, r);
        }
    }
}