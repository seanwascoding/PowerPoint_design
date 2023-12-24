using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    interface IState
    {
        // Intialize
        void InitializeState(Shape shape, Shapes compound, int state);
        // mousePress
        void PressMouse(double firstPointX, double firstPointY);
        // mouseMove
        void MoveMouse(double firstPointX, double firstPointY);
        // mouseDown
        void MoveDownMouse(double firstPointX, double firstPointY);
        // GetCompleteShape
        Shape GetCompleteShape();
    }
}
