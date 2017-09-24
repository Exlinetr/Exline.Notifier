import { Router, Request, Response, NextFunction } from "express";
import * as React from "React";
import { BaseController } from "./BaseController";


class IndexController extends BaseController {

    InitRoute(): void {
        this.Router.get("/", this.Index);
    }

    constructor() {
        super();
        this.InitRoute();
    }
    public Index(req: Request, res: Response, next: NextFunction): void {
        res.send("index controller");
    }
}

export default new IndexController().Router;