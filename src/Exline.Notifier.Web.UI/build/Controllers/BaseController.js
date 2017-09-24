"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var express_1 = require("express");
var BaseController = /** @class */ (function () {
    function BaseController() {
        this.Router = express_1.Router();
    }
    return BaseController;
}());
exports.BaseController = BaseController;
