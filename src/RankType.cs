﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;

namespace frep2
{
    class RankType : DotLiquid.ILiquidizableWithContext
    {
        private Dictionary<string, int> _Values = new Dictionary<string, int>();

        public int this[string category]
        {
            get
            {
                if (this._Values.ContainsKey(category)) return this._Values[category];
                else return 0;
            }
            set
            {
                if (this._Values.ContainsKey(category)) this._Values[category] = value;
                else this._Values.Add(category, value);
            }
        }

        public RankType() { }
        public object ToLiquid(Context ctx)
        {
            if (ctx.Environments.Count > 0 && ctx.Environments[0].ContainsKey("fundCategory"))
            {
                string key = ctx.Environments[0]["fundCategory"].ToString();
                if (this._Values.ContainsKey(key)) return this._Values[key].ToString();
            }
            else
            {
                string key = string.Empty;
                foreach (Hash h in ctx.Scopes)
                {
                    if (h.ContainsKey("fundCategory"))
                    {
                        key = h["fundCategory"].ToString();
                        if (this._Values.ContainsKey(key))
                            return this._Values[key].ToString();
                    }
                }
            }
            return "NA";
        }
    }
}
