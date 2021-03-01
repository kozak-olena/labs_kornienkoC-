using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int[] GetPointsOfTriangle(PointF a, PointF b, PaintEventArgs e)
        {
            int[] treePointsOfNewTriangle = new int[3];

            PointF m = new PointF();
            PointF n = new PointF();
            PointF k = new PointF();

            m.X = a.X + (b.X - a.X) * 0.3f;
            m.Y = a.Y + (b.Y - a.Y) * 0.3f;

            k.X = b.X + (a.X - b.X) * 0.3f;
            k.Y = b.Y + (a.Y - b.Y) * 0.3f;

            double lengthOfSide = Math.Sqrt(Math.Pow(k.X - m.X, 2) + Math.Pow(k.Y - m.Y, 2));

            double half = 1 / 2;

            double calculationXPoint = 0.5 * ((m.Y - k.Y) *
                    Math.Sqrt(-(-Math.Pow(m.X, 2) + 2 * k.X * m.X - Math.Pow(k.X, 2) +
                    (-lengthOfSide + lengthOfSide - m.Y + k.Y) *
                    (-lengthOfSide + lengthOfSide + m.Y - k.Y)) *
                    (-Math.Pow(m.X, 2) + 2 * k.X * m.X - Math.Pow(k.X, 2) +
                    (lengthOfSide + lengthOfSide - m.Y + k.Y) * (lengthOfSide + lengthOfSide + m.Y - k.Y)) *
                    Math.Pow(m.X - k.X, 2) +
                    (Math.Pow(m.X, 3) - Math.Pow(m.X, 2) * k.X +
                    (Math.Pow(k.Y, 2) - 2 * m.Y * k.Y - Math.Pow(lengthOfSide, 2) + Math.Pow(m.Y, 2)
                    + Math.Pow(lengthOfSide, 2) - Math.Pow(k.X, 2)) *
                     m.X - k.X * (Math.Pow(lengthOfSide, 2) - Math.Pow(lengthOfSide, 2) - Math.Pow(k.X, 2)
                   - Math.Pow(k.Y, 2) + 2 * m.Y * k.Y - Math.Pow(m.Y, 2))) * (m.X - k.X))
                /
                    ((m.X - k.X) *
                    (Math.Pow(m.X, 2) - 2 * k.X * m.X + Math.Pow(k.X, 2) +
                     Math.Pow(m.Y - k.Y, 2)))
                );

            n.X = (float)calculationXPoint;

            double calculationYPoint =
            //(-sqrt(-(-x1^2+2*x2*x1-x2^2+(-c+a-y1+y2)*(-c+a+y1-y2))
            (-Math.Sqrt(-(-Math.Pow(m.X, 2) + 2 * k.X * m.X - Math.Pow(k.X, 2) +
            (-lengthOfSide + lengthOfSide - m.Y + k.Y) * (-lengthOfSide + lengthOfSide + m.Y - k.Y))   //$$
            *
            //(-x1^2+2*x2*x1-x2^2+(c+a-y1+y2)*(c+a+y1-y2))
            (-Math.Pow(m.X, 2) + 2 * k.X * m.X - Math.Pow(k.X, 2) + (lengthOfSide + lengthOfSide - m.Y + k.Y) *
            (lengthOfSide + lengthOfSide + m.Y - k.Y)) * //$$
            //(x1 - x2) ^ 2)
            Math.Pow(m.X - k.X, 2)) //$$
            //+y1^3-y1^2*y2+(a^2+x1^2-c^2+x2^2-2*x2*x1-y2^2)
            + Math.Pow(m.Y, 3) - Math.Pow(m.Y, 2) * k.Y +
             (Math.Pow(lengthOfSide, 2) + Math.Pow(m.X, 2) - Math.Pow(lengthOfSide, 2) + Math.Pow(k.X, 2) - 2 * m.X * k.X - Math.Pow(k.Y, 2)) * //$$
             //y1+y2^3+(x2^2-2*x2*x1+c^2-a^2+x1^2)*y2)
             m.Y + Math.Pow(k.Y, 3) + (Math.Pow(k.X, 2) - 2 * k.X * m.X + Math.Pow(lengthOfSide, 2) -
             Math.Pow(lengthOfSide, 2) + Math.Pow(m.X, 2)) * k.Y)
            /
            //(2*y1^2-4*y1*y2+2*y2^2+2*(x1-x2)^2)
            (2 * Math.Pow(m.Y, 2) - 4 * m.Y * k.Y + 2 * Math.Pow(k.Y, 2) + 2 * Math.Pow(m.Y - k.Y, 2));

            n.Y = (float)calculationYPoint;


            Pen pen = new Pen(Color.DarkBlue, 3);
            e.Graphics.DrawLine(pen, m.X, m.Y, n.X, n.Y);

            return treePointsOfNewTriangle;


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
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

            int[] treePoints = new int[3];
            treePoints = GetPointsOfTriangle(a, b, e);


        }
    }
}
