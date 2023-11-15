using System;
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
        double _tempx1;
        double _tempy1;
        double _tempx2;
        double _tempy2;

        // Intialize
        public void InitializeState(Shape shape, Shapes compound, int state)
        {
            _hint = shape;
            _state = state;
        }

        // PointerPressed
        public void PressMouse(double x, double y)
        {
            _firstPointX = x;
            _firstPointY = y;
            _tempx1 = _hint._x1;
            _tempy1 = _hint._y1;
            _tempx2 = _hint._x2;
            _tempy2 = _hint._y2;
        }

        // PointerMoved
        public void MoveMouse(double x, double y)
        {
            _hint._x1 = _tempx1 + (x - _firstPointX);
            _hint._y1 = _tempy1 + (y - _firstPointY);
            _hint._x2 = _tempx2 + (x - _firstPointX);
            _hint._y2 = _tempy2 + (y - _firstPointY);
        }

        // PointerReleased
        public void MoveDownMouse(double x, double y)
        {
            _hint._x1 = _tempx1 + (x - _firstPointX);
            _hint._y1 = _tempy1 + (y - _firstPointY);
            _hint._x2 = _tempx2 + (x - _firstPointX);
            _hint._y2 = _tempy2 + (y - _firstPointY);
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
