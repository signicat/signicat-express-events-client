# Idfy Events Client

Subscribe to and handle events that are raised when something happens in your account.

You can read more about the various events in our [documentation](https://developer.idfy.io/docs).

## Example

This example shows how to set up the client and subscribe to events. We have set up our subscriptions with one handler that will trigger on allevents that are raised, and one handler that only triggers for the `DocumentCreated` event. 

```csharp
class Program
{
    private const string ClientId = "";
    private const string ClientSecret = "";

    static void Main(string[] args)
    {
        var client = EventClient.Setup(ClientId, ClientSecret)
            .LogToConsole()
            .SubscribeToAllEvents(EventHandler)
            .Subscribe<DocumentCreatedEvent>(DocumentCreatedEventHandler)
            .Start();

        Console.ReadLine();
        client?.Dispose();
    }
    
    private static Task EventHandler(Event evt)
    {
        if (evt.Type == EventType.DocumentCreated)
        {
            var payload = evt.RawPayload as DocumentCreatedPayload;
            Console.WriteLine($"A new document with ID {payload?.DocumentId} was created.");
        }

        return Task.FromResult(0);
    }

    private static Task DocumentCreatedEventHandler(DocumentCreatedEvent evt)
    {
        Console.WriteLine($"A new document with ID {evt.Payload.DocumentId} was created.");
        return Task.FromResult(0);
    }
}
```
