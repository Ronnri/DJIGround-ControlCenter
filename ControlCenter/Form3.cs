using screenshot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ControlCenter
{
    public partial class Form3 : ControlCenter.FormMain
    {
        public Form3()
        {
            InitializeComponent();
        }

        private delegate void SetPos(int ipos, string vinfo);//代理

        private void SetTextMesssage(int ipos, string vinfo)
        {
            if (this.InvokeRequired)
            {
                SetPos setpos = new SetPos(SetTextMesssage);
                this.Invoke(setpos, new object[] { ipos, vinfo });
            }
            else
            {
                this.progressBar1.Value = Convert.ToInt32(ipos);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // if (runningFlag == true)
          //  {
                button4_Click(sender, e);

           // }
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
                        this.picFilename = fileDialog.FileName;
                        Form3_Load(sender, e);

                    }
                }
            }

        }
        string picFilename = "../../welcome.gif";

        BackgroundWorker bw = new BackgroundWorker();
        private void Form3_Load(object sender, EventArgs e)
        {

            this.label2.Text = "Stop";
            this.label2.ForeColor = Color.Red;
            SetTextMesssage(0, "");   
            cancelFlag = false;
            runningFlag = false;
            this.button3.Enabled = false;

            this.button1.Enabled = true;
            this.button3.Text = "暂停飞行任务";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            mre.Set();//继续
            this.label2.Text = "Running";
            this.label2.ForeColor = Color.Green;
            this.button1.Enabled = false;
            bw = new BackgroundWorker();
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.RunWorkerAsync();
            bw.WorkerSupportsCancellation = true;
            cancelFlag = false;
            runningFlag = true;
            this.button3.Enabled = true;

        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // 后台线程， 是在另一个线程上完成的
            for (int i = 0; i < 1000 ; i++)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                mre.WaitOne();
                System.Threading.Thread.Sleep(10);          
                SetTextMesssage(100 * i / 1000, i.ToString() + "\r\n");
                
            }
            e.Result = e.Argument + "工作线程完成";
        }
        
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {      
            if (cancelFlag == true)
            { SetTextMesssage(0, "");  }
            else
            {
                //后台线程完成，返回主线程
                this.button1.Enabled = true;
                this.label2.Text = "Finish!";
                this.label2.ForeColor = Color.Green;
                
            }
            runningFlag = false;
            this.button3.Enabled = false;
        }

        public static ManualResetEvent mre = new ManualResetEvent(true);
        private void button3_Click(object sender, EventArgs e)
        {
            string button3text = button3.Text;
     
                if (button3text == "暂停飞行任务")
                {
                    mre.Reset();//暂停
                    button3.Text = "继续飞行任务";
                    this.label2.Text = "Pause";
                    this.label2.ForeColor = Color.Purple;
                }
                else
                {
                    mre.Set();//继续
                    button3.Text = "暂停飞行任务";
                    this.label2.Text = "Running";
                    this.label2.ForeColor = Color.Green;
                }
              
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (runningFlag == true)
            {
                cancelFlag = true;
                bw.CancelAsync();
            }
                
            this.label2.Text = "Stop";
            SetTextMesssage(0, "");
            this.button1.Enabled = true;
            this.button3.Enabled = false;
         
            this.label2.ForeColor = Color.Red;
            this.button3.Text = "暂停飞行任务";
        }

        private bool cancelFlag = false;
        private bool runningFlag = false;


        //截图
        //选择picturebox2中一个区域，显示再pictbox3中

        shot st = new shot();
        private void button5_Click(object sender, EventArgs e)
        {
            string buttonText = button5.Text;
            if (buttonText == "打开截图框")
            {
                st = new shot();
                st.TopMost = true;
                st.BringToFront();
                st.Show();
                button5.Text = "截取";
            }
            else if(buttonText == "截取")
            {
                
                st.TopMost = true;
                st.BringToFront();
                st.button1_Click(sender,e);
                button5.Text = "打开截图框";
                pictureBox3.Image = st.pic;
                st.Close();
    
            }
            
          //  pictureBox3.Image = Image.FromFile(picFilename);

        }
    
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
          

        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
     
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void pictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {


        }
    

        //通过paint绘制
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
          
        }

    }
 
}
