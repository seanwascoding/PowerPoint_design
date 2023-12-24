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
        double _tempX1;
        double _tempY1;
        double _tempX2;
        double _tempY2;
        double[] _temp;

        // Intialize
        public void InitializeState(Shape shape, Shapes compound, int state)
        {
            _hint = shape;
            _temp = (double[])_hint.GetCoordinates().Clone();
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
            if (_hint._moveState)
            {
                _hint._x2 = firstPointX;
                _hint._y2 = firstPointY;
            }
            else
            {
                _hint._x1 = _tempX1 + (firstPointX - _firstPointX);
                _hint._y1 = _tempY1 + (firstPointY - _firstPointY);
                _hint._x2 = _tempX2 + (firstPointX - _firstPointX);
                _hint._y2 = _tempY2 + (firstPointY - _firstPointY);
            }
        }

        // PointerReleased
        public void MoveDownMouse(double firstPointX, double firstPointY)
        {
            if (_hint._moveState)
            {
                _hint._x2 = firstPointX;
                _hint._y2 = firstPointY;
                _hint._moveState = false;
            }
            else
            {
                _hint._x1 = _tempX1 + (firstPointX - _firstPointX);
                _hint._y1 = _tempY1 + (firstPointY - _firstPointY);
                _hint._x2 = _tempX2 + (firstPointX - _firstPointX);
                _hint._y2 = _tempY2 + (firstPointY - _firstPointY);
            }
        }

        // GetCompleteShape
        public Shape GetCompleteShape()
        {
            return _hint;
        }

        // GetBeforePosition
        public double[] GetBeforePosition()
        {
            return _temp;
        }

        // GetAfterPosition
        public double[] GetAfterPosition()
        {
            return (double[])_hint.GetCoordinates().Clone();
        }
    }
}
