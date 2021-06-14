using System;
using DesignPatterns.Command.Fx;

namespace DesignPatterns.Command
{
    public class BlackAndWhiteCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Black and white");
        }
    }
}
