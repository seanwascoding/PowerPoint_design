using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class Line : Shape
    {
        public Line(double r)
        {
            _r = r;
            temp = new double[4];
            random = new Random();
            temp[0] = GetRandomValue(random);
            temp[1] = GetRandomValue(random);
            temp[2] = GetRandomValue(random);
            temp[3] = GetRandomValue(random);
        }

        ~Line()
        {
            Console.WriteLine("Line destory");
        }

        // Area
        public double GetArea()
        {
            return 0;
        }

        // Perimeter
        public double GetPerimeter()
        {
            return _r;
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

        private double _r;
        private Random random;
        private double[] temp;
    }
}
