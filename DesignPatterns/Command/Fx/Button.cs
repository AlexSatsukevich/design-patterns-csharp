using System;

namespace DesignPatterns.Command.Fx
{
    public class Button
    {
        private readonly ICommand _command;

        public Button(ICommand command)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
        }

        public string Label { get; set; }

        public void Click()
        {
            _command.Execute();
        }
    }
}
