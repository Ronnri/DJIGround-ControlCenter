using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using CsharpMySQLConnector;
using System.Diagnostics;

namespace ControlCenter
{
    public partial class Form1 : ControlCenter.FormMain
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGridView1.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridView1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGridView2.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridView2.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView2.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection mysql = new MySqlConnection();
            try
            {
                //初始化mysql - C# 连接
                mysql = CsharpMySQL.GetMySqlConnection();
                mysql.Open();

                //获取数据
                string cmd = @"
SELECT BasicInfor.*,VertexInfor.VertexID,VertexInfor.VertexName,VertexInfor.VertexLongitude,VertexInfor.VertexLatitude,VertexInfor.VertexAltitude 
FROM BasicInfor LEFT OUTER JOIN VertexInfor 
ON BasicInfor.bridgeID= VertexInfor.bridgeID
ORDER BY BasicInfor.bridgeID;";
                MySqlCommand mySqlCommand = CsharpMySQL.GetSqlCommand(cmd, mysql);
                MySqlDataAdapter adapter = new MySqlDataAdapter(mySqlCommand);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                /*dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[3].Width = 233;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 80;
                dataGridView1.Columns[6].Width = 80;
                dataGridView1.Columns[7].Width = 80;
                dataGridView1.Columns[8].Width = 80;*/
                dataGridView1.Columns[0].HeaderText = "桥梁编号"; 
                dataGridView1.Columns[1].HeaderText = "桥梁名称"; 
                dataGridView1.Columns[2].HeaderText = "桥梁类型"; 
                dataGridView1.Columns[3].HeaderText = "桥梁简介"; 
                dataGridView1.Columns[4].HeaderText = "桥梁跨度"; 
                dataGridView1.Columns[5].HeaderText = "顶点编号"; 
                dataGridView1.Columns[6].HeaderText = "顶点名称"; 
                dataGridView1.Columns[7].HeaderText = "顶点经度"; 
                dataGridView1.Columns[8].HeaderText = "顶点纬度";
                dataGridView1.Columns[9].HeaderText = "顶点海拔";
                dataGridView1.ReadOnly = true;

                cmd = @"
SELECT PartsInfor.bridgeID , PartsInfor.PartID , PartsInfor.PartName , PartsInfor.PartType , PartsVertexInfor.PartsVertexID, PartsVertexInfor.PartsVertexName , PartsVertexInfor.PartLongitude , PartsVertexInfor.PartLatitude , PartsVertexInfor.PartAltitude
FROM PartsInfor LEFT OUTER JOIN PartsVertexInfor
ON PartsInfor.PartID = PartsVertexInfor.PartID
AND PartsInfor.BridgeID = PartsVertexInfor.bridgeID
ORDER BY PartsInfor.bridgeID;";
                mySqlCommand = CsharpMySQL.GetSqlCommand(cmd, mysql);
                adapter = new MySqlDataAdapter(mySqlCommand);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch (Exception)
            {
                MessageBox.Show(this, "数据库连接失败！", "初始化失败");
                mysql.Close();
                
            }
            finally
            {
                //关闭连接            
                mysql.Close();
            }
            

            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("当前操作单元格内容:" + this.dataGridView1.CurrentCell.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1Query1 f1q1 = new Form1Query1();
            f1q1.StartPosition = FormStartPosition.CenterScreen;
            f1q1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1Query1 f1q1 = new Form1Query1(); f1q1.StartPosition = FormStartPosition.CenterScreen;
            f1q1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1_Load(sender,e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1Query1 f1q1 = new Form1Query1(); f1q1.StartPosition = FormStartPosition.CenterScreen;
            f1q1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1Query1 f1q1 = new Form1Query1(); f1q1.StartPosition = FormStartPosition.CenterScreen;
            f1q1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1Query2 f1q2 = new Form1Query2();
            f1q2.StartPosition = FormStartPosition.CenterScreen;
            f1q2.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1Query2 f1q2 = new Form1Query2();
            f1q2.StartPosition = FormStartPosition.CenterScreen;
            f1q2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1Query2 f1q2 = new Form1Query2();
            f1q2.StartPosition = FormStartPosition.CenterScreen;
            f1q2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1Query2 f1q2 = new Form1Query2();
            f1q2.StartPosition = FormStartPosition.CenterScreen;
            f1q2.Show();
        }
    }
}
