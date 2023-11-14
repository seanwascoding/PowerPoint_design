using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class Line : Shape
    {
        const string LINE = "Line destory";
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        const int SIZE_THREE = 3;
        const int SIZE_FOUR = 4;
        const string LINENAME = "Line";

        public Line(double x1, double y1, double x2, double y2)
        {
            _temp = new double[SIZE_FOUR];
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        ~Line()
        {
            Console.WriteLine(LINE);
        }

        // Area
        public override double GetArea()
        {
            return SIZE_ZERO;
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
            return LINENAME;
        }

        // Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_x1, _y1, _x2, _y2);
        }

        private double[] _temp;

        // isContain
        public override bool isContain(System.Drawing.Point point)
        {
            double distance = PointToLineDistance(point);
            return distance < 10;
        }


        // PointToLineDistance
        private double PointToLineDistance(System.Drawing.Point point)
        {
            double a = point.X - _temp[0];
            double b = point.Y - _temp[1];
            double c = _temp[2] - _temp[0];
            double d = _temp[3] - _temp[1];

            double dot = a * c + b * d;
            double lenSq = c * c + d * d;
            double param = dot / lenSq;

            double xx, yy;

            if (param < 0 || (_temp[0] == _temp[2] && _temp[1] == _temp[3]))
            {
                xx = _temp[0];
                yy = _temp[1];
            }
            else if (param > 1)
            {
                xx = _temp[2];
                yy = _temp[3];
            }
            else
            {
                xx = _temp[0] + param * c;
                yy = _temp[1] + param * d;
            }

            double dx = point.X - xx;
            double dy = point.Y - yy;

            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
