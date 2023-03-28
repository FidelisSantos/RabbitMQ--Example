import express from "express";
import App from "./app";

class Server {
  private PORT = 4000;
  private HOST = "0.0.0.0";
  constructor(private readonly app: express.Application) {
    this.app = app;
    this.app.listen(this.PORT, this.HOST, () =>
      console.log(`listening on port ${this.PORT}`)
    );
  }

  async consume() {
    return App.consume();
  }
}

new Server(App.app);
App.consume();
