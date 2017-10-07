import * as React from "React";
import { BaseComponent } from "../BaseComponent";

export class Header extends BaseComponent {

    props: {
        MenuItems?: Array<MenuItem>;
        IsLogin?: Boolean;
    }

    constructor() {
        super();
    }

    render() {
        return (
            <div>
            </div>
        );
    }
}