using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class ShapeFactory
    {
        // Line
        public static Shape CreateLine()
        {
            return new Line();
        }

        // Rectangle
        public static Shape CreateRectangle()
        {
            return new Rectangle();
        }

        // Circle
        public static Shape CreateCircle()
        {
            return new Circle();
        }
    }
}
