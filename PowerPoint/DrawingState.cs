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
            Shape hint = CheckState(); // check shape state
            if (hint == null)
                return;
            hint._x1 = _firstPointX;
            hint._y1 = _firstPointY;
            hint._x2 = firstPointX;
            hint._y2 = firstPointY;
            _compound.AddShape(hint);
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
