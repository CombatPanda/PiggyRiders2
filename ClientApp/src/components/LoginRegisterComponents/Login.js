import React, { Component } from "react";

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
        <h3>Log In</h3>

        <div className="imput-field">
          <label>Email address</label>
          <input
            type="email"
            name="email"
            ref="email"
            className="form-control"
            placeholder="Enter email"
          />
        </div>

        <div className="imput-field">
          <label htmlFor="password">Password</label>
          <input
            type="password"
            name="password"
            ref="password"
            placeholder="Enter password"
          />
        </div>

        <div className="form-group">
          <div className="custom-control custom-checkbox">
            <input
              type="checkbox"
              className="custom-control-input"
              id="customCheck1"
            />
            <label className="custom-control-label" htmlFor="customCheck1">
              Remember me
            </label>
          </div>
        </div>

        <button type="submit" className="btn btn-primary btn-block">
          Submit
        </button>
        <p className="forgot-password text-right">
          Forgot <a href="#">password?</a>
        </p>
      </form>
    );
  }
}
