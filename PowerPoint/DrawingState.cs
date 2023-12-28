using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class DrawingState : IState
    {
        double _firstPointX;
        double _firstPointY;
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        Shape _hint;
        Shape _currentHint;
        Shapes _compound;
        int _state;

        // Intialize
        public void InitializeState(Shape shape, Shapes compound, int state)
        {
            _hint = shape;
            _compound = compound;
            _state = state;
        }

        // PointerPressed
        public void PressMouse(double firstPointX, double firstPointY)
        {
            _firstPointX = firstPointX;
            _firstPointY = firstPointY;
            _hint._x1 = _firstPointX;
            _hint._y1 = _firstPointY;
        }

        // PointerMoved
        public void MoveMouse(double firstPointX, double firstPointY)
        {
            _hint._x2 = firstPointX;
            _hint._y2 = firstPointY;
        }

        // PointerReleased
        public void MoveDownMouse(double firstPointX, double firstPointY)
        {
            _currentHint = CheckState(); // check shape state
            if (_currentHint == null)
                return;
            _currentHint._x1 = _firstPointX;
            _currentHint._y1 = _firstPointY;
            _currentHint._x2 = firstPointX;
            _currentHint._y2 = firstPointY;
        }

        // GetCompleteShape
        public Shape GetCompleteShape()
        {
            return _currentHint;
        }

        // CheckState
        public Shape CheckState()
        {
            if (_state == SIZE_ZERO)
            {
                return ShapeFactory.CreateLine(0, 0, 0, 0);
            }
            else if (_state == SIZE_ONE)
            {
                return ShapeFactory.CreateRectangle(0, 0, 0, 0);
            }
            else if (_state == SIZE_TWO)
            {
                return ShapeFactory.CreateCircle(0, 0, 0, 0);
            }
            return null;
        }
    }
}
