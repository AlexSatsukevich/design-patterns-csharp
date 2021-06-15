using System.Collections.Generic;

namespace DesignPatterns.Mediator
{
    public abstract class UiControl
    {
        private readonly List<IEventHandler> _eventHandlers = new List<IEventHandler>();

        public void AddEventHandler(IEventHandler eventHandler)
        {
            _eventHandlers.Add(eventHandler);
        }

        protected void NotifyEventHandlers()
        {
            foreach (var handler in _eventHandlers)
            {
                handler.Handle();
            }
        }
    }
}