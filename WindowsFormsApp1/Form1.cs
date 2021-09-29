using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool draw = false;
        PointF pnt1, pnt2, pnt3;
        Color c1, c2, c3;
        
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                c1 = Color.Red;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                c1 = Color.Orange;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                c1 = Color.Yellow;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                c1 = Color.Green;
            }
            if (comboBox1.SelectedIndex == 4)
            {
                c1 = Color.Blue;
            }
            if (comboBox1.SelectedIndex == 5)
            {
                c1 = Color.Indigo;
            }
            if (comboBox1.SelectedIndex == 6)
            {
                c1 = Color.Violet;
            }
            if (c1 == c2 || c2 == c3 || c3 == c1 || c1.IsEmpty || c2.IsEmpty || c3.IsEmpty)
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                c2 = Color.Red;
            }
            if (comboBox2.SelectedIndex == 1)
            {
                c2 = Color.Orange;
            }
            if (comboBox2.SelectedIndex == 2)
            {
                c2 = Color.Yellow;
            }
            if (comboBox2.SelectedIndex == 3)
            {
                c2 = Color.Green;
            }
            if (comboBox2.SelectedIndex == 4)
            {
                c2 = Color.Blue;
            }
            if (comboBox2.SelectedIndex == 5)
            {
                c2 = Color.Indigo;
            }
            if (comboBox2.SelectedIndex == 6)
            {
                c2 = Color.Violet;
            }
            if (c1 == c2 || c2 == c3 || c3 == c1 || c1.IsEmpty || c2.IsEmpty || c3.IsEmpty)
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                c3 = Color.Red;
            }
            if (comboBox3.SelectedIndex == 1)
            {
                c3 = Color.Orange;
            }
            if (comboBox3.SelectedIndex == 2)
            {
                c3 = Color.Yellow;
            }
            if (comboBox3.SelectedIndex == 3)
            {
                c3 = Color.Green;
            }
            if (comboBox3.SelectedIndex == 4)
            {
                c3 = Color.Blue;
            }
            if (comboBox3.SelectedIndex == 5)
            {
                c3 = Color.Indigo;
            }
            if (comboBox3.SelectedIndex == 6)
            {
                c3 = Color.Violet;
            }
            //comboBox1.SelectedIndex == comboBox2.SelectedIndex || comboBox1.SelectedIndex == comboBox3.SelectedIndex || comboBox3.SelectedIndex == comboBox2.SelectedIndex
            if (c1 == c2 || c2 == c3 || c3 == c1 || c1.IsEmpty || c2.IsEmpty || c3.IsEmpty )
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }
        
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            draw = true;
            Random rnd = new Random();
            Bitmap bt = new Bitmap(pictureBox1.Width - 1, pictureBox1.Height - 1);
            Graphics g = Graphics.FromImage(bt);

             int x1 = rnd.Next(100, 300);
             int y1 = rnd.Next(100, 250);
         
             int y2 = rnd.Next(100, 250);
             

             pnt1 = new PointF(x1, y1-50);
             pnt2 = new PointF(x1+50, y2+50);
             pnt3 = new PointF(x1-50, y2+50);
            PointF[] points = { pnt1, pnt2, pnt3 };
            
            g.DrawPolygon(Pens.Black, points);

            pictureBox1.Image = bt;
            
        }

        

        public void Gradient()
        {
            
        }


    }
}
