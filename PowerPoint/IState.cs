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
        void PressMouse(double x, double y);
        // mouseMove
        void MoveMouse(double x, double y);
        // mouseDown
        void MoveDownMouse(double x, double y);
    }
}
