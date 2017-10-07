import * as React from "React";
import { BaseComponent } from "./BaseComponent";
import { Header } from "./Header/Index";
import { MenuItem } from "./Header/MenuItem";
import {SlideBarMenu} from "./SlideBarMenu/Index";


interface IDefaultLayoutProps {

}

export class DefaultLayout extends BaseComponent {
    public MenuItems: Array<MenuItem>;
    public Body: BaseComponent;

    props: {
        Title?: string,
    }

    constructor() {
        super();
        this.MenuItems = new Array<MenuItem>();
        this.MenuItems.push(new MenuItem("Menu1", "#"));
        this.MenuItems.push(new MenuItem("Menu2", "#"));
    }

    render() {
        return (
            <html>
                <head>
                    <meta charSet="utf-8" />
                    <title>{this.props.Title}</title>
                    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
                    <meta content="width=device-width, initial-scale=1" name="viewport" />
                    <meta content="Preview page of Metronic Admin Theme #1 for statistics, charts, recent events and reports" name="description" />
                    <meta content="" name="author" />
                    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
                    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
                    <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
                    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
                    <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
                    <link href="../assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css" rel="stylesheet" type="text/css" />
                    <link href="../assets/global/plugins/morris/morris.css" rel="stylesheet" type="text/css" />
                    <link href="../assets/global/plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet" type="text/css" />
                    <link href="../assets/global/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" />
                    <link href="../assets/global/css/components.min.css" rel="stylesheet" id="style_components" type="text/css" />
                    <link href="../assets/global/css/plugins.min.css" rel="stylesheet" type="text/css" />
                    <link href="../assets/layouts/layout/css/layout.min.css" rel="stylesheet" type="text/css" />
                    <link href="../assets/layouts/layout/css/themes/darkblue.min.css" rel="stylesheet" type="text/css" id="style_color" />
                    <link href="../assets/layouts/layout/css/custom.min.css" rel="stylesheet" type="text/css" />
                    <link rel="shortcut icon" href="favicon.ico" />
                </head>
                <body>
                    <SlideBarMenu />
                    {this.Body}
                </body>
            </html>
        );
    }
}
