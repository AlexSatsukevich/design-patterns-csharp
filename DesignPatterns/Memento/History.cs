using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Memento
{
    public class History
    {
        private readonly List<EditorState> _states = new List<EditorState>();

        public void Push(EditorState state)
        {
            _states.Add(state);
        }

        public EditorState Pop()
        {
            if (!_states.Any()) return null;

            var last = _states.Last();
            _states.Remove(last);

            return last;
        }
    }
}