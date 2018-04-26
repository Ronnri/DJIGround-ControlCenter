using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ControlCenter
{
    public partial class Form2 : ControlCenter.FormMain
    {
        
        public Form2()
        {
            InitializeComponent();
            
        }
        string fileName = null;
        FolderBrowserDialog path = new FolderBrowserDialog();

        private void button1_Click(object sender, EventArgs e)
        {
            //初始化一个OpenFileDialog类
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff|Windows Bitmap(*.bmp)|*.bmp|Windows Icon(*.ico)|*.ico|Graphics Interchange Format (*.gif)|(*.gif)|JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|Portable Network Graphics (*.png)|*.png|Tag Image File Format (*.tif)|*.tif;*.tiff";
            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                /*
                //声明允许的后缀名
                string[] str = new string[] { ".gif", ".jpge", ".jpg" };
                if (!((IList)str).Contains(extension))
                {
                    MessageBox.Show("仅能上传gif,jpge,jpg格式的图片！");
                }*/
                if (false) { }
                else
                {
                    //定义上传文件大小
                    const int FILEMAXSIZE = 1024*1024*10;
                    FileInfo fileInfo = new FileInfo(fileDialog.FileName);          
                    if (fileInfo.Length > FILEMAXSIZE)
                    {
                        MessageBox.Show("上传的图片不能大于10MB!");
                    }
                    else
                    {
                        //获取到正确文件
                        this.pictureBox2.Image = Image.FromFile(fileDialog.FileName, false);
                        this.fileName = fileDialog.FileName;
                    }
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(this.fileName == null)
            {
                MessageBox.Show("无飞行任务!");
            }
            else
            {
                FileInfo fileinfo = new FileInfo(this.fileName);
                string[] str = this.fileName.Split('.');
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                string time = currentTime.Year.ToString()                       + currentTime.Month.ToString(). PadLeft(2,'0') +
                                currentTime.Day.ToString().PadLeft(2,'0')      + currentTime.Hour.ToString().  PadLeft(2,'0') +
                                currentTime.Minute.ToString().PadLeft(2,'0')   + currentTime.Second.ToString().PadLeft(2,'0');
              
                if (path.SelectedPath == "")
                {
                    MessageBox.Show(this,"路径不合法!","保存错误");
                    textBox1_Click(sender, e);
                    
                }
                else
                {
                    //组合生成文件名
                    string filepath = path.SelectedPath + time + "." + str[1];

                    fileinfo.CopyTo(filepath);
                    str = filepath.Split('\\');
                    MessageBox.Show(this,"文件已成功保存至" + path.SelectedPath + "\n" + "文件名为:" + str[1],"保存成功");
                }      
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            path.ShowDialog();
            textBox1.Text = path.SelectedPath;
            
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            tooltip.Show("选择路径", textBox1); 
        }
    }
}
