namespace DesignPatterns.Command.Editor
{
    public class UndoCommand : ICommand
    {
        private readonly History _history;

        public UndoCommand(History history)
        {
            _history = history;
        }

        public void Execute()
        {
            _history.Pop()?.Unexecute();
        }
    }
}
