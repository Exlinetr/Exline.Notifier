import * as http from "http";
import * as express from "express";
import * as bodyParser from "body-parser";
import * as logger from "morgan";
import * as path from "path";
import { renderToString } from 'react-dom/server';
import { matchPath, Router } from 'react-router';
import * as indexController from "./Controllers/IndexController";
import * as applicationController from "./Controllers/ApplicationController";

class Startup {

    private App: express.Application;
    private server: http.Server;

    constructor() {
        this.Init();
    }

    private Init(): void {
        this.App = express();
        this.App.set('view engine', 'ejs');
        this.App.set('views', path.join(__dirname, 'views'));
        // this.App.set("view engine","jsx");
        // this.App.engine('jsx', reactViewRender.createEngine());
        this.Middleware();
        this.Routes();
        this.server = http.createServer(this.App);
        this.server.listen(this.GetPort());
        this.server.on("error", this.OnError);
        this.server.on("listening", function () {
            console.log("server listening");
        });
    }
    protected OnError(error: NodeJS.ErrnoException): void {
        console.log(error.message);
    }
    private Middleware(): void {
        this.App.use(bodyParser.json());
        this.App.use(bodyParser.urlencoded({ extended: false }));
    }

    private Routes(): void {
        this.App.use('/Index', indexController.default);;
        this.App.use('/Application/', applicationController.default);
    }
    private GetPort() {
        return process.env.port || 8080
    }
}

const app = new Startup();
exports = app;