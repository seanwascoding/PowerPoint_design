using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class CommandManager
    {
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();

        const string UNDO_EXCEPTION = "Cannot Undo exception\n";
        const string REDO_EXCEPTION = "Cannot Redo exception\n";

        // Execute
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        // Undo
        public void Undo()
        {
            if (_undo.Count <= 0)
                throw new Exception(UNDO_EXCEPTION);
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.ExecuteReverse();
        }

        // Redo
        public void Redo()
        {
            if (_redo.Count <= 0)
                throw new Exception(REDO_EXCEPTION);
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        // IsRedoEnabled
        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        // IsUndoEnabled
        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }
    }
}
