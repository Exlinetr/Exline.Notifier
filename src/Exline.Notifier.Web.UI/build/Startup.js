"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http = require("http");
var express = require("express");
var bodyParser = require("body-parser");
var reactViewRender = require("express-react-views");
var indexController = require("./Controllers/IndexController");
var applicationController = require("./Controllers/ApplicationController");
var Startup = /** @class */ (function () {
    function Startup() {
        this.Init();
    }
    Startup.prototype.Init = function () {
        this.App = express();
        this.App.set("view engine", "jsx");
        this.App.engine('jsx', reactViewRender.createEngine());
        this.Middleware();
        this.Routes();
        this.server = http.createServer(this.App);
        this.server.listen(this.GetPort());
        this.server.on("error", this.OnError);
        this.server.on("listening", function () {
            console.log("server listening");
        });
    };
    Startup.prototype.OnError = function (error) {
        console.log(error.message);
    };
    Startup.prototype.Middleware = function () {
        this.App.use(bodyParser.json());
        this.App.use(bodyParser.urlencoded({ extended: false }));
    };
    Startup.prototype.Routes = function () {
        this.App.use('/Index', indexController.default);
        ;
        this.App.use('/Application/', applicationController.default);
    };
    Startup.prototype.GetPort = function () {
        return process.env.port || 8080;
    };
    return Startup;
}());
var app = new Startup();
exports = app;
