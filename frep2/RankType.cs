using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frep2
{
    class RankType : DotLiquid.ILiquidizable
    {
        private int _Value;

        public static readonly RankType NA = new RankType(0);

        public int Value { get { return this._Value; } }
        
        private RankType(int value) { this._Value = value; }
        internal static RankType FromInt(int v) { return new RankType(v); }
        public override string ToString()
        {
            return (this._Value > 0) ? (this._Value.ToString()) : ("NA");
        }
        public object ToLiquid()
        {
            return this.ToString();
        }
    }
}
