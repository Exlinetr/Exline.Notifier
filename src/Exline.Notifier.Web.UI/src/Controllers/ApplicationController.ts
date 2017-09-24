import { Router, Request, Response, NextFunction } from "Express";
import { BaseController } from "./BaseController";


class AppplicationController extends BaseController {

    InitRoute(): void {
        this.Router.get("/", this.Index);
    }

    constructor() {
        super();
        this.InitRoute();
    }
    public Index(req: Request, res: Response, next: NextFunction) {
        res.send("application controller");
    }
}

export default new AppplicationController().Router;


