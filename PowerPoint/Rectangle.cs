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

        public Rectangle(double width, double height)
        {

            _width = width;
            _height = height;
            _temp = new double[SIZE_FOUR];
            _random = new Random();
            _temp[SIZE_ZERO] = GetRandomValue(_random);
            _temp[SIZE_ONE] = GetRandomValue(_random);
            _temp[SIZE_TWO] = GetRandomValue(_random);
            _temp[SIZE_THREE] = GetRandomValue(_random);
        }

        ~Rectangle()
        {
            Console.WriteLine(RECTANGLE);
        }

        // Area
        public double GetArea()
        {
            return _width * _height;
        }

        // GetLength
        public double GetLength()
        {
            return ((_width * SIZE_TWO) + (_height * SIZE_TWO));
        }

        // Coordinates
        public double[] GetCoordinates()
        {
            return _temp;
        }

        // RandomValue
        private int GetRandomValue(Random random)
        {
            int value = random.Next(SIZE_ONE, SIZE_TO);
            return value;
        }

        private double _width;
        private double _height;
        private Random _random;
        private double[] _temp;
    }
}
