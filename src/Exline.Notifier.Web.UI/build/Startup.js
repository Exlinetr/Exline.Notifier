(function (factory) {
    if (typeof module === "object" && typeof module.exports === "object") {
        var v = factory(require, exports);
        if (v !== undefined) module.exports = v;
    }
    else if (typeof define === "function" && define.amd) {
        define(["require", "exports", "http", "express", "body-parser", "path", "React", "react-router-dom", "react-dom/server", "./Controllers/IndexController", "./Controllers/ApplicationController", "./App"], factory);
    }
})(function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var http = require("http");
    var express = require("express");
    var bodyParser = require("body-parser");
    var path = require("path");
    var React = require("React");
    var react_router_dom_1 = require("react-router-dom");
    var server_1 = require("react-dom/server");
    var indexController = require("./Controllers/IndexController");
    var applicationController = require("./Controllers/ApplicationController");
    var App_1 = require("./App");
    var Startup = /** @class */ (function () {
        function Startup() {
            this.Init();
        }
        Startup.prototype.Init = function () {
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
            this.App.use("/react", function (req, res) {
                res.contentType("text/html; charset=utf-8");
                res.type(".html");
                var html = server_1.renderToString(React.createElement(react_router_dom_1.BrowserRouter, null,
                    React.createElement(App_1.App, null)));
                console.log(html);
                res.send(html);
            });
        };
        Startup.prototype.GetPort = function () {
            return process.env.port || 8080;
        };
        return Startup;
    }());
    var app = new Startup();
    exports = app;
});
