using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class ShapeFactory
    {
        // Line
        public static Shape CreateLine(int positionx1, int positionx2, int positiony1, int positiony2)
        {
            return new Line(positionx1, positiony1, positionx2, positiony2);
        }

        // Rectangle
        public static Shape CreateRectangle(int positionx1, int positionx2, int positiony1, int positiony2)
        {
            double x1 = positionx1;
            double y1 = positiony1;
            double x2 = positionx2;
            double y2 = positiony2;
            return new Rectangle(x1, y1, x2, y2);
        }

        // Circle
        public static Shape CreateCircle(int positionx1, int positionx2, int positiony1, int positiony2)
        {
            return new Circle(positionx1, positiony1, positionx2, positiony2);
        }
    }
}
