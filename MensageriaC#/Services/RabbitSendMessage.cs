using MensageriaC_.Model;
using MensageriaC_.Repository;

namespace MensageriaC_.Services;

class RabbitSendMessage
{
  private RabbiRepository repository = new RabbiRepository();
  public void SendMessage(RabbitMessage message) => repository.SendMessage(message);

}