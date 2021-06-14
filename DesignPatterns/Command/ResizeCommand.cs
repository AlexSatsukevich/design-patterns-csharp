using System;
using DesignPatterns.Command.Fx;

namespace DesignPatterns.Command
{
    public class ResizeCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Resize");
        }
    }
}
