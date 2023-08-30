using EasyNetQ;
using Polly;
using RabbitMQ.Client.Exceptions;

namespace DP.MessageBus;

public class MessageBus : IMessageBus
{
    private IBus _bus;
    private IAdvancedBus _advancedBus;

    private readonly string _connectionString;
    public MessageBus(string connectionString)
    {
        _connectionString = connectionString;
        TryConnect();
    }

    public void Publish<T>(T message) where T : class
    {
        TryConnect();
        _bus.Publish(message);
    }


    public bool IsConnected => _bus?.IsConnected ?? false;
    public IAdvancedBus AdvancedBus => _bus?.Advanced;


    public async Task PublishAsync<T>(T message) where T : class
    {
        TryConnect();
        await _bus.PublishAsync(message)
            .ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        Console.WriteLine("Inclusão na fila completo");
                    }
                    else if (task.IsFaulted)
                    {
                        Console.WriteLine("fahou ao incluir na fila rabbitmq");
                    }
                });
    }

    public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
    {
        TryConnect();
        _bus.SubscribeAsync(subscriptionId, onMessage);
    }
   
    private void TryConnect()
    {
        if (IsConnected) return;

        var policy = Policy.Handle<EasyNetQException>()
            .Or<BrokerUnreachableException>()
            .WaitAndRetry(3, retryAttempt =>
                TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        policy.Execute(() =>
        {
            _bus = RabbitHutch.CreateBus(_connectionString);
            _advancedBus = _bus.Advanced;
            _advancedBus.Disconnected += OnDisconnect;
        });
    }

    private void OnDisconnect(object s, EventArgs e)
    {
        var policy = Policy.Handle<EasyNetQException>()
            .Or<BrokerUnreachableException>()
            .RetryForever();

        policy.Execute(TryConnect);
    }

    public void Dispose()
    {
        _bus.Dispose();
    }
}