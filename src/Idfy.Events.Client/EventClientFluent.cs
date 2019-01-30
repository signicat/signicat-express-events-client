using System;
using System.Threading.Tasks;
using Idfy.Events.Entities;
using Rebus.Config;
using Rebus.Logging;

namespace Idfy.Events.Client
{
    public static class EventClientFluent
    {
        /// <summary>
        /// Plugin - a logger which is compatible with Rebus. Read more here: https://github.com/rebus-org/Rebus/wiki/Logging
        /// </summary>
        /// <param name="eventClient"></param>
        /// <param name="loggerFactory"></param>
        /// <returns></returns>
        public static EventClient UseRebusCompatibleLogger(this EventClient eventClient, object loggerFactory)
        {
            if (loggerFactory is IRebusLoggerFactory factory)
                eventClient.RebusLoggerFactory = factory;
            
            if(loggerFactory != null)
                eventClient.LogToConsole = false;
            
            return eventClient;
        }

        /// <summary>
        /// Sets up a console logger in Rebus. You can only have one logger, so do not combine this with another logger
        /// </summary>
        /// <param name="eventClient"></param>
        /// <param name="logLevel"></param>
        /// <param name="logToConsole"></param>
        /// <returns></returns>
        public static EventClient LogToConsole(this EventClient eventClient, LogLevel logLevel = LogLevel.Debug, bool logToConsole = true)
        {
            var internalLogLevel = (Rebus.Logging.LogLevel)Enum.Parse(typeof(Rebus.Logging.LogLevel), logLevel.ToString());

            eventClient.LogToConsole = logToConsole;
            eventClient.LogLevel = internalLogLevel;
            
            if(logToConsole)
                eventClient.RebusLoggerFactory = null;
            
            return eventClient;
        }
        
        /// <summary>
        /// Subscribes to the specified event. 
        /// The <paramref name="eventHandler"/> method will be invoked with an event of type <typeparamref name="T"/>
        /// </summary>
        /// <param name="eventClient"></param>
        /// <param name="eventHandler"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static EventClient Subscribe<T>(this EventClient eventClient, Func<T, Task> eventHandler) where T : Event
        {
            if (eventHandler != null)
                eventClient.Subscribe<T>(eventHandler);
            return eventClient;
        }
        
        /// <summary>
        /// Subscribe to all raised events
        /// </summary>
        /// <param name="eventClient"></param>
        /// <param name="eventHandler"></param>
        /// <returns></returns>
        public static EventClient SubscribeToAllEvents(this EventClient eventClient, Func<Event, Task> eventHandler)
        {
            if (eventHandler != null)
                eventClient.SubscribeToAllEvents(eventHandler);
            return eventClient;
        }
     

        /// <summary>
        /// Start the event listener. It is important to call this function or the client will not listen to any events
        /// </summary>
        /// <param name="eventClient"></param>
        public static EventClient Start(this EventClient eventClient)
        {
            eventClient.Start();
            return eventClient;
        }

        /// <summary>
        /// Enables the use of a Rebus compatible logger using the RebusLogging configuration syntax, for example x.Serilog(new LoggerConfiguration().WriteTo.ColoredConsole().MinimumLevel.Debug()) 
        /// For more examples go to https://github.com/rebus-org/Rebus/wiki/Logging
        /// </summary>
        /// <param name="eventClient"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static EventClient AddRebusCompatibeLogger(this EventClient eventClient, Action<RebusLoggingConfigurer> config)
        {
            eventClient.AddRebusCompatibeLogger(config);
            return eventClient;
        }
    }
}