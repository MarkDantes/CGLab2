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
        
        PointF a, b, c;
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
            pictureBox1.Refresh();
            Random rnd = new Random();
            // Bitmap bt = new Bitmap(pictureBox1.Width - 1, pictureBox1.Height - 1);
            //Graphics g = Graphics.FromImage(bt);

            int x1 = rnd.Next(100, 300);
            int y1 = rnd.Next(100, 250);

            int y2 = rnd.Next(100, 250);


            a = new PointF(x1, y1 - 50);
            b = new PointF(x1 + 50, y2 + 50);
            c = new PointF(x1 - 50, y2 + 50);

            PointF[] points = { a, b, c };

            //g.DrawPolygon(Pens.Black, points);

            Gradient();
            
            //pictureBox1.Image = bt;

        }

        //Находим описывающий прямоугольник
        public (PointF,PointF) R()
        {
            var minP = new PointF(Math.Min(a.X, Math.Min(b.X, c.X)), Math.Min(a.Y, Math.Min(b.Y, c.Y)));
            var maxP = new PointF(Math.Max(a.X, Math.Max(b.X, c.X)), Math.Max(a.Y, Math.Max(b.Y, c.Y)));
            return (minP, maxP);
        }
        //Проверяем находится ли точка внутри треугольника
        public bool InTriangle(float x, float y)
        {
            float aSide = (a.Y - b.Y) * x + (b.X - a.X) * y + (a.X * b.Y - b.X * a.Y);
            float bSide = (b.Y - c.Y) * x + (c.X - b.X) * y + (b.X * c.Y - c.X * b.Y);
            float cSide = (c.Y - a.Y) * x + (a.X - c.X) * y + (c.X * a.Y - a.X * c.Y);
            return (aSide >= 0 && bSide >= 0 && cSide >= 0) || (aSide < 0 && bSide < 0 && cSide < 0);
        }

       

        
        //Процедура окраски в градиентный цвет
        public void Gradient()
        {
            Bitmap image = new Bitmap(pictureBox1.Width - 1, pictureBox1.Height - 1);

            

                    pictureBox1.Image = image;
        }


    }
}
