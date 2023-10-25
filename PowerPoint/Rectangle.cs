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
        const int SIZE_TO = 255;
        const int SIZE_HIGHT = 730;
        const int SIZE_WIDTH = 557;
        const string RECTANGLENAME = "Rectangle";

        public Rectangle()
        {
            _temp = new double[SIZE_FOUR];
            _random = new Random();
            _x1 = GetRandomValue(_random, SIZE_HIGHT);
            _y1 = GetRandomValue(_random, SIZE_WIDTH);
            while (true)
            {
                _x2 = GetRandomValue(_random, SIZE_HIGHT);
                if (_x2 > _x1)
                    break;
            }
            while (true)
            {
                _y2 = GetRandomValue(_random, SIZE_WIDTH);
                if (_y2 > _y1)
                    break;
            }
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

        // RandomValue
        private int GetRandomValue(Random random, int max)
        {
            int value = random.Next(SIZE_ONE, max);
            return value;
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

        private Random _random;
        private double[] _temp;
    }
}
