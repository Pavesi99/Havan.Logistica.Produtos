using Domain.Interfaces.Integration;
using Domain.Message;
using Domain.Models;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Integration
{
    public class ProdutoMessageHandler : IProdutoMessageHandler
    { 
        private readonly IConnectionFactory   _factory;
        public ProdutoMessageHandler(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public void Publish(CatalogoProdutosMessage produto)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "catalogoProduto", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var produtoSerialized = JsonSerializer.Serialize(produto);
                byte[] body = Encoding.UTF8.GetBytes(produtoSerialized);

                channel.BasicPublish(exchange: "", routingKey: "catalogoProduto", basicProperties: null, body: body);
            }

        }
    }
}
