using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '1')
            {
                e.Handled = false;
            }
        }


        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.DeepPink, 7);
            myPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            Pen penK = new Pen(Color.HotPink, 7);

            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(10, 10, 10, 100);
            graphicsPath.AddLine(10, 50, 50, 15);
            graphicsPath.AddLine(10, 50, 55, 95);
            e.Graphics.DrawPath(myPen, graphicsPath);

            Pen myPenO = new Pen(Color.Pink, 7);
            myPenO.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            e.Graphics.DrawRectangle(myPenO, 70, 10, 40, 90);


            Pen myPenZ = new Pen(Color.Coral, 7);
            myPenZ.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            GraphicsPath graphicsPathZ = new GraphicsPath();
            graphicsPathZ.AddLine(125, 10, 170, 10);
            graphicsPathZ.AddLine(170, 10, 125, 100);
            graphicsPathZ.AddLine(125, 100, 170, 100);
            e.Graphics.DrawPath(myPenZ, graphicsPathZ);


            //Pen penA = new Pen(Color.DeepPink, 7);
            //e.Graphics.DrawLine(penA, 210, 9, 180, 104);
            //e.Graphics.DrawLine(penA, 210, 9, 240, 104);
            //e.Graphics.DrawLine(penA, 190, 60, 230, 60);

            Pen penA = new Pen(Color.DeepPink, 7);
            penA.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            GraphicsPath graphicsPathA = new GraphicsPath();
            graphicsPath.AddLine(210, 9, 180, 100);
            graphicsPath.AddLine(210, 9, 240, 100);
            graphicsPath.AddLine(90, 60, 230, 60);
            e.Graphics.DrawPath(penA, graphicsPathA);

            e.Graphics.DrawLine(penK, 260, 10, 260, 100);
            e.Graphics.DrawLine(penK, 260, 50, 306, 97);
            e.Graphics.DrawLine(penK, 260, 50, 297, 12);

            e.Graphics.DrawRectangle(myPen, 10, 110, 40, 90);




        }
    }
}
