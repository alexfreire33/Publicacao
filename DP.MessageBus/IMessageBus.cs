using EasyNetQ;

namespace DP.MessageBus
{
    public interface IMessageBus : IDisposable
    {

        bool IsConnected { get; }
        IAdvancedBus AdvancedBus { get; }

        void Publish<T>(T message) where T: class;

        Task PublishAsync<T>(T message) where T : class;
        void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class;

        
    }

}
