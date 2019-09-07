using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FBCodeProduce.Tools
{
    public static class DataTableHelper
    {
        public static List<DataRow> ToList(this DataTable table)
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }
            return rows;
        }
        public static List<DataColumn> ToList(this DataColumnCollection columns)
        {
            List<DataColumn> result = new List<DataColumn>();
            foreach (DataColumn column in columns)
            {
                result.Add(column);
            }
            return result;
        }
        /// <summary>
        /// 获取某一列的所有值
        /// </summary>
        /// <typeparam name="T">列数据类型</typeparam>
        /// <param name="dtSource">数据表</param>
        /// <param name="filedName">列名</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dtSource, string filedName)
        {
            return (from r in dtSource.AsEnumerable() select r.Field<T>("ID")).ToList<T>();
        }


        /// <summary>  
        /// 填充对象列表：用DataTable填充实体类
        /// </summary>  
        public static List<T> FillModel<T>(this DataTable dt) where T : new()
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return new List<T>();
            }
            List<T> modelList = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                //T model = (T)Activator.CreateInstance(typeof(T));  
                T model = new T();
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    PropertyInfo propertyInfo = model.GetType().GetProperty(dr.Table.Columns[i].ColumnName);
                    if (propertyInfo != null && dr[i] != DBNull.Value)
                        propertyInfo.SetValue(model, dr[i], null);
                }

                modelList.Add(model);
            }
            return modelList;
        }
 
    }


}
