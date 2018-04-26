using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlCenter
{
   
    public partial class FormMain : Form
    {
        Form1 f1 ;
        Form2 f2 ;
        Form3 f3 ;
        Form4 f4 ;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            f1 = new Form1();
            f2 = new Form2();
            f3 = new Form3();
            f4 = new Form4();
             this.pictureBox1.Load("../../welcome.gif");


    }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            this.Hide();
            f1.StartPosition = FormStartPosition.CenterScreen;

            f1.Show();  
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            f3.StartPosition = FormStartPosition.CenterScreen;
            f3.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            f4.StartPosition = FormStartPosition.CenterScreen;
            f4.Show(); 
        }
       
    }
}

