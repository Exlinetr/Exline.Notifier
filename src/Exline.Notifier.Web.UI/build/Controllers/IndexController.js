var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
(function (factory) {
    if (typeof module === "object" && typeof module.exports === "object") {
        var v = factory(require, exports);
        if (v !== undefined) module.exports = v;
    }
    else if (typeof define === "function" && define.amd) {
        define(["require", "exports", "./BaseController"], factory);
    }
})(function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var BaseController_1 = require("./BaseController");
    var IndexController = /** @class */ (function (_super) {
        __extends(IndexController, _super);
        function IndexController() {
            var _this = _super.call(this) || this;
            _this.InitRoute();
            return _this;
        }
        IndexController.prototype.InitRoute = function () {
            this.Router.get("/", this.Index);
        };
        IndexController.prototype.Index = function (req, res, next) {
            res.send("index controller");
        };
        return IndexController;
    }(BaseController_1.BaseController));
    exports.default = new IndexController().Router;
});
