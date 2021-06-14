using System;
using DesignPatterns.Command;
using DesignPatterns.Command.Editor;
using DesignPatterns.Command.Fx;
using DesignPatterns.Iterator;
using DesignPatterns.Memento;
using DesignPatterns.Observer;
using DesignPatterns.State;
using DesignPatterns.Strategy;
using DesignPatterns.TemplateMethod;
using History = DesignPatterns.Memento.History;

// ReSharper disable UnusedMember.Local

namespace DesignPatterns
{
    internal static class Program
    {
        private static void Main()
        {
            // TestMemento();
            // TestState();
            // TestIterator();
            // TestStrategy();
            // TestTemplateMethod();
            // TestCommand();
            TestObserver();
        }

        private static void TestMemento()
        {
            var editor = new Editor();
            var history = new History();

            editor.Content = "a";
            history.Push(editor.CreateState());
            
            editor.Content = "b";
            history.Push(editor.CreateState());

            editor.Content = "c";
            history.Push(editor.CreateState());

            editor.Content = "d";
            history.Push(editor.CreateState());

            editor.Content = "e";
            editor.Restore(history.Pop());

            Console.WriteLine($"Last item is {editor.Content}");
            Console.ReadKey();
        }

        private static void TestState()
        {
            var canvas = new Canvas
            {
                CurrentTool = new SelectionTool()
            };

            canvas.MouseDown();
            canvas.MouseUp();
            
            canvas.CurrentTool = new BrushTool();
            
            canvas.MouseDown();
            canvas.MouseUp();
            
            canvas.CurrentTool = new EraserTool();
            
            canvas.MouseDown();
            canvas.MouseUp();
        }

        private static void TestIterator()
        {
            var history = new BrowseHistory();
            history.Push("a");
            history.Push("b");
            history.Push("c");

            var iterator = history.CreateIterator();

            while (iterator.HasNext())
            {
                var url = iterator.Current();
                Console.WriteLine(url);
                iterator.Next();
            }
        }

        private static void TestStrategy()
        {
            var imageStorage = new ImageStorage(
                new JpegCompressor(), 
                new BlackAndWhiteFilter());

            imageStorage.Store("a");
        }

        private static void TestTemplateMethod()
        {
            var task = new TransferMoneyTask(new AuditTrial());
            task.Execute();
        }

        private static void TestCommand()
        {
            var service = new CustomerService();
            var command = new AddCustomerCommand(service);
            var button = new Button(command);
            button.Click();
            
            var composite = new CompositeCommand();
            composite.Add(new ResizeCommand());
            composite.Add(new BlackAndWhiteCommand());
            composite.Execute();
            
            var history = new Command.Editor.History();
            var document = new HtmlDocument
            {
                Content = "Hello world"
            };
            
            var boldCommand = new BoldCommand(document, history);
            boldCommand.Execute();

            Console.WriteLine(document.Content);
            
            var undoCommand = new UndoCommand(history);
            undoCommand.Execute();

            Console.WriteLine(document.Content);
        }

        private static void TestObserver()
        {
            var dataSource = new DataSource();
             
            var sheet1 = new SpreadSheet(dataSource);
            var sheet2 = new SpreadSheet(dataSource);
            var chart = new Chart(dataSource);
            
            dataSource.AddObserver(sheet1);
            dataSource.AddObserver(sheet2);
            dataSource.AddObserver(chart);

            dataSource.Value = 1;
        }
    }
}
