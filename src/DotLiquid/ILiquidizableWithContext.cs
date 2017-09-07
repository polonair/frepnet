using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotLiquid
{
    public interface ILiquidizableWithContext
    {
        object ToLiquid(Context ctx);
    }
}
