import React, { Component } from "react";
import Logo from "../piggy.gif";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
        <div>
            <img src={Logo} width='500' />
        <h1>Hello, world!</h1>
        <p>Welcome to Smart saver!</p>
      </div>
    );
  }
}
