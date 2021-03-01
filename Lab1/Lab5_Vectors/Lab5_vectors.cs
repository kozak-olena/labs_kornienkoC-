using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_Vectors
{
    public partial class GetTwoPointsInRightDirection : Form
    {
        public GetTwoPointsInRightDirection()
        {
            InitializeComponent();
        }




        public void GetTwoPointsOfTriangleBaseOfNewTriangle(PointF a, PointF b, out PointF c, out PointF d)
        {
            c = new PointF();
            d = new PointF();

            c.X = a.X + (b.X - a.X) * 0.3f;
            c.Y = a.Y + (b.Y - a.Y) * 0.3f;

            d.X = b.X + (a.X - b.X) * 0.3f;
            d.Y = b.Y + (a.Y - b.Y) * 0.3f;

        }

        public double GetLengthOfSegment(PointF a, PointF b)
        {
            PointF c = new PointF();
            PointF d = new PointF();
            GetTwoPointsOfTriangleBaseOfNewTriangle(a, b, out c, out d);

            double lengthOfsegmentCD;
            lengthOfsegmentCD = Math.Sqrt(Math.Pow(c.X - d.X, 2) + Math.Pow(c.Y - d.Y, 2));
            return lengthOfsegmentCD;
        }

        public PointF GetMiddlePointOfTriangle(PointF a, PointF b)
        {
            PointF c = new PointF();
            PointF d = new PointF();

            GetTwoPointsOfTriangleBaseOfNewTriangle(a, b, out c, out d);

            PointF middlePoint = new PointF();
            middlePoint.X = (c.X + d.X) / 2;
            middlePoint.Y = (c.Y + d.Y) / 2;

            return middlePoint;

        }


        public double GetHeightOfTriangle(PointF a, PointF b)
        {
            double lengthOfSegment = GetLengthOfSegment(a, b);

            double heightKH = ((lengthOfSegment * Math.Sqrt(3)) / 2);

            return heightKH;
        }

        public PointF GetVector(PointF a, PointF b)
        {
            PointF c = new PointF();
            PointF d = new PointF();
            GetTwoPointsOfTriangleBaseOfNewTriangle(a, b, out c, out d);

            PointF middlePointOfTriangle = new PointF();

            middlePointOfTriangle = GetMiddlePointOfTriangle(a, b);

            PointF vectorA = new PointF();
            vectorA.X = middlePointOfTriangle.X - c.X;
            vectorA.Y = middlePointOfTriangle.Y - c.Y;

            return vectorA;
        }

        public PointF[] GetTrianglePeaksCoordinates(PointF a, PointF b, PaintEventArgs e)
        {
            double heightKH = GetHeightOfTriangle(a, b);

            PointF vectorA = new PointF();
            vectorA = GetVector(a, b);
            PointF middlePoint = new PointF();
            middlePoint = GetMiddlePointOfTriangle(a, b);

            PointF coordinatesOfVector1 = new PointF();
            coordinatesOfVector1.Y = (float)Math.Sqrt((Math.Pow(heightKH, 2) * Math.Pow(vectorA.X, 2)) / (Math.Pow(vectorA.Y, 2) + Math.Pow(vectorA.X, 2)));
            coordinatesOfVector1.X = -((vectorA.Y * coordinatesOfVector1.Y) / vectorA.X);

            PointF coordinatesOfVector2 = new PointF();
            coordinatesOfVector2.Y = -(float)Math.Sqrt((Math.Pow(heightKH, 2) * Math.Pow(vectorA.X, 2)) / (Math.Pow(vectorA.Y, 2) + Math.Pow(vectorA.X, 2)));
            coordinatesOfVector2.X = -((vectorA.Y * coordinatesOfVector2.Y) / vectorA.X);


            PointF peaksCoordinateOfTriangleK1 = new PointF();
            peaksCoordinateOfTriangleK1.X = coordinatesOfVector1.X + middlePoint.X;
            peaksCoordinateOfTriangleK1.Y = coordinatesOfVector1.Y + middlePoint.Y;

            PointF alternativePeaksCoordinateOfTriangleK2 = new PointF();
            alternativePeaksCoordinateOfTriangleK2.X = coordinatesOfVector2.X + middlePoint.X;
            alternativePeaksCoordinateOfTriangleK2.Y = coordinatesOfVector2.Y + middlePoint.Y;

         
            PointF[] twoVariantOfTrianglePeaks = new PointF[2];
            twoVariantOfTrianglePeaks[0].X = peaksCoordinateOfTriangleK1.X;
            twoVariantOfTrianglePeaks[0].Y = peaksCoordinateOfTriangleK1.Y;
            twoVariantOfTrianglePeaks[1].X = alternativePeaksCoordinateOfTriangleK2.X;
            twoVariantOfTrianglePeaks[1].Y = alternativePeaksCoordinateOfTriangleK2.Y;

            PointF c = new PointF();
            PointF d = new PointF();

            GetTwoPointsOfTriangleBaseOfNewTriangle(a, b, out c, out d);

            
            return twoVariantOfTrianglePeaks;

        }


        public PointF GetTwoPointsOfCorrectDirection(PointF a, PointF b, PaintEventArgs e)
        {

            PointF twoPointsOfCorrectDirection = new PointF();

            PointF[] trianglePeaksCoordinates = new PointF[2];
            trianglePeaksCoordinates = GetTrianglePeaksCoordinates(a, b, e);

            PointF vectorA = GetVector(a, b);

            PointF c = new PointF();
            PointF d = new PointF();
            GetTwoPointsOfTriangleBaseOfNewTriangle(a, b, out c, out d);

            PointF vectorB1 = new PointF();
            vectorB1.X = trianglePeaksCoordinates[0].X - c.X;
            vectorB1.Y = trianglePeaksCoordinates[0].Y - c.Y;

            PointF alternativeVectorB2 = new PointF();
            alternativeVectorB2.X = trianglePeaksCoordinates[1].X - c.X;
            alternativeVectorB2.Y = trianglePeaksCoordinates[1].Y - c.Y;

            double direction1 = vectorA.X * vectorB1.Y - vectorA.Y * vectorB1.X;
            double direction2 = vectorA.X * alternativeVectorB2.Y - vectorA.Y * alternativeVectorB2.X;

            if (direction1 <= 0)
            {
                twoPointsOfCorrectDirection.X = trianglePeaksCoordinates[0].X;
                twoPointsOfCorrectDirection.Y = trianglePeaksCoordinates[0].Y;
            }
            else  
            {
                twoPointsOfCorrectDirection.X = trianglePeaksCoordinates[1].X;
                twoPointsOfCorrectDirection.Y = trianglePeaksCoordinates[1].Y;
            }


            return twoPointsOfCorrectDirection;

        }

        public void DrawSnowflake(PointF a, PointF b, PointF c, int nesting, PaintEventArgs e)
        {
            DrawKochSnowflakeElement(a, b, nesting, e);
            DrawKochSnowflakeElement(b, c, nesting, e);
            DrawKochSnowflakeElement(c, a, nesting, e);

        }

        public void DrawKochSnowflakeElement(PointF a, PointF b, int nesting, PaintEventArgs e)
        {
            if (nesting == 7)
            {
                Pen pen = new Pen(Color.Coral, 3);
                e.Graphics.DrawLine(pen, a, b);

                return;
            }
            else
            {
                PointF m = new PointF();
                PointF n = new PointF();
                PointF k = new PointF();
                GetTwoPointsOfTriangleBaseOfNewTriangle(a, b, out m, out n);
                k = GetTwoPointsOfCorrectDirection(a, b, e);

                

                DrawKochSnowflakeElement(a, m, nesting + 1, e);
                DrawKochSnowflakeElement(m, k, nesting + 1, e);
                DrawKochSnowflakeElement(k, n, nesting + 1, e);
                DrawKochSnowflakeElement(n, b, nesting + 1, e);

            }
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.HotPink, 2);
           

            PointF a = new PointF();
            PointF b = new PointF();
            PointF c = new PointF();
            b.X = 210;
            b.Y = 13;
            a.X = 27.147303f;
            a.Y = 307;
            c.X = 370.093362f;
            c.Y = 307;

            int nesting = 0;
            DrawSnowflake(a, b, c, nesting, e);
        }
    }
}
