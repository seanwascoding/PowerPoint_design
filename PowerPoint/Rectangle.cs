using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            _w = width;
            _h = height;
            temp = new double[4];
            random = new Random();
            temp[0] = GetRandomValue(random);
            temp[1] = GetRandomValue(random);
            temp[2] = GetRandomValue(random);
            temp[3] = GetRandomValue(random);
        }

        ~Rectangle()
        {
            Console.WriteLine("Rectangle destory");
        }

        // Area
        public double GetArea()
        {
            return _w * _h;
        }

        // Perimeter
        public double GetPerimeter()
        {
            return ((_w * 2) + (_h * 2));
        }

        // Coordinates
        public double[] GetCoordinates()
        {
            return temp;
        }

        // RandomValue
        private int GetRandomValue(Random random)
        {
            int temp = random.Next(1, 255);
            return temp;
        }

        private double _w, _h;
        private Random random;
        private double[] temp;
    }
}
