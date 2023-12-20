using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    interface ICommand
    {
        // Execute
        void Execute();

        // UnExecute
        void UnExecute();
    }
}
