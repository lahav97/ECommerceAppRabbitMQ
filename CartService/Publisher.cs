using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using CartService.Models;

namespace CartService
{
    public class Publisher
    { 
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _hostName = "rabbitmq";
        private readonly string _exchangeName = "orderExchange";

        public Publisher()
        {
            var factory = new ConnectionFactory() { HostName = _hostName, UserName = "guest", Password = "guest" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Direct);
        }
        public void PublishMessage(Order message)
        {
            string routingKey = message.Status;
            var orderJson = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(orderJson);

            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(exchange: _exchangeName,
                routingKey: routingKey,
                basicProperties: null,
                body: body);

            Console.WriteLine($"[x] Sent orderId: {message.OrderId}, itemsNum: {message.Items.Count}");
        }
    }
}
