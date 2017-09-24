import * as React from "React";
import * as Header from "./Header/Header";

export class DefaultLayout extends React.Component {

    render() {
        return (
            <html>
                <head>
                    <title>{this.props.title}</title>
                </head>
                <body>
                    <Header></Header>
                    {this.props.children}
                </body>
            </html>
        );
    }
}

exports = DefaultLayout;