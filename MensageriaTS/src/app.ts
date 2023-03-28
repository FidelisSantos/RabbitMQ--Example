import express from "express";
import cors from "cors";
import MessageService from "./service/mensageriaService";

class App {
  public readonly app = express();
  private service = new MessageService("amqp://admin:admin@rabbitmq:5672");
  constructor() {
    this.app.use(express.json());

    this.app.use(cors());

    this.app.get("/", (req, res) => {
      res.status(200).send("Api Ts");
    });

    this.app.post("/", async (req, res) => {
      await this.service.sendMessage(JSON.stringify(req.body));
      res.send(req.body);
    });
  }

  public async consume() {
    await this.service.cosumeMessage();
  }
}

export default new App();
