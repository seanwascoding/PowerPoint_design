using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class CommandManager
    {
        Stack<ICommand> undo = new Stack<ICommand>();
        Stack<ICommand> redo = new Stack<ICommand>();

        // Execute
        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            undo.Push(cmd);
            redo.Clear();
        }

        // Undo
        public void Undo()
        {
            if (undo.Count <= 0)
                throw new Exception("Cannot Undo exception\n");
            ICommand cmd = undo.Pop();
            redo.Push(cmd);
            cmd.UnExecute();
        }

        // Redo
        public void Redo()
        {
            if (redo.Count <= 0)
                throw new Exception("Cannot Redo exception\n");
            ICommand cmd = redo.Pop();
            undo.Push(cmd);
            cmd.Execute();
        }

        // IsRedoEnabled
        public bool IsRedoEnabled
        {
            get
            {
                return redo.Count != 0;
            }
        }

        // IsUndoEnabled
        public bool IsUndoEnabled
        {
            get
            {
                return undo.Count != 0;
            }
        }
    }
}
