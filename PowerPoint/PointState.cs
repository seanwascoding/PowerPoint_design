﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class PointState : IState
    {
        double _firstPointX;
        double _firstPointY;
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        Shape _hint;
        int _state;
        double _tempX1;
        double _tempY1;
        double _tempX2;
        double _tempY2;

        // Intialize
        public void InitializeState(Shape shape, Shapes compound, int state)
        {
            _hint = shape;
            _state = state;
        }

        // PointerPressed
        public void PressMouse(double firstPointX, double firstPointY)
        {
            _firstPointX = firstPointX;
            _firstPointY = firstPointY;
            _tempX1 = _hint._x1;
            _tempY1 = _hint._y1;
            _tempX2 = _hint._x2;
            _tempY2 = _hint._y2;
        }

        // PointerMoved
        public void MoveMouse(double firstPointX, double firstPointY)
        {
            _hint._x1 = _tempX1 + (firstPointX - _firstPointX);
            _hint._y1 = _tempY1 + (firstPointY - _firstPointY);
            _hint._x2 = _tempX2 + (firstPointX - _firstPointX);
            _hint._y2 = _tempY2 + (firstPointY - _firstPointY);
        }

        // PointerReleased
        public void MoveDownMouse(double firstPointX, double firstPointY)
        {
            _hint._x1 = _tempX1 + (firstPointX - _firstPointX);
            _hint._y1 = _tempY1 + (firstPointY - _firstPointY);
            _hint._x2 = _tempX2 + (firstPointX - _firstPointX);
            _hint._y2 = _tempY2 + (firstPointY - _firstPointY);
        }

        // CheckState
        public Shape CheckState()
        {
            if (_state == SIZE_ZERO)
            {
                return ShapeFactory.CreateLine();
            }
            else if (_state == SIZE_ONE)
            {
                return ShapeFactory.CreateRectangle();
            }
            else if (_state == SIZE_TWO)
            {
                return ShapeFactory.CreateCircle();
            }
            return null;
        }
    }
}
