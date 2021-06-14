namespace DesignPatterns.Command.Editor
{
    public interface IUndoableCommand : ICommand
    {
        void Unexecute();
    }
}