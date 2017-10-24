using System;

namespace Idfy.Events.Entities
{
    public interface IEvent
    {
        Guid Id { get; }
        EventType Type { get; set; }
        object Payload { get; set; }
    }
    
    public abstract class Event<T> : IEvent where T : class
    {
        protected Event(EventType type, T payload)
        {
            Id = Guid.NewGuid();
            Type = type;
            Payload = payload;
        }

        public Guid Id { get; }
        public EventType Type { get; set; }
        public object Payload { get; set; }
    }
}