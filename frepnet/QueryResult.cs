using System;
using System.Collections.Generic;
using System.Text;

namespace frepnet
{
	class QueryResult
	{
		private List<string> _Funds;
		private QueryType _Type;
		private string _Category;

		public List<string> Funds { get { return this._Funds; } }
		public QueryType Type { get { return this._Type; } }
		public string Category { get { return this._Category; } }

		public QueryResult(QueryType type, string category, IEnumerable<string> keys)
		{
			this._Type = type;
			this._Category = category;
			this._Funds = new List<string>(keys);
		}
		public VirtualFundList GetSlice(DataBase db, int from, int count)
		{
			return new VirtualFundList(db, this._Funds.GetRange(from, Math.Min(this._Funds.Count-from, count)));
		}
	}
}
