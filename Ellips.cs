using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_Neiron_Net
{
    public class Ellips
    {
        private double dx, dy;   // коэфициенты движения
        private double x, y;    // координаты текущей сферы
        private const int thickness = 2;    // толщена границ отрисовываемых предметов
        private const int Radius = 15;      // радиус окружности
        private Random r;       // генератор смены движения
        private int GraSizeH = 500, GraSizeW = 1100;    // начальные границы области движения
        private Color col;      // цвет зарисовки фона окружности

        // начальное положение и мектор движения
        public Ellips(double a, double b, double c, double d, Color cl)
        {
            r = new Random();

            x = a;
            y = b;
            dx = c;
            dy = d;
            col = new Color();
            col = cl;
        }

        // получение цвета зарисовки
        public Color GetColor()
        {
            return col;
        }

        // получение толщины границы
        public int GetThicnkness()
        {
            return thickness;
        }

        public int GetRadius()
        {
            return Radius;
        }

        // изменения движения
        protected void ChangVector(ref double a)
        {
            a = (r.Next(-10, 10) / 3);
        }

        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }

        public void Draw(PaintEventArgs e, int a, int b)
        {
            GraSizeW = a;
            GraSizeH = b;
            dx += r.Next(-10, 10) / 100;
            dy += r.Next(-10, 10) / 100;

            //++++++++++++ при достежении границы области++++++++++++++++++
            if (dx == 0) ChangVector(ref dx);
            if (dy == 0) ChangVector(ref dy);

            if (x < 0)
            {
                dx = Math.Abs(dx);
            }

            if (x + Radius * 2 > GraSizeW)
            {
                dx = -Math.Abs(dx);
            }

            if (y < 0)
            {
                dy = Math.Abs(dy);
            }
            if (y + Radius * 2 > GraSizeH)
            {
                dy = -Math.Abs(dy);
            }

            // определяем новые координаты
            x += dx;
            y += dy;
        }
    }
}