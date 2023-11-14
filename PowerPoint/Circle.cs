using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Circle : Shape
    {
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        const int SIZE_THREE = 3;
        const int SIZE_FOUR = 4;
        const string CIRCLENAME = "Circle";
        const string CIRCLE = "Circle destory";

        public Circle(double x1, double y1, double x2, double y2)
        {
            _temp = new double[SIZE_FOUR];
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        ~Circle()
        {
            Console.WriteLine(CIRCLE);
        }

        // Coordinates
        public override double[] GetCoordinates()
        {
            _temp[SIZE_ZERO] = _x1;
            _temp[SIZE_ONE] = _y1;
            _temp[SIZE_TWO] = _x2;
            _temp[SIZE_THREE] = _y2;
            return _temp;
        }

        // GetShapeName
        public override string GetShapeName()
        {
            return CIRCLENAME;
        }

        // Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(_x1, _y1, _x2, _y2);
        }

        private double[] _temp;

        // isContain
        public override bool isContain(Point point)
        {
            Point ellipseCenter = new Point(((int)_temp[0] + (int)_temp[2]) / 2, ((int)_temp[3] + (int)_temp[1]) / 2);
            double ellipseMajorAxis = Math.Abs((_temp[2] - _temp[0]) / 2);
            double ellipseMinorAxis = Math.Abs((_temp[3] - _temp[1]) / 2);
            double distance = CalculateDistanceToEllipse(point, ellipseCenter, ellipseMajorAxis, ellipseMinorAxis);
            return distance == 0;
        }

        // CalculateDistanceToEllipse
        private double CalculateDistanceToEllipse(Point point, Point ellipseCenter, double majorAxis, double minorAxis)
        {
            double distanceToCenter = Math.Sqrt(Math.Pow(point.X - ellipseCenter.X, 2) + Math.Pow(point.Y - ellipseCenter.Y, 2));
            //Console.WriteLine("滑鼠到橢圓的距離: " + distanceToCenter);
            if (Math.Pow((point.X - ellipseCenter.X) / majorAxis, 2) + Math.Pow((point.Y - ellipseCenter.Y) / minorAxis, 2) <= 1)
            {
                return 0;
            }
            return -1;
        }
    }
}
