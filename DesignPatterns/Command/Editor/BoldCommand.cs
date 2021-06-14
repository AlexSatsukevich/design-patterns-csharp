namespace DesignPatterns.Command.Editor
{
    public class BoldCommand : IUndoableCommand
    {
        private string _previousContent;
        private readonly HtmlDocument _document;
        private readonly History _history;

        public BoldCommand(HtmlDocument document, History history)
        {
            _document = document;
            _history = history;
        }

        public void Execute()
        {
            _previousContent = _document.Content;
            _document.MakeBold();
            _history.Push(this);
        }

        public void Unexecute()
        {
            _document.Content = _previousContent;
        }
    }
}