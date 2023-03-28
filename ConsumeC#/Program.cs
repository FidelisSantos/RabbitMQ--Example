using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;


var factory = new ConnectionFactory()
{
  HostName = "localhost",
  UserName = "admin",
  Password = "admin"
};
var connection = factory.CreateConnection();
var channel = connection.CreateModel();
{
  channel.QueueDeclare(queue: "Api_TS",
                       durable: true,
                       exclusive: false,
                       autoDelete: false,
                       arguments: null);

  var consumer = new EventingBasicConsumer(channel);
  consumer.Received += (model, ea) =>
  {
    var body = ea.Body.ToArray();
    var json = Encoding.UTF8.GetString(body);

    System.Threading.Thread.Sleep(1000);

    Console.WriteLine(json);
  };
  channel.BasicConsume(queue: "Api_TS",
                       autoAck: true,
                       consumer: consumer);

  Console.WriteLine(" Press [enter] to exit.");
  Console.ReadLine();
}

