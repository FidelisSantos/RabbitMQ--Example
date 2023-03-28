import RabbitmqServer from "../connection/rabbitmq-server";

class MessageService {
  private rabbiMq = new RabbitmqServer(this.uri);

  constructor(private readonly uri: string) {
    this.uri = uri;
  }

  async sendMessage(message: string) {
    await this.rabbiMq.start();
    await this.rabbiMq.publishInQueue("Api_TS", message);
    await this.rabbiMq.publishInExchage("amq.direct", "ts_route", message);
  }

  async cosumeMessage() {
    await this.rabbiMq.start();
    await this.rabbiMq.consume("ApiCsharpQueue", (message) =>
      console.log(message.content.toString())
    );
  }
}

export default MessageService;
