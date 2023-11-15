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
        void Intialize(Shape shape, Shapes compound, int state);
        // mousePress
        void mousePress(double x, double y);
        // mouseMove
        void mouseMove(double x, double y);
        // mouseDown
        void mouseDown(double x, double y);
    }
}
