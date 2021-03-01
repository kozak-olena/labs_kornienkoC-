using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4NEW
{
    public partial class Form1 : Form
    {
        public class TriangleCoordinates
        {
            public PointF A;
            public PointF B;
            public PointF C;
            public TriangleCoordinates(PointF a, PointF b, PointF c)
            {
                A = a;
                B = b;
                C = c;
            }
            public TriangleCoordinates()
            {

            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string readNumber = textBox1.Text;
            int input = 0;
            int.TryParse(readNumber, out input);

        }


        public void DrawTriangles(PointF a, PointF b, PointF c, int nesting, PaintEventArgs e)
        {
            float p = 0.5f;
            if (nesting == 3)
            {
                return;
            }
            else
            {
                PointF m = new PointF();
                m.X = b.X + (a.X - b.X) * p;
                m.Y = b.Y + (a.Y - b.Y) * p;
                PointF n = new PointF();
                n.X = b.X + (c.X - b.X) * p;
                n.Y = b.Y + (c.Y - b.Y) * p;
                PointF k = new PointF();
                k.X = a.X + (c.X - a.X) * p;
                k.Y = a.Y + (c.Y - a.Y) * p;

                Pen pen = new Pen(Color.HotPink, 4);
                e.Graphics.DrawLine(pen, m, n);
                e.Graphics.DrawLine(pen, n, k);
                e.Graphics.DrawLine(pen, k, m);

                DrawTriangles(m, b, n, nesting + 1, e);
                DrawTriangles(a, m, k, nesting + 1, e);
                DrawTriangles(a, m, k, nesting + 1, e);



            }

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            string readNumber = textBox1.Text;
            int input = 0;
            int.TryParse(readNumber, out input);

            Pen pen = new Pen(Color.HotPink, 2);
            e.Graphics.DrawLine(pen, 200, 3, (float)17.147303, 297);
            e.Graphics.DrawLine(pen, (float)17.147303, 297, (float)360.093362, 297);
            e.Graphics.DrawLine(pen, (float)360.093362, 297, 200, 3);

            PointF a = new PointF();
            PointF b = new PointF();
            PointF c = new PointF();
            b.X = 200;
            b.Y = 3;
            a.X = 17.147303f;
            a.Y = 297;
            c.X = (float)360.093362;
            c.Y = 297;

            int nesting = 0;

            DrawTriangles(a, b, c, nesting, e);





        }
    }
}
