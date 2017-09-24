import { Router, Request, Response } from "express";

export abstract class BaseController {
    public Router: Router;

    constructor() {
        this.Router = Router();
    }
    abstract InitRoute():void;
}