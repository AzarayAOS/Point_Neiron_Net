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
        private float x, y;
        private bool f;

        public Form1()
        {
            f = false;
            x = 4;
            y = 3;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;

            f = !f;     // включение/отключение
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (f)
            {
                e.Graphics.Clear(Color.White);

                x += 0.5f;
                y += 0.3f;
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), new Rectangle((int)x, (int)y, 50, 50));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // отрисовка
            pictureBox1.Refresh();
        }
    }
}