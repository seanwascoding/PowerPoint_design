using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class DrawCommand : ICommand
    {
        Model _model;
        Shape _shape;

        // DrawCommand
        public DrawCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        // Execute
        public void Execute()
        {
            _model.AddElement(_shape);
        }

        // UnExecute
        public void UnExecute()
        {
            _model.RemoveElement(_model.GetComponent().Count - 1);
        }
    }
}
