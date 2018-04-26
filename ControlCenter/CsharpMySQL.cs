using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CsharpMySQLConnector
{
    class CsharpMySQL
    {
        //Notes:建立mysql数据库链接
        public static MySqlConnection GetMySqlConnection()
        {
            String mysqlStr = "Database=bridge;Data Source=localhost;User Id=root;Password=123456;pooling=false;CharSet=utf8;port=3306";
            MySqlConnection mysql = new MySqlConnection(mysqlStr);
            return mysql;
        }
        //Notes:建立执行命令语句对象
        public static MySqlCommand GetSqlCommand(String sql, MySqlConnection mysql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
            return mySqlCommand;
        }

        //Notes:查询并且获取结果
        public static void GetResult(MySqlCommand mySqlCommand, MySqlConnection mysql)
        {
           // mysql.Open();
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("bridgeID:" + reader.GetString(0) + "\tbridgeType:" + reader.GetString(1) + "\tbridgeSpan:" + reader.GetString(2));
                        //Console.WriteLine("sno:" + reader.GetString(0) + "\tsname:" + reader.GetString(1) + "\tssex:" + reader.GetString(2) + "\tage:" + reader.GetString(3) + "\tsdept:" + reader.GetString(4));
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败！");
            }
            finally
            {
                reader.Close();
              //  mysql.Close();
            }
        }

        //Notes：添加数据
        public static void GetInsert(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("添加数据成功！", "添加成功");
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                MessageBox.Show("添加数据失败！", "添加失败");
                Console.WriteLine("添加数据失败！" + message);
            }

        }
        //Notes: 修改数据
        public static void GetUpdate(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("修改数据成功！", "修改成功");
            }
            catch (Exception ex)
            {

                String message = ex.Message;
                MessageBox.Show("修改数据失败！", "修改失败");
                Console.WriteLine("修改数据失败！" + message);
            }
        }

        //Notes: 删除数据
        public static void GetDelete(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("删除数据成功！", "删除成功");
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                MessageBox.Show("删除数据失败！", "删除失败");
                Console.WriteLine("删除数据失败！" + message);
            }
  
        }
    }


}
