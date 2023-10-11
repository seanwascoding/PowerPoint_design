using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Shapes : Shape
    {
        const string INSTANCE = "active instance:";

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
            Console.WriteLine(INSTANCE + _components.Count);
        }

        private List<Shape> _components;

        // total Area
        public double GetArea()
        {
            return 0;
        }

        // GetLength
        public double GetLength()
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
