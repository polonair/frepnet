using System;
using System.Collections.Generic;
using System.Text;

namespace frep2
{
    partial class Fund
    {
        public bool IsConsidered(Settings settings, QueryType type)
        {
            Fund f = this;

            if ((settings.Restrictions[type] != null) &&
                !settings.Restrictions[type].IsConsidered(this))
                return false;
            if ((double.IsNaN(this.valueResearchRating) &&
                double.IsNaN(this.totalBondSales) &&
                double.IsNaN(this.todayNAV)))
                return false;

            switch (type)
            {
                case QueryType.Q1:
                    if ((this.History.Length < 1) ||
                        (double.IsNaN(this.yesterdayNAV)) ||
                        (!this.IncludedIn(QueryType.Q1)) ||
                        (this.percentageChangeInNAV <= 0) ||
                        double.IsNaN(this.percentageChangeInNAV) ||
                        (
                            (this.History.Length > 0) &&
                            ((this.History[0] == null) || (double.IsNaN(this.History[0].Nav)))
                        ))
                        return false;
                    break;
                case QueryType.Q2:
                    if ((f.History.Length < 1) ||
                        (!f.IncludedIn(QueryType.Q2)) ||
                        (f.navChangeLongPercentage <= 0) ||
                        double.IsNaN(f.navChangeLongPercentage) ||
                        (
                            (f.History.Length > 1) &&
                            ((f.History[0] == null) || (double.IsNaN(f.History[0].Nav)))
                        ))
                        return false;
                    break;
                case QueryType.Q3:
                    if ((!f.IncludedIn(QueryType.Q3)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q4:
                    if ((!f.IncludedIn(QueryType.Q4)) ||
                        double.IsNaN(f.todayNAV) ||
                        (
                            double.IsNaN(f.valueResearchRating) &&
                            double.IsNaN(f.totalBondSales) &&
                            double.IsNaN(f.todayNAV)
                        ))
                        return false;
                    break;
                case QueryType.Q5:
                    if ((!f.IncludedIn(QueryType.Q5)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q6:
                    if ((!f.IncludedIn(QueryType.Q6)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q7:
                    if ((!f.IncludedIn(QueryType.Q7)) ||
                        (!f.IncludedIn(QueryType.Q3)) ||
                        (!f.IncludedIn(QueryType.Q4)) ||
                        (!f.IncludedIn(QueryType.Q5)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q8:
                    if ((!f.IncludedIn(QueryType.Q8)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q9:
                    if ((!f.IncludedIn(QueryType.Q9)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q10:
                    if ((!f.IncludedIn(QueryType.Q10)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q11:
                    if ((f.History.Length < 1) ||
                        (!f.IncludedIn(QueryType.Q11)) ||
                        (f.percentageChangeInNAV <= 0) ||
                        double.IsNaN(f.percentageChangeInNAV) ||
                        (
                            (f.History.Length > 0) &&
                            ((f.History[0] == null) || (double.IsNaN(f.History[0].Nav)))
                        ))
                        return false;
                    break;
                case QueryType.Q12:
                    if ((f.History.Length < 1) ||
                        (!f.IncludedIn(QueryType.Q12)) ||
                        (f.percentageChangeInNAV <= 0) ||
                        double.IsNaN(f.percentageChangeInNAV) ||
                        (
                            (f.History.Length > 1) &&
                            ((f.History[0] == null) || (double.IsNaN(f.History[0].Nav)))
                        ))
                        return false;
                    break;
                case QueryType.Q13:
                    if ((!f.IncludedIn(QueryType.Q13)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q14:
                    if ((!f.IncludedIn(QueryType.Q14)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q15:
                    if ((!f.IncludedIn(QueryType.Q15)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q16:
                    if ((!f.IncludedIn(QueryType.Q16)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q17:
                    if ((!f.IncludedIn(QueryType.Q17)) ||
                        (!f.IncludedIn(QueryType.Q13)) ||
                        (!f.IncludedIn(QueryType.Q14)) ||
                        (!f.IncludedIn(QueryType.Q15)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q18:
                    if ((!f.IncludedIn(QueryType.Q18)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q19:
                    if ((!f.IncludedIn(QueryType.Q19)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
                case QueryType.Q20:
                    if ((!f.IncludedIn(QueryType.Q20)) ||
                        double.IsNaN(f.todayNAV))
                        return false;
                    break;
            }
            return true;
        }
    }
}
