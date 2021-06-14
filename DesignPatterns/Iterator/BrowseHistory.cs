using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Iterator
{
    public class BrowseHistory
    {
        private readonly List<string> _urls = new List<string>();
        
        public void Push(string url)
        {
            _urls.Add(url);
        }

        public string Pop()
        {
            var last = _urls.LastOrDefault();

            if (last != null)
            {
                _urls.Remove(last);
            }

            return last;
        }

        public IIterator<string> CreateIterator()
        {
            return new ListIterator(this);
        } 

        private class ListIterator : IIterator<string>
        {
            private readonly BrowseHistory _history;
            private int _index;
            
            public ListIterator(BrowseHistory history)
            {
                _history = history;
            }
            
            public bool HasNext()
            {
                return _index < _history._urls.Count;
            }

            public string Current()
            {
                return _history._urls[_index];
            }

            public void Next()
            {
                _index++;
            }
        }
    }
}