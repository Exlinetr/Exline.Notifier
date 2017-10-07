import React from "react";
import { Route,Switch } from "react-router";
import { LoginView } from "./Views/Login/Index";

export default (
    <Route path="/login" component={LoginView} />
);
