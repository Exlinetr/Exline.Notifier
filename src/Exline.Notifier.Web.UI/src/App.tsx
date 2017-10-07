import * as React from "react";
import { DefaultLayout } from "./Compenents/DefaultLayout";
import * as RouteConfig from "./RouteConfig";

export class App extends React.Component {

    constructor() {
        super();
    }
    render() {
        return (
            <DefaultLayout Title="Test App" />
        );
    }
}