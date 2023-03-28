using MensageriaC_.Model;
using MensageriaC_.Services;
using Microsoft.AspNetCore.Mvc;

namespace MensageriaC_.Controllers;

[ApiController]
[Route("message")]
public class ControllerMensageria : ControllerBase
{
  private RabbitSendMessage services;

  public ControllerMensageria()
  {
    services = new RabbitSendMessage();
  }

  [HttpGet]
  public IActionResult GetMessage() => Ok("Api C#");

  [HttpPost]
  public IActionResult PostMessage([FromBody] RabbitMessage message)
  {
    services.SendMessage(message);
    return Ok(message);
  }
}