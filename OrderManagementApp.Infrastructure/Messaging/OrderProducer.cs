using OrderManagementApp.Infrastructure.Messaging.Contracts;

namespace OrderManagementApp.Infrastructure.Messaging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

public class OrderProducer
{
    private readonly Task<IConnection> _connection;

    public OrderProducer()
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };

        _connection = factory.CreateConnectionAsync();
    }

    public void PublishOrderCreated(OrderCreatedMessage message)
    {
        
    }
}