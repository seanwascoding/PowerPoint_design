using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class AddCommand : ICommand
    {
        Model _model;
        Shape _shape;

        // AddCommand
        public AddCommand(Model model, Shape shape)
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
        public void ExecuteReverse()
        {
            _model.RemoveElement(_model.GetComponent().Count - 1);
        }
    }
}
