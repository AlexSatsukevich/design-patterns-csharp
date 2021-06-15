using System;

namespace DesignPatterns.Mediator
{
    public class ArticlesDialogBox
    {
        private readonly ListBox _articlesListBox;
        private readonly TextBox _titleTextBox;
        private readonly Button _saveButton;

        public ArticlesDialogBox()
        {
            _articlesListBox = new ListBox();
            _titleTextBox = new TextBox();
            _saveButton = new Button();
            
            _articlesListBox.AddEventHandler(new ListBoxEventHandler(ArticleSelected));
            _titleTextBox.AddEventHandler(new TextBoxEventHandler(TitleChanged));
        }

        private class ListBoxEventHandler : IEventHandler
        {
            private readonly Action _articleSelected;

            public ListBoxEventHandler(Action articleSelected)
            {
                _articleSelected = articleSelected;
            }

            public void Handle()
            {
                _articleSelected();
            }
        }
        
        private class TextBoxEventHandler: IEventHandler
        {
            private readonly Action _titleChanged;

            public TextBoxEventHandler(Action titleChanged)
            {
                _titleChanged = titleChanged;
            }

            public void Handle()
            {
                _titleChanged();
            }
        }

        public void SimulateUserInteraction()
        {
            _articlesListBox.Selection = "Article 1";
            Console.WriteLine($"TextBox: {_titleTextBox.Content}");
            Console.WriteLine($"Button: is enabled {_saveButton.IsEnabled}");
        }

        private void TitleChanged()
        {
            _saveButton.IsEnabled = !string.IsNullOrEmpty(_titleTextBox.Content);
        }

        private void ArticleSelected()
        {
            _titleTextBox.Content = _articlesListBox.Selection;
            _saveButton.IsEnabled = true;
        }
    }
}
