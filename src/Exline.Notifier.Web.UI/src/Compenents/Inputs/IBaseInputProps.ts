import * as React from "react";

export interface IBaseInputProps {
    Value?: string,
    ClassName?: string,
    Id?: string,
    Name?: string,
    OnClick?:  React.MouseEventHandler<{}>,
    OnMouseOver?: React.MouseEventHandler<{}>,
    Background?:string,
    Color?:string,
    Height?:number,
    Witdh?:number

}