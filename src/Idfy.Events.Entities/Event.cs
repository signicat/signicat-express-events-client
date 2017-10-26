using System;

namespace Idfy.Events.Entities
{
    public abstract class Event
    {
        public Guid Id { get; protected set; }
        public EventType Type { get; set; }
        public abstract object RawPayload { get; }
    }

    public abstract class Event<T> : Event where T : class
    {
        protected Event(EventType type, T payload)
        {
            Id = Guid.NewGuid();
            Type = type;
            Payload = payload;
        }

        public T Payload { get; set; }
        public override object RawPayload => Payload;
    }
}
