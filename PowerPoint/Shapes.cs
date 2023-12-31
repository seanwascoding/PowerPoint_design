﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    [DataContract]
    public class Shapes : Shape
    {
        const string INSTANCE = "active instance:";

        [DataMember]
        public List<Shape> Components
        {
            get { return _components; }
            set { _components = value; }
        }

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

        // Clear
        public void ClearShape()
        {
            _components.Clear();
        }

        // GetComponents
        public List<Shape> GetComponents()
        {
            return _components;
        }

        private List<Shape> _components;
    }
}
