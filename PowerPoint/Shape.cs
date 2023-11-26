using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Shape
    {
        // Area
        public virtual double GetArea()
        {
            return 0;
        }

        // GetLength
        public virtual double GetLength()
        {
            return 0;
        }

        // Coordinates
        public virtual double[] GetCoordinates()
        {
            return null;
        }

        // GetInfo
        public virtual void GetInfo()
        {
        }

        // draw
        public virtual void Draw(IGraphics graphics)
        {
        }

        // GetShapeName
        public virtual string GetShapeName()
        {
            return null;
        }

        // isContain
        public virtual bool IsContain(System.Drawing.Point point)
        {
            return false;
        }

        // peremeter
        internal protected double _x1;
        internal protected double _y1;
        internal protected double _x2;
        internal protected double _y2;

        // selected
        internal protected bool _selected = false;
    }
}
