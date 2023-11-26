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
        const string LINE_NAME = "Line";

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
            return LINE_NAME;
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
        //private double PointToLineDistance(System.Drawing.Point point)
        //{
        //    double temp1 = point.X - _temp[SIZE_ZERO];
        //    double temp2 = point.Y - _temp[SIZE_ONE];
        //    double temp3 = _temp[SIZE_TWO] - _temp[SIZE_ZERO];
        //    double temp4 = _temp[SIZE_THREE] - _temp[SIZE_ONE];
        //    double dot = temp1 * temp3 + temp2 * temp4;
        //    double lengthSquare = temp3 * temp3 + temp4 * temp4;
        //    double temp5 = dot / lengthSquare;
        //    double result1;
        //    double result2;
        //    if (temp5 < SIZE_ZERO || (_temp[SIZE_ZERO] == _temp[SIZE_TWO] && _temp[SIZE_ONE] == _temp[SIZE_THREE]))
        //    {
        //        result1 = _temp[SIZE_ZERO];
        //        result2 = _temp[SIZE_ONE];
        //    }
        //    else if (temp5 > SIZE_ONE)
        //    {
        //        result1 = _temp[SIZE_TWO];
        //        result2 = _temp[SIZE_THREE];
        //    }
        //    else
        //    {
        //        result1 = _temp[SIZE_ZERO] + temp5 * temp3;
        //        result2 = _temp[SIZE_ONE] + temp5 * temp4;
        //    }
        //    double result3 = point.X - result1;
        //    double result4 = point.Y - result2;
        //    return Math.Sqrt(result3 * result3 + result4 * result4);
        //}

        private double PointToLineDistance(System.Drawing.Point point)
        {
            double temp1 = point.X - _temp[SIZE_ZERO];
            double temp2 = point.Y - _temp[SIZE_ONE];
            double temp3 = _temp[SIZE_TWO] - _temp[SIZE_ZERO];
            double temp4 = _temp[SIZE_THREE] - _temp[SIZE_ONE];
            double lengthSquare = temp3 * temp3 + temp4 * temp4;
            double dot = temp1 * temp3 + temp2 * temp4;
            double temp5 = Math.Min(SIZE_ONE, Math.Max(SIZE_ZERO, dot / lengthSquare));
            return Math.Sqrt((temp1 - temp5 * temp3) * (temp1 - temp5 * temp3) + (temp2 - temp5 * temp4) * (temp2 - temp5 * temp4));
        }
    }
}
