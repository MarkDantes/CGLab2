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

        Brush aBrush = new SolidBrush(Color.FromArgb(255, Color.Black));


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
				g = this.CreateGraphics();
				drawWuLine2(x0.GetValueOrDefault(), y0.GetValueOrDefault(), x1.GetValueOrDefault(), y1.GetValueOrDefault());
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
            Brush brush = new SolidBrush(Color.FromArgb((int)Math.Floor(255.0*c), Color.Black));
            g.FillRectangle(brush, x, y, 1, 1);
        }

		double ipart(double x)
		{
			return Math.Floor(x);
		}

		double round(double x)
		{
			return ipart(x + 0.5);
		}

        double fpart(double x)
        {
            return x - Math.Floor(x);
        }

        double rfpart(double x)
        {
            return 1 - fpart(x);
        }

		void drawWuLine2(double x0, double y0, double x1, double y1)
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

			var dx = x1 - x0;
			var dy = y1 - y0;
			var gradient = dy / dx;
			if (dx == 0.0)
			{
				gradient = 1.0;
			}
			var xend = round(x0);
			var yend = y0 + gradient * (xend - x0);
			var xgap = rfpart(x0 + 0.5);
			var xpxl1 = xend;
			var ypxl1 = ipart(yend);
			if (steep)
			{
				drawPixel(int.Parse(ypxl1.ToString()), int.Parse(xpxl1.ToString()), rfpart(yend) * xgap);
				drawPixel(int.Parse((ypxl1 + 1).ToString()), int.Parse(xpxl1.ToString()), rfpart(yend) * xgap);
			}
			else
			{
				drawPixel(int.Parse(xpxl1.ToString()), int.Parse(ypxl1.ToString()), rfpart(yend) * xgap);
				drawPixel(int.Parse(xpxl1.ToString()), int.Parse((ypxl1+1).ToString()), rfpart(yend) * xgap);
			}
			var intery = yend + gradient;
			xend = round(x1);
			yend = y1 + gradient * (xend - x1);
			xgap = rfpart(x0 + 0.5);
			var xpxl2 = xend;
			var ypxl2 = ipart(yend);
			if (steep)
			{
				drawPixel(int.Parse(ypxl2.ToString()), int.Parse(xpxl2.ToString()), rfpart(yend) * xgap);
				drawPixel(int.Parse((ypxl2 + 1).ToString()), int.Parse(xpxl2.ToString()), rfpart(yend) * xgap);
			}
			else
			{
				drawPixel(int.Parse(xpxl2.ToString()), int.Parse(ypxl2.ToString()), rfpart(yend) * xgap);
				drawPixel(int.Parse(xpxl2.ToString()), int.Parse((ypxl2 + 1).ToString()), rfpart(yend) * xgap);
			}

			if (steep)
			{
				for (int x = int.Parse((xpxl1 + 1).ToString()); x <= int.Parse((xpxl2 - 1).ToString()); x++)
				{
					drawPixel(int.Parse(ipart(intery).ToString()), int.Parse(x.ToString()), rfpart(intery));
					drawPixel(int.Parse(ipart(intery).ToString()) + 1, int.Parse(x.ToString()), rfpart(intery));
					intery += gradient;
				}
			}
			else
			{
				for (int x = int.Parse((xpxl1 + 1).ToString()); x <= int.Parse((xpxl2 - 1).ToString()); x++)
				{
					drawPixel(int.Parse(x.ToString()), int.Parse(ipart(intery).ToString()), rfpart(intery));
					drawPixel(int.Parse(x.ToString()), int.Parse(ipart(intery).ToString()) + 1, rfpart(intery));
					intery += gradient;
				}
			}
		}

        void drawWuLine(int x0,int y0,int x1,int y1)
        {

            if (x1 < x0)
            {
                (x0, x1) = (x1, x0);
                (y0, y1) = (y1, y0);
            }
            var dx = x1 - x0;
            var dy = y1 - y0;
            var gradient = dy / dx;

            // обработать начальную точку
            var xend = x0;
            double yend = y0 + gradient * (xend - x0);
            var xgap = 1 - fpart(x0 + 0.5);
            var xpxl0 = xend;  // будет использоваться в основном цикле
            var ypxl0 = int.Parse(Math.Floor(yend).ToString());
            drawPixel(xpxl0, ypxl0, (1 - fpart(yend)) * xgap);
            drawPixel(xpxl0, ypxl0 + 1, fpart(yend) * xgap);
            var intery = yend + gradient; // первое y-пересечение для цикла

   // обработать конечную точку
        xend= int.Parse(Math.Round(x1 + 0.5).ToString());
            yend = y1 + gradient * (xend - x1);
            xgap = fpart(x1 + 0.5);
            var xpxl1 = xend;  // будет использоваться в основном цикле
   var ypxl1= int.Parse(Math.Floor(yend).ToString());
            drawPixel(xpxl1, ypxl1, (1 - fpart(yend)) * xgap);
            drawPixel(xpxl1, ypxl1 + 1, fpart(yend) * xgap);

            // основной цикл
            for (int x = xpxl0 + 1; x <= (xpxl1 - 1); x++) 
            {
                drawPixel(x, int.Parse(Math.Floor(intery).ToString()), 1 - fpart(intery));
                drawPixel(x, int.Parse(Math.Floor(intery).ToString()) + 1, fpart(intery));
                intery = intery + gradient;
            }
        }
   
    
   
    
    
    

    


   
  
    }


}
