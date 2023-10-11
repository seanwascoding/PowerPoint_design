using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Shapes : Shape
    {
        public Shapes()
        {
            _components = new List<Shape>();
        }

        // add shape
        public void AddShape(Shape shape)
        {
            _components.Add(shape);
        }

        // remove shape
        public void RemoveShape(int position)
        {
            _components.RemoveAt(position);
            Console.WriteLine(_components.Count);
        }

        private List<Shape> _components;

        // total Area
        public double GetArea()
        {
            return 0;
        }

        // total Perimeter
        public double GetPerimeter()
        {
            return 0;
        }

        // total Coordinates
        public double[] GetCoordinates()
        {
            return null;
        }

    }
}
