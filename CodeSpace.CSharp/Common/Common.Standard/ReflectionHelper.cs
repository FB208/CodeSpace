using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Common.Standard
{
    public class ReflectionHelper
    {
        public static bool CopyValue<TOrigin,TTarget>(TOrigin origin,TTarget target)
        {
            try
            {
                IEnumerable<PropertyInfo> originPis = origin.GetType().GetProperties().OrderBy(m=>m.Name);
                IEnumerable<PropertyInfo> targetPis = target.GetType().GetProperties().OrderBy(m => m.Name);
                foreach (var originPi in originPis)
                {
                    IEnumerable<PropertyInfo> sameTargetPis= targetPis.Where(m => m.Name == originPi.Name && m.PropertyType == originPi.PropertyType);
                    foreach (var sameTarget in sameTargetPis)
                    {
                        sameTarget.SetValue(target, originPi.GetValue(origin));
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }
    }
}
