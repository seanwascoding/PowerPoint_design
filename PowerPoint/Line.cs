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
        const int TEN = 10;
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
            _temp[SIZE_ZERO] = _x1;
            _temp[SIZE_ONE] = _y1;
            _temp[SIZE_TWO] = _x2;
            _temp[SIZE_THREE] = _y2;
            if (!_selected)
                graphics.DrawLine(_x1, _y1, _x2, _y2);
            else
                graphics.DrawLineSelected(_x1, _y1, _x2, _y2);
        }

        private double[] _temp;

        // isContain
        public override bool IsContain(System.Drawing.Point point)
        {
            double distance = PointToLineDistance(point);
            return distance < TEN;
        }

        // PointToLineDistance
        private double PointToLineDistance(System.Drawing.Point point)
        {
            double a = point.X - _temp[SIZE_ZERO];
            double b = point.Y - _temp[SIZE_ONE];
            double c = _temp[SIZE_TWO] - _temp[SIZE_ZERO];
            double d = _temp[SIZE_THREE] - _temp[SIZE_ONE];

            double dot = a * c + b * d;
            double lenSq = c * c + d * d;
            double param = dot / lenSq;

            double xx;
            double yy;

            if (param < SIZE_ZERO || (_temp[SIZE_ZERO] == _temp[SIZE_TWO] && _temp[SIZE_ONE] == _temp[SIZE_THREE]))
            {
                xx = _temp[SIZE_ZERO];
                yy = _temp[SIZE_ONE];
            }
            else if (param > SIZE_ONE)
            {
                xx = _temp[SIZE_TWO];
                yy = _temp[SIZE_THREE];
            }
            else
            {
                xx = _temp[SIZE_ZERO] + param * c;
                yy = _temp[SIZE_ONE] + param * d;
            }

            double dx = point.X - xx;
            double dy = point.Y - yy;

            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
