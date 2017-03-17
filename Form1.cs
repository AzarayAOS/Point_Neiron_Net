using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_Neiron_Net
{
    public partial class Form1 : Form
    {
        public Ellips[] El;
        private const int n = 10; // количество шариков на простарнстве каждого цвета
        private Random r;       // генератор начального положения
        private int GrafPointW = 1100, GrafPointH = 500; // ширина и высота области рисования в пикселях

        public Form1()
        {
            InitializeComponent();

            r = new Random();
            El = new Ellips[n * 3];

            GrafPointH = pictureBox1.Height;
            GrafPointW = pictureBox1.Width;

            Parallel.For(0, n, i => { El[i] = new Ellips(StartX(), StartY(), ChangVector(), ChangVector(), Color.Red); });
            Parallel.For(n, n * 2, i => { El[i] = new Ellips(StartX(), StartY(), ChangVector(), ChangVector(), Color.Orange); });
            Parallel.For(n * 2, n * 3, i => { El[i] = new Ellips(StartX(), StartY(), ChangVector(), ChangVector(), Color.Green); });
        }

        // задание движения
        protected double ChangVector()
        {
            return (r.Next(-10, 10) / 3);
        }

        // для определения начальной координаты круга по Х
        public double StartX()
        {
            return r.Next(100, GrafPointW);
        }

        // для определения начальной координаты по У
        public double StartY()
        {
            return r.Next(50, GrafPointH);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            // поскольку объекты никак не зависят друг от друга, то их следующее положение просчитываем паралельно

            Parallel.For(0, n * 3, i =>
                    { El[i].Draw(e, GrafPointW, GrafPointH); });

            for (var i = 0; i < n * 3; i++)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Black), new Rectangle((int)(El[i].GetX()) - El[i].GetThicnkness(), (int)(El[i].GetY()) - El[i].GetThicnkness(), El[i].GetRadius() * 2 + El[i].GetThicnkness() * 2, El[i].GetRadius() * 2 + El[i].GetThicnkness() * 2));
                e.Graphics.FillEllipse(new SolidBrush(El[i].GetColor()), new Rectangle((int)(El[i].GetX()), (int)(El[i].GetY()), El[i].GetRadius() * 2, El[i].GetRadius() * 2));
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            GrafPointH = this.Height - 100;
            GrafPointW = this.Width - 50;

            this.pictureBox1.Height = GrafPointH;
            this.pictureBox1.Width = GrafPointW;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // отрисовка
            pictureBox1.Refresh();
        }
    }
}