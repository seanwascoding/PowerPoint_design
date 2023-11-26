using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class ShapeFactory
    {
        const int SIZE_ONE = 1;
        const int SIZE_Y = 730;
        const int SIZE_X = 557;

        // Line
        public static Shape CreateLine()
        {
            Random random = new Random();
            return new Line(GetRandomValue(random, SIZE_Y), GetRandomValue(random, SIZE_X), GetRandomValue(random, SIZE_Y), GetRandomValue(random, SIZE_X));
        }

        // Rectangle
        public static Shape CreateRectangle()
        {
            Random random = new Random();
            double x1 = GetRandomValue(random, SIZE_Y);
            double y1 = GetRandomValue(random, SIZE_X);
            double x2 = GetRandomValue(random, SIZE_Y);
            double y2 = GetRandomValue(random, SIZE_X);
            x2 = SetSuitableValue(x1, x2, random);
            y2 = SetSuitableValue(y1, y2, random);
            return new Rectangle(x1, y1, x2, y2);
        }

        // SetSuitableValue
        private static double SetSuitableValue(double temp1, double temp2, Random temp3)
        {
            while (true)
            {
                if (temp2 > temp1)
                    break;
                temp2 = GetRandomValue(temp3, SIZE_Y);
            }
            return temp2;
        }

        // Circle
        public static Shape CreateCircle()
        {
            Random random = new Random();
            return new Circle(GetRandomValue(random, SIZE_Y), GetRandomValue(random, SIZE_X), GetRandomValue(random, SIZE_Y), GetRandomValue(random, SIZE_X));
        }

        // Create random value
        private static double GetRandomValue(Random random, int max)
        {
            int value = random.Next(SIZE_ONE, max);
            return value;
        }
    }
}
