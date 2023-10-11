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
        public static Shape CreateLine(int temp)
        {
            return new Line(temp);
        }

        // Rectangle
        public static Shape CreateRectangle(int temp1, int temp2)
        {
            return new Rectangle(temp1, temp2);
        }
    }
}
