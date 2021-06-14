using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Command.Editor
{
    public class History
    {
        private readonly List<IUndoableCommand> _commands = new List<IUndoableCommand>();

        public void Push(IUndoableCommand command)
        {
            _commands.Add(command);
        }

        public IUndoableCommand Pop()
        {
            var command = _commands.LastOrDefault();
            _commands.Remove(command);
            
            return command;
        }
    }
}
