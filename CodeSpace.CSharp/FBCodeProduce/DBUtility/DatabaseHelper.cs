using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DBUtility;

namespace DLL.DBUtility
{
    public static class DatabaseHelper
    {
        /// <summary>
        /// 获取表内所有列的详细信息
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataTable GetTableColums(string tablename)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT d.name TableName, ");
            sql.Append(" a.colorder ShowIndex,a.name ColumnName, ");
            sql.Append(" (case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '1'else '0' end) IsIdentity, ");
            sql.Append(" (case when (SELECT count(*) FROM sysobjects ");
            sql.Append(" WHERE (name in (SELECT name FROM sysindexes ");
            sql.Append(" WHERE (id = a.id) AND (indid in ");
            sql.Append(" (SELECT indid FROM sysindexkeys ");
            sql.Append(" WHERE (id = a.id) AND (colid in ");
            sql.Append(" (SELECT colid FROM syscolumns WHERE (id = a.id) AND (name = a.name))))))) ");
            sql.Append(" AND (xtype = 'PK'))>0 then '1' else '0' end) IsPK,b.name Type,a.length DBSize, ");
            sql.Append(" COLUMNPROPERTY(a.id,a.name,'PRECISION') as Lenth, ");
            sql.Append(" isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0) as Precision,(case when a.isnullable=1 then '1'else '0' end) CanBeNull, ");
            sql.Append(" isnull(e.text,'') DefaultValue,isnull(g.[value], ' ') AS [Remark] ");
            sql.Append(" FROM  syscolumns a ");
            sql.Append(" left join systypes b on a.xtype=b.xusertype ");
            sql.Append(" inner join sysobjects d on a.id=d.id and d.xtype='U' and d.name<>'dtproperties' ");
            sql.Append(" left join syscomments e on a.cdefault=e.id ");
            sql.Append(" left join sys.extended_properties g on a.id=g.major_id AND a.colid=g.minor_id and g.name='MS_Description'");
            sql.Append(" left join sys.extended_properties f on d.id=f.class and f.minor_id=0 ");
            sql.Append(" where b.name is not null ");
            sql.Append(" and d.name = '" + tablename + "' ");
            sql.Append(" order by a.id,a.colorder ");

            DataTable dt = DbHelper.Query(sql.ToString()).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取数据库内所有表的信息
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public static DataTable GetTables(string databaseName)
        {
            DataTable dt = DbHelper
                .Query("USE " + databaseName + "; SELECT * FROM SYSOBJECTS WHERE TYPE='U' ORDER BY name").Tables[0];
            return dt;
        }
    }
}
