import React, { Component } from "react";
import './LRApp.css';
var token = "";

export default class Login extends Component {
  onSubmit(e) {

    const newUser = {
      email: this.refs.email.value,
      password: this.refs.password.value
    };

    this.getUser(newUser);
    e.preventDefault();
  }

  getUser(newUser) {
    fetch("https://localhost:44312/api/Login", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        Password: newUser.password,
        Email: newUser.email
      })
    }).then(response => {
      console.log(response);

      if (response.ok) {
        document.cookie = response;
        this.props.history.push("/SavingsManagerInformations");
      } else {
        console.log(response.ok);
        alert("Failed to login, try signing up");
        this.props.history.push("/log-in");
      }
    });
  }


  render() {
      return (
          <form onSubmit={this.onSubmit.bind(this)} >
            <div class="input-field">
          <p class = "bold_oblique">email
          <input
            type="email"
            name="email"
            ref="email"
            className="form-control"
            placeholder="enter email..."
            /></p>
        </div>

        <div class="input-field">
        <p class="bold_oblique"htmlFor="password">password
          <input
            className="input_color"
            type="password"
            name="password"
            ref="password"
            placeholder="enter password..."
        /></p>
        </div>

        <div className="form-group">
          <div className="custom-control custom-checkbox ">
            <input
              type="checkbox"
              className="custom-control-input"
              id="customCheck1"
            />
                      <label className="custom-control-label simple_oblique" htmlFor="customCheck1">remember me</label>
          </div>
        </div>

        <button type="submit" class="myButton">LOG IN</button>

        <p className="forgot-password text-center">
        <a href="/sign-up">SIGN UP</a>
        </p>

        <p className="forgot-password text-center">
        <a href="#">forgot password?</a>
        </p>
        </form>
    );
  }
}
