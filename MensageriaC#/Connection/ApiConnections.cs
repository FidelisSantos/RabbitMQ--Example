using RabbitMQ.Client;

namespace MensageriaC_.Connection;
public class ApiConnections
{
  private ConnectionFactory rabbitMQ = new ConnectionFactory();

  public RabbitMQ.Client.IConnection CreateConnectionRabbitMQ()
  {
    rabbitMQ.UserName = "admin";
    rabbitMQ.Password = "admin";
    rabbitMQ.VirtualHost = "/";
    rabbitMQ.HostName = "rabbitmq";
    rabbitMQ.Port = 5672;

    return rabbitMQ.CreateConnection();
  }

}
