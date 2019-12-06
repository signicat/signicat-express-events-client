using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Idfy.Events.Entities;
using NUnit.Framework;

namespace Idfy.Events.Tests
{
    public class EventTypeTests
    {
        /// <summary>
        /// Every <see cref="EventType"/> should have one and only one implementing class.
        /// </summary>
        [Test]
        public void EventType_should_have_one_implementing_class()
        {
            var errors = new List<KeyValuePair<Exception, string>>();

            var dictionary = new Dictionary<EventType, Type>();

            // Enumerate all classes implementing Event
            foreach (var evType in Assembly.GetAssembly(typeof(Event)).GetTypes()
                .Where(t => !t.IsAbstract && typeof(Event).IsAssignableFrom(t)))
            {
                try
                {
                    var instance = InstantiateEvent(evType);

                    if (dictionary.TryGetValue(instance.Type, out var existingType))
                    {
                        var error = $"EventType {instance.Type} has multiple implementing classes: {evType.FullName} and {existingType.FullName}";
                        errors.Add(new KeyValuePair<Exception, string>(null, error));
                    }
                    dictionary[instance.Type] = evType;
                }
                catch (Exception ex)
                {
                    errors.Add(new KeyValuePair<Exception, string>(ex, $"Failed to instantiate event: {evType.FullName}"));
                }
            }

            // Find any missing EventTypes
            foreach (var evType in Enum.GetValues(typeof(EventType)).Cast<EventType>())
            {
                if (!dictionary.ContainsKey(evType))
                {
                    var error = $"EventType {evType} has no implementing class";
                    errors.Add(new KeyValuePair<Exception, string>(null, error));
                }
            }

            for (var i = 0; i < errors.Count; i++)
            {
                var error = errors[i];
                TestContext.Error.WriteLine($"Error #{i + 1}:");
                TestContext.Error.WriteLine(error.Value);
                if (error.Key != null)
                    TestContext.Error.WriteLine(error.Key.ToString());
            }

            Assert.IsEmpty(errors);
        }

        private static Event InstantiateEvent(Type eventType)
        {
            var constructors = eventType.GetConstructors().OrderBy(c => c.GetParameters().Length).ToList();
            var exceptions = new List<Exception>();
            foreach (var ctor in constructors)
            {
                try
                {
                    var parameters = ctor.GetParameters().Select(p =>
                        p.ParameterType.IsValueType ? Activator.CreateInstance(p.ParameterType) : null).ToArray();
                    var instance = ctor.Invoke(parameters) as Event;
                    return instance;
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            throw new AggregateException($"Failed to instantiate event of class {eventType.FullName}", exceptions);
        }
    }
}