﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Circle : Shape
    {
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        const int SIZE_THREE = 3;
        const int SIZE_FOUR = 4;
        const string CIRCLENAME = "Circle";
        const string CIRCLE = "Circle destory";

        public Circle(double x1, double y1, double x2, double y2)
        {
            _temp = new double[SIZE_FOUR];
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        ~Circle()
        {
            Console.WriteLine(CIRCLE);
        }

        // Coordinates
        public override double[] GetCoordinates()
        {
            _temp[SIZE_ZERO] = _x1;
            _temp[SIZE_ONE] = _y1;
            _temp[SIZE_TWO] = _x2;
            _temp[SIZE_THREE] = _y2;
            return _temp;
        }

        // GetShapeName
        public override string GetShapeName()
        {
            return CIRCLENAME;
        }

        // Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(_x1, _y1, _x2, _y2);
        }

        private double[] _temp;
    }
}