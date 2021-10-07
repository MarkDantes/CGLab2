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

        private void onMouseClick(object sender, MouseEventArgs e)
        {
            setPosition(e.X, e.Y);
        }




        private int? x0, y0;
        private int? x1, y1;
        private bool IsDisabled;
        private bool IsBresenham;
        private bool IsWu;


        Brush aBrush = new SolidBrush(Color.FromArgb(255, Color.Black));


        public void setPosition(int x, int y)
        {
            if (IsDisabled)
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
				g = this.CreateGraphics();
                if (IsWu)
                {
                    drawWuLine2(x0.GetValueOrDefault(), y0.GetValueOrDefault(), x1.GetValueOrDefault(), y1.GetValueOrDefault());
                } else if (IsBresenham)
                {
                    drawLine(x0.GetValueOrDefault(), y0.GetValueOrDefault(), x1.GetValueOrDefault(), y1.GetValueOrDefault());
                }
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

        void drawPixel(int x, int y, double c)
        {
            Brush brush = new SolidBrush(Color.FromArgb((int)c, Color.Black));
            g.FillRectangle(brush, x, y, 1, 1);
        }


		void drawWuLine2(int x0, int y0, int x1, int y1)
		{
			bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
			if (steep)
			{   
				(x0, y0) = (y0, x0);
				(x1, y1) = (y1, x1);
			}
			if (x0 > x1)
			{
				(x0, x1) = (x1, x0);
				(y0, y1) = (y1, y0);
			}

			double dx = x1 - x0;
			double dy = y1 - y0;
			double gradient = (double)((double)(dy) / (double)(dx));
            if (dx == 0.0)
			{
				gradient = 1;
			}

            int xpxl1 = x0;
            int xpxl2 = x1;
            double intery = y0;

            if (steep)
			{
				for (int x = int.Parse((xpxl1).ToString()); x <= int.Parse((xpxl2).ToString()); x++)
				{
					drawPixel(int.Parse(iPart(intery).ToString()), int.Parse(x.ToString()), rfPart(intery)*255);
					drawPixel(int.Parse(iPart(intery).ToString()) + 1, int.Parse(x.ToString()), fPart(intery)*255);
					intery += gradient;
				}
			}
			else
			{
				for (int x = int.Parse((xpxl1).ToString()); x <= int.Parse((xpxl2).ToString()); x++)
				{
					drawPixel(int.Parse(x.ToString()), int.Parse(iPart(intery).ToString()), rfPart(intery)*255);
					drawPixel(int.Parse(x.ToString()), int.Parse(iPart(intery).ToString()) + 1, fPart(intery)*255);
					intery += gradient;
				}
			}
		}

        class ColorPoint
        {
            int x;
            int y;
            int color;

            public ColorPoint(int x, int y, int color)
            {
                this.x = x;
                this.y = y;
                this.color = color;
            }
            public int get_x()
            {
                return x;
            }
            public int get_y()
            {
                return y;
            }
            public int get_color()
            {
                return color;
            }
        };

        int iPart(double d)
        {
            return (int)d;
        }

        int round(double d)
        {
            return (int)(d + 0.50000);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButtonDisabled_CheckedChanged(object sender, EventArgs e)
        {
            x0 = null;
            y0 = null;
            x1 = null;
            y1 = null;
            IsDisabled = true;
            IsBresenham = false;
            IsWu = false;
        }

        private void radioButtonBresenham_CheckedChanged(object sender, EventArgs e)
        {
            x0 = null;
            y0 = null;
            x1 = null;
            y1 = null;
            IsDisabled = false;
            IsBresenham = true;
            IsWu = false;
        }

        private void radioButtonWu_CheckedChanged(object sender, EventArgs e)
        {
            x0 = null;
            y0 = null;
            x1 = null;
            y1 = null;
            IsDisabled = false;
            IsBresenham = false;
            IsWu = true;
        }

        double fPart(double d)
        {
            return (double)(d - (int)(d));
        }

        double rfPart(double d)
        {
            return (double)(1.00000 - (double)(d - (int)(d)));
        }
  
    }


}
