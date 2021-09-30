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
       private Graphics g { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void onCheckedChanged(object sender, EventArgs e)
        {
            lineDrawerIsChecked = checkBoxLineDrawer.Checked;
        }

        private void onMouseClick(object sender, MouseEventArgs e)
        {
            setPosition(e.X, e.Y);
        }




        private int? x0, y0;
        private int? x1, y1;
        private bool lineDrawerIsChecked;

        Brush aBrush = (Brush)Brushes.Black;


        public void setPosition(int x, int y)
        {
            if (!lineDrawerIsChecked)
                return;

            if (x0 == null || y0 == null)
            {
                x0 = x;
                y0 = y;
                return;
            }
            if (x1 == null || y1 == null)
            {
                x1 = x;
                y1 = y;
                drawLine(x0.GetValueOrDefault(), y0.GetValueOrDefault(), x1.GetValueOrDefault(), y1.GetValueOrDefault());
                return;
            }
            x0 = x;
            y0 = y;
            x1 = null;
            y1 = null;
        }

        void drawLineUpper(int x0, int y0, int x1, int y1)
        {
            var deltax = x1 - x0;
            var deltay = y1 - y0;

            var dir = 1;

            if (deltax < 0)
            {
                dir = -1;
                deltax = -deltax;
            }

            var delta = (2 * deltax) - deltay;

            var x = x0;

            for (int y = y0; y <= y1; y++)
            {

                g.FillRectangle(aBrush, x, y, 1, 1);

                if (delta > 0)
                {
                    x += dir;
                    delta += (2 * (deltax - deltay));
                }
                else
                {
                    delta += 2 * deltax;
                }

            }
        }

        void drawLineLower(int x0, int y0, int x1, int y1)
        {
            var deltax = x1 - x0;
            var deltay = y1 - y0;

            var dir = 1;

            if (deltay < 0)
            {

                dir = -1;
                deltay = -deltay;

            }
            var delta = (2 * deltay) - deltax;

            var y = y0;

            for (int x = x0; x <= x1; x++)
            {
                g.FillRectangle(aBrush, x, y, 1, 1);

                if (delta > 0)
                {
                    y += dir;
                    delta += (2 * (deltay - deltax));
                }
                else
                {
                    delta += 2 * deltay;
                }
            }
        }

        ///Bresenham's line algorithm
        private void drawLine(int x0, int y0, int x1, int y1)
        {
            g = this.CreateGraphics();
            if (Math.Abs(y1 - y0) < Math.Abs(x1 - x0))
            {
                if (x0 > x1)
                    drawLineLower(x1, y1, x0, y0);
                else
                    drawLineLower(x0, y0, x1, y1);
            }
            else
            {
                if (y0 > y1)
                    drawLineUpper(x1, y1, x0, y0);
                else
                    drawLineUpper(x0, y0, x1, y1);
            }
        }
    }


}
