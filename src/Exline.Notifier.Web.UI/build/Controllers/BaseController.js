(function (factory) {
    if (typeof module === "object" && typeof module.exports === "object") {
        var v = factory(require, exports);
        if (v !== undefined) module.exports = v;
    }
    else if (typeof define === "function" && define.amd) {
        define(["require", "exports", "express"], factory);
    }
})(function (require, exports) {
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
});
