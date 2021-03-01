using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        class SquareCoordinates
        {
            public float X;
            public float Y;
            public SquareCoordinates(float x, float y)
            {
                X = x;
                Y = y;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.HotPink, 1);
            pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            e.Graphics.DrawRectangle(pen, 30, 10, 335, 335);

            SquareCoordinates[] squareCoordinates = new SquareCoordinates[4];
            float x = 0;
            float y = 0;

            for (int i = 0; i < 4; i++)
            {
                squareCoordinates[i] = new SquareCoordinates(x, y);
            }

            squareCoordinates[0].Y = 10;
            squareCoordinates[1].X = 365;
            squareCoordinates[1].Y = 10;
            squareCoordinates[2].X = 365;
            squareCoordinates[2].Y = 345;
            squareCoordinates[3].X = 30;
            squareCoordinates[3].Y = 345;

            int countLoops = 0;
            double p = 0.08;

            while (countLoops != 50)
            {
                float newX1;
                float newY1;

                for (int i = 0; i < 3; i++)
                {
                    newX1 = squareCoordinates[i].X + (squareCoordinates[i + 1].X - squareCoordinates[i].X) * (float)p;
                    newY1 = squareCoordinates[i].Y + (squareCoordinates[i + 1].Y - squareCoordinates[i].Y) * (float)p;


                    squareCoordinates[i].X = newX1;
                    squareCoordinates[i].Y = newY1;

                }

                newX1 = squareCoordinates[3].X + (squareCoordinates[0].X - squareCoordinates[3].X) * (float)p;
                newY1 = squareCoordinates[3].Y + (squareCoordinates[0].Y - squareCoordinates[3].Y) * (float)p;


                squareCoordinates[3].X = newX1;
                squareCoordinates[3].Y = newY1;


                Pen myPen = new Pen(Color.DeepPink, 1);
                for (int i = 0; i < 3; i++)
                {
                    e.Graphics.DrawLine(myPen, squareCoordinates[i].X, squareCoordinates[i].Y, squareCoordinates[i + 1].X, squareCoordinates[i + 1].Y);
                }
                e.Graphics.DrawLine(myPen, squareCoordinates[3].X, squareCoordinates[3].Y, squareCoordinates[0].X, squareCoordinates[0].Y);
                countLoops++;

            }
        }
    }
}
