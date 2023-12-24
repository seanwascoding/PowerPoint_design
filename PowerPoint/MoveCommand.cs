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

        public MoveCommand(Model model, Shape shape, double[] shapeBefore, double[] shapeAfter)
        {
            _shape = shape;
            _tempBefore = shapeBefore;
            _tempAfter = shapeAfter;
        }

        // Execute
        public void Execute()
        {
            Console.WriteLine("test1");
            _shape._x1 = _tempAfter[0];
            _shape._y1 = _tempAfter[1];
            _shape._x2 = _tempAfter[2];
            _shape._y2 = _tempAfter[3];
        }

        // UnExecute
        public void UnExecute()
        {
            Console.WriteLine("test2");
            _shape._x1 = _tempBefore[0];
            _shape._y1 = _tempBefore[1];
            _shape._x2 = _tempBefore[2];
            _shape._y2 = _tempBefore[3];
            _shape._selected = false;
        }
    }
}
