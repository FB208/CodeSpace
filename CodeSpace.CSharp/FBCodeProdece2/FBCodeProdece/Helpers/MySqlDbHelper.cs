using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FBCodeProduce.Helpers
{
    public abstract class MySqlDbHelper
    {
        static JToken json = NewtonjsonHelper.ReadFile(Global.USER_SETTING_PATH);
        //数据库连接字符串(web.config来配置)，多数据库可使用DbHelperQLP来实现.
        //public static string connectionString = PubConstant.ConnectionString;
        public static string connectionString = json["DbServer"].Children().FirstOrDefault(m => m.Value<bool>("IsUse") == true).Value<string>("ConnectionString");
        public MySqlDbHelper()
        {
        }
        #region 库相关
        /// <summary>
        /// 获取数据库连接下所有数据库
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataBases()
        {
            DataTable dt = MySqlDbHelper.Query("show DATABASES").Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取数据库内所有表的信息
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public static DataTable GetTables(string databaseName)
        {
            DataTable dt = MySqlDbHelper
                .Query($"SELECT * FROM information_schema.`TABLES` WHERE TABLE_SCHEMA = '{databaseName}'").Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取表内所有列的详细信息
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataTable GetTableColums(string databaseName, string tablename)
        {
            DataTable dt = MySqlDbHelper
                .Query($@"
                        SELECT
                            TABLE_SCHEMA AS '库名',
                            TABLE_NAME AS '表名',
                            COLUMN_NAME AS '列名',
                            ORDINAL_POSITION AS '列的排列顺序',
                            COLUMN_DEFAULT AS '默认值',
                            IS_NULLABLE AS '是否为空',
                            DATA_TYPE AS '数据类型',
                            CHARACTER_MAXIMUM_LENGTH AS '字符最大长度',
                            NUMERIC_PRECISION AS '数值精度(最大位数)',
                            NUMERIC_SCALE AS '小数精度',
                            COLUMN_TYPE AS 列类型,
                            COLUMN_KEY 'KEY',
                            EXTRA AS '额外说明',
                            COLUMN_COMMENT AS '注释'
                        FROM
                            information_schema.`COLUMNS`
                        WHERE
                            TABLE_SCHEMA = '{databaseName}' and TABLE_NAME = '{tablename}'
                        ORDER BY
                            TABLE_NAME,
                            ORDINAL_POSITION;
                ").Tables[0];
            return dt;
        }
        #endregion
        #region 查询
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
        #endregion
        #region 执行语句

        #endregion
        #region 事务


        #endregion
    }
}
