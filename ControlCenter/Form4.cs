using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ControlCenter
{
    public partial class Form4 : ControlCenter.FormMain
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff|Windows Bitmap(*.bmp)|*.bmp|Windows Icon(*.ico)|*.ico|Graphics Interchange Format (*.gif)|(*.gif)|JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|Portable Network Graphics (*.png)|*.png|Tag Image File Format (*.tif)|*.tif;*.tiff";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (false)
                {

                }
                else
                {
                    //定义上传文件大小
                    const int FILEMAXSIZE = 1024 * 1024 * 10;
                    FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                    if (fileInfo.Length > FILEMAXSIZE)
                    {
                        MessageBox.Show("上传的图片不能大于10MB!");
                    }
                    else
                    {
                        //获取到正确文件
                        this.pictureBox2.Image = Image.FromFile(fileDialog.FileName, false);
                        this.pictureBox3.Image = Image.FromFile(fileDialog.FileName, false);
                        this.pictureBox4.Image = Image.FromFile(fileDialog.FileName, false);
                    }
                }
            }
        }

        FolderBrowserDialog path = new FolderBrowserDialog();
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
