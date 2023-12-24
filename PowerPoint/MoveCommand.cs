using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class MoveCommand : ICommand
    {
        Shape _shape;
        double[] _tempAfter;
        double[] _tempBefore;
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        const int SIZE_THREE = 3;

        public MoveCommand(Model model, Shape shape, double[] shapeBefore, double[] shapeAfter)
        {
            _shape = shape;
            _tempBefore = shapeBefore;
            _tempAfter = shapeAfter;
        }

        // Execute
        public void Execute()
        {
            _shape._x1 = _tempAfter[SIZE_ZERO];
            _shape._y1 = _tempAfter[SIZE_ONE];
            _shape._x2 = _tempAfter[SIZE_TWO];
            _shape._y2 = _tempAfter[SIZE_THREE];
        }

        // UnExecute
        public void ExecuteReverse()
        {
            _shape._x1 = _tempBefore[SIZE_ZERO];
            _shape._y1 = _tempBefore[SIZE_ONE];
            _shape._x2 = _tempBefore[SIZE_TWO];
            _shape._y2 = _tempBefore[SIZE_THREE];
            _shape._selected = false;
        }
    }
}
