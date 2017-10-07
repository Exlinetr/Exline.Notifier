import * as http from "http";
import * as express from "express";
import * as bodyParser from "body-parser";
import * as logger from "morgan";
import * as path from "path";
import * as React from "React";
import { Router,match  } from 'react-router'
import { renderToString } from 'react-dom/server';
import { DefaultLayout } from "./Compenents/DefaultLayout";
import * as indexController from "./Controllers/IndexController";
import * as applicationController from "./Controllers/ApplicationController";
import * as RouteConfig from "./RouteConfig";
import { App } from "./App";

class Startup {

    private App: express.Application;
    private Server: http.Server;

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
        this.Server = http.createServer(this.App);
        this.Server.listen(this.GetPort());
        this.Server.on("error", this.OnError);
        this.Server.on("listening", function () {
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
        this.App.use("/react", function (req, res) {
            res.contentType("text/html; charset=utf-8");
            res.type(".html");
            var html = renderToString(
                <BrowserRouter>
                    <App />
                </BrowserRouter>
            );
            console.log(html);
            res.send(html);
        });
    }
    private GetPort() {
        return process.env.port || 8080
    }
}

const app = new Startup();
exports = app;