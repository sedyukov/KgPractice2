using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KgPractice2
{
    public partial class Form1 : Form
    {
        static Graphics holst;
        static Pen pen_green;

        public Form1()
        {
            InitializeComponent();
        }

        static int FractalKoh(PointF p1, PointF p2, PointF p3, int iter)
        {
            if (iter > 0)
            {
                var p4 = new PointF((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
                var p5 = new PointF((2 * p2.X + p1.X) / 3, (p1.Y + 2 * p2.Y) / 3);

                var ps = new PointF((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
                var pn = new PointF((4 * ps.X - p3.X) / 3, (4 * ps.Y - p3.Y) / 3);

                holst.DrawLine(pen_green, p4, pn);
                holst.DrawLine(pen_green, p5, pn);
                holst.DrawLine(pen_green, p4, p5);

                FractalKoh(p4, pn, p5, iter - 1);
                FractalKoh(pn, p5, p4, iter - 1);
                FractalKoh(p1, p4, new PointF((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), iter - 1);
                FractalKoh(p5, p2, new PointF((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), iter - 1);
            }
            return iter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
            pen_green = new Pen(Color.Green, 3);
            holst = CreateGraphics();
            holst.Clear(Color.White);

            var point1 = new PointF(ClientSize.Width / 3, ClientSize.Height / 3);
            var point2 = new PointF((ClientSize.Width / 3) * 2, ClientSize.Height / 3);
            var point3 = new PointF(ClientSize.Width / 2, (ClientSize.Height / 3) * 2);

            holst.DrawLine(pen_green, point1, point2);
            holst.DrawLine(pen_green, point2, point3);
            holst.DrawLine(pen_green, point3, point1);

            FractalKoh(point1, point2, point3, 4);
            FractalKoh(point2, point3, point1, 4);
            FractalKoh(point3, point1, point2, 4);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
