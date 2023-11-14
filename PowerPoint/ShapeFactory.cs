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
        const int SIZE_HIGHT = 730;
        const int SIZE_WIDTH = 557;

        // Line
        public static Shape CreateLine()
        {
            Random random = new Random();
            return new Line(GetRandomValue(random, SIZE_HIGHT), GetRandomValue(random, SIZE_WIDTH), GetRandomValue(random, SIZE_HIGHT), GetRandomValue(random, SIZE_WIDTH));
        }

        // Rectangle
        public static Shape CreateRectangle()
        {
            Random random = new Random();
            double x1 = GetRandomValue(random, SIZE_HIGHT);
            double y1 = GetRandomValue(random, SIZE_WIDTH);
            double x2 = GetRandomValue(random, SIZE_HIGHT);
            double y2 = GetRandomValue(random, SIZE_WIDTH);
            while (true)
            {
                if (x2 > x1)
                    break;
                x2 = GetRandomValue(random, SIZE_HIGHT);
            }
            while (true)
            {
                if (y2 > y1)
                    break;
                y2 = GetRandomValue(random, SIZE_WIDTH);

            }
            return new Rectangle(x1, y1, x2, y2);
        }

        // Circle
        public static Shape CreateCircle()
        {
            Random random = new Random();
            return new Circle(GetRandomValue(random, SIZE_HIGHT), GetRandomValue(random, SIZE_WIDTH), GetRandomValue(random, SIZE_HIGHT), GetRandomValue(random, SIZE_WIDTH));
        }

        // Create random value
        private static double GetRandomValue(Random random, int max)
        {
            int value = random.Next(SIZE_ONE, max);
            return value;
        }
    }
}
