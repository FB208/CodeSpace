using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FBCodeProduce.Tools
{
    public class DBTypeHelper
    {
        public static string GetDbType(Type type)
        {
            string result = "DbType.String";
            if (type.Equals(typeof(int)) || type.IsEnum)
                result = "DbType.Int32";
            else if (type.Equals(typeof(long)))
                result = "DbType.Int32";
            else if (type.Equals(typeof(double)) || type.Equals(typeof(Double)))
                result = "DbType.Decimal";
            else if (type.Equals(typeof(DateTime)))
                result = "DbType.DateTime";
            else if (type.Equals(typeof(bool)))
                result = "DbType.Boolean";
            else if (type.Equals(typeof(string)))
                result = "DbType.String";
            else if (type.Equals(typeof(decimal)))
                result = "DbType.Decimal";
            else if (type.Equals(typeof(byte[])))
                result = "DbType.Binary";
            else if (type.Equals(typeof(Guid)))
                result = "DbType.Guid";
            return result.ToString();
        }
    }
}
