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
        
        public Form1()
        {
            InitializeComponent();

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

        
    }
}
