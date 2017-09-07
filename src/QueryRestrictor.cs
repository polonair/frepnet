using System;
using System.Collections.Generic;
using System.Globalization;

namespace frep2
{
    internal class QueryRestrictor
    {
        List<double> _V = new List<double>();
        List<double> _T = new List<double>();
        List<double> _N = new List<double>();

        internal static QueryRestrictor Parse(string v)
        {
            QueryRestrictor result = new QueryRestrictor();

            string[] parts = v.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach(string part in parts)
            {
                double value;
                if (part.Trim().StartsWith("v"))
                {
                    if (double.TryParse(part.Substring(1), NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                        result._V.Add(value);
                }
                if (part.Trim().StartsWith("t"))
                {
                    if (double.TryParse(part.Substring(1), NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                        result._T.Add(value);
                }
                if (part.Trim().StartsWith("n"))
                {
                    if (double.TryParse(part.Substring(1), NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                        result._N.Add(value);
                }
            }
            return result;
        }
        internal bool IsConsidered(Fund fund)
        {
            foreach (double v in this._V)
            {
                if (fund.valueResearchRating < v)
                    return false;
            }
            foreach (double t in this._T)
            {
                if (fund.totalBondSales < t)
                    return false;
            }
            foreach (double n in this._N)
            {
                if (fund.todayNAV < n)
                    return false;
            }
            return true;
        }
    }
}