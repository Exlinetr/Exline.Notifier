import * as React from "react";
import { BaseComponent } from "../../BaseComponent";
import { IBaseInputProps } from "../IBaseInputProps";

interface IButtonProps extends IBaseInputProps {
    
}

export class Button extends BaseComponent<IButtonProps> {
    constructor() {
        super();
    }
    
    render() {
        return (
            <input type="button" 
            name={this.props.Name} 
            onClick={this.props.OnClick} 
            className={this.props.ClassName}
            id={this.props.Id} />
        );
    }
}
