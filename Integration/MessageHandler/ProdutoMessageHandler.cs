using Domain.Models;
using Infra.CrossCutting.Dto;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Integration
{
    public class ProdutoMessageHandler
    {
        public void Publish(CatalogoProdutosMessage produto)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
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
