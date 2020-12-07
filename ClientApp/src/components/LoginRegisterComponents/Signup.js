import React, {Component } from 'react';
//import './passValidation.css';

export default class SignUp extends React.Component {

    onSubmit(e) {
    const newUser = {
        username: this.refs.username.value,
        password: this.refs.password.value,   
        email: this.refs.email.value
    }
    this.addUser(newUser);
    e.preventDefault();
}

addUser(newUser) {
    fetch('https://localhost:44312/api/UserInformations', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            Username: newUser.username,
            Password: newUser.password,
            Email: newUser.email 
        })
    }).then(response => {
        if (response.ok) {
          alert("Successfully registered, you can log in")
          this.props.history.push("/log-in");
        }
        else{
          alert("Failed to register this email or username is taken, try loging in");
          this.props.history.push("/log-in");
        }
      });
    
}
    render() {
        return (
            <form onSubmit={this.onSubmit.bind(this)}>
                <h3>Sign Up</h3>

                <div className="imput-field">
                    <label htmlFor="username">Username</label>
                    <input type="text" name = "username"  ref="username"  placeholder="Username" />
                </div>

                <div className="imput-field">
                    <label htmlFor="password">Password</label>
                    <input type="password"  name = "password" ref="password"  placeholder="Enter password" />
                </div>

                <div className="imput-field">
                    <label htmlFor="email">Email address</label>
                    <input type="email" name = "email" ref="email"  placeholder="Enter email" />
                </div>

                <button type="submit" className="btn btn-primary btn-block">Sign Up</button>
                <p className="forgot-password text-right">
                    Already registered <a href="#">sign in?</a>
                </p>
            </form>
            
        );
    }
}