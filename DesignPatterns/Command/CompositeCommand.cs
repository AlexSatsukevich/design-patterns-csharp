using System;
using System.Collections.Generic;
using DesignPatterns.Command.Fx;

namespace DesignPatterns.Command
{
    public class CompositeCommand : ICommand
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        public void Add(ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            
            _commands.Add(command);
        }
        
        public void Execute()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }
    }
}
