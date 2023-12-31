using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    [DataContract]
    public class Shape
    {
        // Coordinates
        public virtual double[] GetCoordinates()
        {
            return _coordinate;
        }

        // draw
        public virtual void Draw(IGraphics graphics)
        {
        }

        // GetShapeName
        public virtual string GetShapeName()
        {
            return _shapeName;
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

        // _moveState
        internal protected bool _moveState = false;

        [DataMember(Order = 2)]
        public double[] Coordinates
        {
            get { return GetCoordinates(); }
            set { _coordinate = value; }
        }

        [DataMember(Order = 1)]
        public string ShapeName
        {
            get { return GetShapeName(); }
            set { _shapeName = value; }
        }

        internal protected string _shapeName;
        internal protected double[] _coordinate;
    }
}
