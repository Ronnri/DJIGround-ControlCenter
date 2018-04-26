using CsharpMySQLConnector;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlCenter
{
    public partial class Form1Query1 : Form
    {
        public Form1Query1()
        {
            InitializeComponent();
        }

        //目前仅支持通过桥梁编号字段查询数据
        private void button1_Click(object sender, EventArgs e)
        {
            String bridgeID = textBox1.Text;
            if(bridgeID.Length == 0)
            {
                textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = "";
                textBox6.Text = ""; textBox7.Text = ""; textBox8.Text = ""; textBox9.Text = "";
                textBox10.Text = ""; textBox11.Text = ""; textBox12.Text = ""; textBox13.Text = "";
                textBox14.Text = ""; textBox15.Text = ""; textBox16.Text = ""; textBox17.Text = "";
                textBox18.Text = ""; textBox19.Text = ""; textBox20.Text = ""; textBox21.Text = "";
                textBox22.Text = ""; textBox23.Text = ""; textBox24.Text = ""; textBox25.Text = "";
                textBox26.Text = ""; textBox27.Text = ""; textBox28.Text = ""; textBox29.Text = "";
                textBox30.Text = ""; textBox31.Text = ""; textBox32.Text = ""; textBox33.Text = "";
                textBox34.Text = ""; textBox35.Text = ""; textBox36.Text = ""; textBox37.Text = "";
                textBox38.Text = ""; textBox39.Text = ""; textBox40.Text = ""; textBox41.Text = "";
                textBox42.Text = ""; textBox43.Text = ""; textBox44.Text = ""; textBox45.Text = "";

                MessageBox.Show(this, "编号不允许为空！", "查询失败");
            }
            else
            {
                
                string cmd = @"
SELECT BasicInfor.*,VertexInfor.*
FROM BasicInfor, VertexInfor 
WHERE BasicInfor.bridgeID = '";
                cmd = cmd + bridgeID + "'AND VertexInfor.bridgeID = '" + bridgeID + "';";
                Debug.WriteLine(cmd);
                //初始化mysql - C# 连接
                MySqlConnection mysql = CsharpMySQL.GetMySqlConnection();
                mysql.Open();
                MySqlCommand mySqlCommand = CsharpMySQL.GetSqlCommand(cmd, mysql);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                int counter = 0;
                try
                {
                    
                    Boolean flag = reader.Read();
                    if(flag == false)
                    {
                        //没有顶点数据;
                        string cmd1 = "SELECT * FROM BasicInfor WHERE BasicInfor.bridgeID = '" + bridgeID + "';";
                        Debug.WriteLine(cmd1);
                        MySqlConnection mysql1 = CsharpMySQL.GetMySqlConnection();
                        mysql1.Open();
                        MySqlCommand mySqlCommand1 = CsharpMySQL.GetSqlCommand(cmd1, mysql1);
                        MySqlDataReader reader1 = mySqlCommand1.ExecuteReader();
                        try
                        {
                            Boolean flag1 = reader1.Read();
                            if (flag1 == false)
                            {
                                textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = "";
                                textBox6.Text = ""; textBox7.Text = ""; textBox8.Text = ""; textBox9.Text = "";
                                textBox10.Text = ""; textBox11.Text = ""; textBox12.Text = ""; textBox13.Text = "";
                                textBox14.Text = ""; textBox15.Text = ""; textBox16.Text = ""; textBox17.Text = "";
                                textBox18.Text = ""; textBox19.Text = ""; textBox20.Text = ""; textBox21.Text = "";
                                textBox22.Text = ""; textBox23.Text = ""; textBox24.Text = ""; textBox25.Text = "";
                                textBox26.Text = ""; textBox27.Text = ""; textBox28.Text = ""; textBox29.Text = "";
                                textBox30.Text = ""; textBox31.Text = ""; textBox32.Text = ""; textBox33.Text = "";
                                textBox34.Text = ""; textBox35.Text = ""; textBox36.Text = ""; textBox37.Text = "";
                                textBox38.Text = ""; textBox39.Text = ""; textBox40.Text = ""; textBox41.Text = "";
                                textBox42.Text = ""; textBox43.Text = ""; textBox44.Text = ""; textBox45.Text = "";
                                MessageBox.Show(this, "没有记录！", "查询失败");
                            }
                            while (flag1)
                            {
                                
                                if (reader1.HasRows)
                                {
                                    string[] textBoxShowStr = new string[5];
                                    for (int i = 0; i < 5; i++)
                                    {
                                        if (reader1[i].ToString() == "" || reader1[i].ToString() == "NULL" || reader1[i].ToString() == null)
                                        {
                                            textBoxShowStr[i] = "暂无!";
                                        }
                                        else
                                        {
                                            textBoxShowStr[i] = reader1.GetString(i);
                                        }
                                    }
                                    textBox1.Text = textBoxShowStr[0];
                                    textBox3.Text = textBoxShowStr[1];
                                    textBox4.Text = textBoxShowStr[2];
                                    textBox6.Text = textBoxShowStr[4];
                                    textBox5.Text = textBoxShowStr[3];

                                    textBox2.Text = ""; 
                                    textBox7.Text = ""; textBox8.Text = ""; textBox9.Text = "";
                                    textBox10.Text = ""; textBox11.Text = ""; textBox12.Text = ""; textBox13.Text = "";
                                    textBox14.Text = ""; textBox15.Text = ""; textBox16.Text = ""; textBox17.Text = "";
                                    textBox18.Text = ""; textBox19.Text = ""; textBox20.Text = ""; textBox21.Text = "";
                                    textBox22.Text = ""; textBox23.Text = ""; textBox24.Text = ""; textBox25.Text = "";
                                    textBox26.Text = ""; textBox27.Text = ""; textBox28.Text = ""; textBox29.Text = "";
                                    textBox30.Text = ""; textBox31.Text = ""; textBox32.Text = ""; textBox33.Text = "";
                                    textBox34.Text = ""; textBox35.Text = ""; textBox36.Text = ""; textBox37.Text = "";
                                    textBox38.Text = ""; textBox39.Text = ""; textBox40.Text = ""; textBox41.Text = "";
                                    textBox42.Text = ""; textBox43.Text = ""; textBox44.Text = ""; textBox45.Text = "";
                                }
                                flag1 = reader1.Read();
                            }
                        }
                        catch
                        {
                            MessageBox.Show(this, "查询失败！", "查询失败");
                        }
                        finally
                        {
                            reader1.Close();
                            mysql1.Close();
                        }          
                    }
                    while (flag)
                    {
                        
                        string[] textBoxShowStr = new string[11];
                        if (reader.HasRows)
                        {
                            
                            for(int i = 0; i < 11; i++)
                            {
                                if(reader[i].ToString() == "" || reader[i].ToString() == "NULL" || reader[i].ToString() == null)
                                {
                                    textBoxShowStr[i] = "暂无!";
                                }
                                else
                                {
                                    textBoxShowStr[i] = reader.GetString(i);
                                }
                            }
                           
                            switch (counter)
                            {
                                case 0: { textBox2.Text  = textBoxShowStr[6]; textBox7.Text  = textBoxShowStr[7]; textBox8.Text  = textBoxShowStr[8]; textBox9.Text  = textBoxShowStr[9];   textBox10.Text = textBoxShowStr[10]; break; }
                                case 1: { textBox15.Text = textBoxShowStr[6]; textBox14.Text = textBoxShowStr[7]; textBox13.Text = textBoxShowStr[8]; textBox12.Text = textBoxShowStr[9];   textBox11.Text = textBoxShowStr[10]; break; }
                                case 2: { textBox20.Text = textBoxShowStr[6]; textBox19.Text = textBoxShowStr[7]; textBox18.Text = textBoxShowStr[8]; textBox17.Text = textBoxShowStr[9];   textBox16.Text = textBoxShowStr[10]; break; }
                                case 3: { textBox25.Text = textBoxShowStr[6]; textBox24.Text = textBoxShowStr[7]; textBox23.Text = textBoxShowStr[8]; textBox22.Text = textBoxShowStr[9];   textBox21.Text = textBoxShowStr[10]; break; }
                                case 4: { textBox30.Text = textBoxShowStr[6]; textBox29.Text = textBoxShowStr[7]; textBox28.Text = textBoxShowStr[8]; textBox27.Text = textBoxShowStr[9];   textBox26.Text = textBoxShowStr[10]; break; }
                                case 5: { textBox35.Text = textBoxShowStr[6]; textBox34.Text = textBoxShowStr[7]; textBox33.Text = textBoxShowStr[8]; textBox32.Text = textBoxShowStr[9];   textBox31.Text = textBoxShowStr[10]; break; }
                                case 6: { textBox40.Text = textBoxShowStr[6]; textBox39.Text = textBoxShowStr[7]; textBox38.Text = textBoxShowStr[8]; textBox37.Text = textBoxShowStr[9];   textBox36.Text = textBoxShowStr[10]; break; }
                                case 7: { textBox45.Text = textBoxShowStr[6]; textBox44.Text = textBoxShowStr[7]; textBox43.Text = textBoxShowStr[8]; textBox43.Text = textBoxShowStr[9];   textBox42.Text = textBoxShowStr[10]; break; }

                            }
                            counter = counter + 1;
                            textBox1.Text = textBoxShowStr[0];
                            textBox3.Text = textBoxShowStr[1];
                            textBox4.Text = textBoxShowStr[2];
                            textBox6.Text = textBoxShowStr[4];
                            textBox5.Text = textBoxShowStr[3];

                        }

                        flag = reader.Read();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "查询失败！", "查询失败"); 
                }
                finally
                {
                    reader.Close();
                    mysql.Close();
                    counter = 0;
                }

            }
            
        }

        //添加数据
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show(this, "桥梁编号不允许为空!", "插入失败"); return;
            }
            if (textBox3.Text == "" || textBox3.Text == null)
            {
                MessageBox.Show(this, "桥梁名称不允许为空!", "插入失败"); return;
            }
            if (textBox4.Text == "" || textBox4.Text == null)
            {
                MessageBox.Show(this, "桥梁类型不允许为空!", "插入失败"); return;
            }

            MySqlConnection mysql = new MySqlConnection();
            try
            {
                //初始化mysql - C# 连接
                mysql = CsharpMySQL.GetMySqlConnection();
                mysql.Open();

                //获取数据
                string cmd = @"INSERT INTO `bridge`.`basicinfor` (`bridgeID`, `bridgeName`, `bridgeType`, `bridgeBrief`, `bridgeSpan`) VALUES ('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "');";
                

                if (textBox2.Text != "")
                {
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox7.Text + "','" + float.Parse(textBox8.Text) + "','" + float.Parse(textBox9.Text) + "','" + float.Parse(textBox10.Text) + "');";
                }
                
                if(textBox15.Text != "")
                {
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox15.Text + "','" + textBox14.Text + "','" + float.Parse(textBox13.Text) + "','" + float.Parse(textBox12.Text) + "','" + float.Parse(textBox11.Text) + "');";
                                                                                                                                                                                                                                                   
                }                                                                                                                                                                                                                                  
                                                                                                                                                                                                                                                   
                if(textBox20.Text != "")                                                                                                                                                                                                           
                {                                                                                                                                                                                                                                  
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox20.Text + "','" + textBox19.Text + "','" + float.Parse(textBox18.Text) + "','" + float.Parse(textBox17.Text) + "','" + float.Parse(textBox16.Text) + "');";
                                                                                                                                                                                                                                                    
                }                                                                                                                                                                                                                                   
                                                                                                                                                                                                                                                    
                if(textBox25.Text != "")                                                                                                                                                                                                            
                {                                                                                                                                                                                                                                   
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox25.Text + "','" + textBox24.Text + "','" + float.Parse(textBox23.Text) + "','" + float.Parse(textBox22.Text) + "','" + float.Parse(textBox21.Text) + "');";
                                                                                                                                                                                                                                                    
                }                                                                                                                                                                                                                                   
                                                                                                                                                                                                                                                    
                if (textBox30.Text != "")                                                                                                                                                                                                           
                {                                                                                                                                                                                                                                   
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox30.Text + "','" + textBox29.Text + "','" + float.Parse(textBox28.Text) + "','" + float.Parse(textBox27.Text) + "','" + float.Parse(textBox26.Text) + "');";
                }                                                                                                                                                                                                                                   
                                                                                                                                                                                                                                                    
                if (textBox35.Text != "")                                                                                                                                                                                                           
                {                                                                                                                                                                                                                                   
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox35.Text + "','" + textBox34.Text + "','" + float.Parse(textBox33.Text) + "','" + float.Parse(textBox32.Text) + "','" + float.Parse(textBox31.Text) + "');";
                                                                                                                                                                                                                                                    
                }                                                                                                                                                                                                                                   
                                                                                                                                                                                                                                                    
                if (textBox40.Text != "")                                                                                                                                                                                                           
                {                                                                                                                                                                                                                                   
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox40.Text + "','" + textBox39.Text + "','" + float.Parse(textBox38.Text) + "','" + float.Parse(textBox37.Text) + "','" + float.Parse(textBox36.Text) + "');";
                                                                                                                                                                                                                                                                                          
                }                                                                                                                                                                                                                                                                         
                                                                                                                                                                                                                                                                                          
                if (textBox45.Text != "")                                                                                                                                                                                                                                                 
                {                                                                                                                                                                                                                                                                         
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox45.Text + "','" + textBox44.Text + "','" + float.Parse(textBox43.Text) + "','" + float.Parse(textBox42.Text) + "','" + float.Parse(textBox41.Text) + "');";
                    
                }
                MySqlCommand mySqlCommand = CsharpMySQL.GetSqlCommand(cmd, mysql);
                CsharpMySQL.GetInsert(mySqlCommand);


            }
            catch(Exception)
            {
                MessageBox.Show(this, "添加失败", "添加失败");
            }
            finally
            {
                mysql.Close();
            }
        }

        //更新数据
        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection mysql = new MySqlConnection();
            try
            {
                //初始化mysql - C# 连接
                mysql = CsharpMySQL.GetMySqlConnection();
                mysql.Open();

                string cmd = "DELETE FROM BasicInfor WHERE bridgeID = '" + textBox1.Text + "';";
                cmd += "DELETE FROM VertexInfor WHERE bridgeID = '" + textBox1.Text + "';";
                //获取数据
                cmd += @"INSERT INTO `bridge`.`basicinfor` (`bridgeID`, `bridgeName`, `bridgeType`, `bridgeBrief`, `bridgeSpan`) VALUES ('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "');";

                if (textBox2.Text != "")
                {
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox7.Text + "','" + float.Parse(textBox8.Text) + "','" + float.Parse(textBox9.Text) + "','" + float.Parse(textBox10.Text) + "');";
                }

                if (textBox15.Text != "")
                {
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox15.Text + "','" + textBox14.Text + "','" + float.Parse(textBox13.Text) + "','" + float.Parse(textBox12.Text) + "','" + float.Parse(textBox11.Text) + "');";

                }

                if (textBox20.Text != "")
                {
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox20.Text + "','" + textBox19.Text + "','" + float.Parse(textBox18.Text) + "','" + float.Parse(textBox17.Text) + "','" + float.Parse(textBox16.Text) + "');";

                }

                if (textBox25.Text != "")
                {
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox25.Text + "','" + textBox24.Text + "','" + float.Parse(textBox23.Text) + "','" + float.Parse(textBox22.Text) + "','" + float.Parse(textBox21.Text) + "');";

                }

                if (textBox30.Text != "")
                {
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox30.Text + "','" + textBox29.Text + "','" + float.Parse(textBox28.Text) + "','" + float.Parse(textBox27.Text) + "','" + float.Parse(textBox26.Text) + "');";
                }

                if (textBox35.Text != "")
                {
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox35.Text + "','" + textBox34.Text + "','" + float.Parse(textBox33.Text) + "','" + float.Parse(textBox32.Text) + "','" + float.Parse(textBox31.Text) + "');";

                }

                if (textBox40.Text != "")
                {
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox40.Text + "','" + textBox39.Text + "','" + float.Parse(textBox38.Text) + "','" + float.Parse(textBox37.Text) + "','" + float.Parse(textBox36.Text) + "');";

                }

                if (textBox45.Text != "")
                {
                    cmd += @"INSERT INTO `bridge`.`vertexinfor` (`bridgeID`, `VertexID`, `VertexName`, `VertexLongitude`, `VertexLatitude`, `VertexAltitude`) VALUES('" + textBox1.Text + "','" + textBox45.Text + "','" + textBox44.Text + "','" + float.Parse(textBox43.Text) + "','" + float.Parse(textBox42.Text) + "','" + float.Parse(textBox41.Text) + "');";

                }
                MySqlCommand mySqlCommand = CsharpMySQL.GetSqlCommand(cmd, mysql);
                CsharpMySQL.GetUpdate(mySqlCommand);
            }
            catch
            {
                MessageBox.Show(this, "修改失败", "修改失败");
            }
            finally
            {
                mysql.Close();
            }
        }

        //删除数据
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show(this, "桥梁编号不允许为空!", "删除失败"); return;
            }
            MySqlConnection mysql = CsharpMySQL.GetMySqlConnection();
            mysql.Open();
            string cmd = "DELETE FROM BasicInfor WHERE bridgeID = '" + textBox1.Text + "';";
            cmd += "DELETE FROM VertexInfor WHERE bridgeID = '" + textBox1.Text + "';";
            MySqlCommand mySqlCommand = CsharpMySQL.GetSqlCommand(cmd, mysql);
            CsharpMySQL.GetDelete(mySqlCommand);
            mysql.Close();
        }
    }
}
