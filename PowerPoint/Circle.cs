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
        const int ERROR_CODE = -1;
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        const int SIZE_THREE = 3;
        const int SIZE_FOUR = 4;
        const string CIRCLE_NAME = "Circle";
        const string CIRCLE_DELETE = "Circle destory";

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
            Console.WriteLine(CIRCLE_DELETE);
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
            return CIRCLE_NAME;
        }

        // Draw
        public override void Draw(IGraphics graphics)
        {
            _temp[SIZE_ZERO] = _x1;
            _temp[SIZE_ONE] = _y1;
            _temp[SIZE_TWO] = _x2;
            _temp[SIZE_THREE] = _y2;
            if (!_selected)
                graphics.DrawCircle(_x1, _y1, _x2, _y2);
            else
                graphics.DrawCircleSelected(_x1, _y1, _x2, _y2);
        }

        private double[] _temp;

        // isContain
        public override bool IsContain(Point point)
        {
            Point ellipseCenter = new Point(((int)_temp[SIZE_ZERO] + (int)_temp[SIZE_TWO]) / SIZE_TWO, ((int)_temp[SIZE_THREE] + (int)_temp[SIZE_ONE]) / SIZE_TWO);
            double ellipseMajorValue = Math.Abs((_temp[SIZE_TWO] - _temp[SIZE_ZERO]) / SIZE_TWO);
            double ellipseMinorValue = Math.Abs((_temp[SIZE_THREE] - _temp[SIZE_ONE]) / SIZE_TWO);
            double distance = CalculateDistanceToEllipse(point, ellipseCenter, ellipseMajorValue, ellipseMinorValue);
            return distance == SIZE_ZERO;
        }

        // CalculateDistanceToEllipse
        private double CalculateDistanceToEllipse(Point point, Point ellipseCenter, double ellipseMajorValue, double ellipseMinorValue)
        {
            if (Math.Pow((point.X - ellipseCenter.X) / ellipseMajorValue, SIZE_TWO) + Math.Pow((point.Y - ellipseCenter.Y) / ellipseMinorValue, SIZE_TWO) <= SIZE_ONE)
            {
                return SIZE_ZERO;
            }
            return ERROR_CODE;
        }

    }
}
