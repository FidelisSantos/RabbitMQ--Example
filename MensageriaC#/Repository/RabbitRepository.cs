using MensageriaC_.Model;
using MensageriaC_.Connection;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client;

namespace MensageriaC_.Repository;

class RabbiRepository
{
  public void SendMessage(RabbitMessage message)
  {
    var apiConnections = new ApiConnections();
    var conn = apiConnections.CreateConnectionRabbitMQ();
    var channel = conn.CreateModel();
    channel.QueueDeclare(queue: "ApiCsharpQueue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
    string json = JsonSerializer.Serialize(message);
    var bodyMessage = Encoding.UTF8.GetBytes(json);

    channel.BasicPublish(exchange: "",
                          routingKey: "ApiCsharpQueue",
                          basicProperties: null,
                          body: bodyMessage);
  }
}