using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Filter
{
    public class ActionAttribute: ActionBaseAttribute
    {
        public override void Before(string method, object[] parameters)
        {
            Trace.WriteLine($"action before method:{method} | parameters:{parameters}");
        }

        public override object After(string method, object result)
        {
            Trace.WriteLine($"action aftre method:{method} | result:{result}");
            return base.After(method, result);
        }
    }
}
