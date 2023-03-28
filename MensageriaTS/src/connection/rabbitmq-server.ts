import { Connection, Channel, connect, Message, ConsumeMessage } from "amqplib";

class RabbitmqServer {
  private conn?: Connection;
  private channel?: Channel;

  constructor(private uri: string) {}

  async start() {
    this.conn = await connect(this.uri);
    this.channel = await this.conn.createChannel();
  }

  async publishInQueue(queue: string, message: string) {
    return this.channel?.sendToQueue(queue, Buffer.from(message));
  }

  async publishInExchage(exchage: string, routingKey: string, message: string) {
    return this.channel?.publish(exchage, routingKey, Buffer.from(message));
  }

  async consume(queue: string, callback: (message: Message) => void) {
    return this.channel?.consume(queue, (message) => {
      callback(message as ConsumeMessage);
      this.channel?.ack(message as ConsumeMessage);
    });
  }
}

export default RabbitmqServer;
