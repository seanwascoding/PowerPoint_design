using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class DeleteCommand : ICommand
    {
        Model _model;
        int _position;
        Shape _shape;

        public DeleteCommand(Model model, int position)
        {
            _model = model;
            _position = position;
            _shape = _model.GetComponent()[_position];
        }

        // Execute
        public void Execute()
        {
            _model.RemoveElement(_position);
        }

        // UnExecute
        public void UnExecute()
        {
            _model.AddElement(_shape);
        }
    }
}
