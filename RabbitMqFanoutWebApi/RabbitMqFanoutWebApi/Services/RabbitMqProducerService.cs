using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMqFanoutWebApi.Services
{
    public class RabbitMqProducerService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string ExchangeName = "fanout_exchange";

        public RabbitMqProducerService(IConfiguration configuration)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(configuration["RabbitMq:Uri"])
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Fanout);
        }

        public Task SendMessageAsync(string message)
        {
            var body = Encoding.UTF8.GetBytes($"{message} - {DateTime.Now:T}");
            _channel.BasicPublish(exchange: ExchangeName, routingKey: "", body: body);
            return Task.CompletedTask;
        }
    }
}
