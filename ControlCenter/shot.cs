using ControlCenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace screenshot
{
    public partial class shot : Form
    {
        //private Form3 f3obj;
        public shot()
        {
            InitializeComponent();
        }
        /*public shot(Form3 f3)
        {
            InitializeComponent();
            f3obj = f3; 
        }*/

        private void shot_Load(object sender, EventArgs e)
        {
            BackColor = Color.Gray;
            panel1.BackColor = Color.Gray;
            TransparencyKey = Color.Gray;
            shot_resize(null, null);
            button1.Visible = false;
        }

        private void shot_resize(object sender, EventArgs e)
        {
            panel1.Left = 0;
            panel1.Width = this.ClientRectangle.Width;
            panel1.Height = this.ClientRectangle.Height - panel1.Top;
        }

        public Bitmap pic { get; set; }
        public void button1_Click(object sender, EventArgs e)
        {
            Point r = new Point();
            Bitmap image = new Bitmap(panel1.Width, panel1.Height);
            Graphics imgGh = Graphics.FromImage(image);
            r.X = panel1.ClientRectangle.X;
            r.Y = panel1.ClientRectangle.Y;
            r = panel1.PointToScreen(r);
            imgGh.CopyFromScreen(r, new Point(0, 0), new Size(panel1.Width, panel1.Height));
            this.pic = image;


            /*
            SaveFileDialog f = new SaveFileDialog();
            f.InitialDirectory = ".";
            f.Filter = "jpeg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp";
            f.FileName = (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))).TotalMilliseconds.ToString() + ".jpg";
            if (f.ShowDialog(this) == DialogResult.OK)
                image.Save(f.FileName);*/
        }
    }
}
