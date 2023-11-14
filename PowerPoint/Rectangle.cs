using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class Rectangle : Shape
    {
        const string RECTANGLE = "Rectangle destory";
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        const int SIZE_THREE = 3;
        const int SIZE_FOUR = 4;
        const string RECTANGLENAME = "Rectangle";

        public Rectangle(double x1, double y1, double x2, double y2)
        {
            _temp = new double[SIZE_FOUR];
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        ~Rectangle()
        {
            Console.WriteLine(RECTANGLE);
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
            return RECTANGLENAME;
        }

        // Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_x1, _y1, _x2, _y2);
        }

        private double[] _temp;
    }
}
