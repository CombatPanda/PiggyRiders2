import React, {Component } from 'react';
import './passValidation.css';
import './LRApp.css';

export default class SignUp extends React.Component {
    constructor() {
        super();
        this.state = {
          fields: {},
          errors: {}
        }
  
        this.handleChange = this.handleChange.bind(this);
        this.submituserRegistrationForm = this.submituserRegistrationForm.bind(this);
  
      };
  
      handleChange(e) {
        let fields = this.state.fields;
        fields[e.target.name] = e.target.value;
        this.setState({
          fields
        });
  
      }
  
      submituserRegistrationForm(e) {
        e.preventDefault();
        if (this.validateForm()) {
            const newUser = {
                username: this.refs.username.value,
                password: this.refs.password.value,   
                email: this.refs.email.value
            }
            this.addUser(newUser);
            let fields = {};
            fields["username"] = "";
            fields["email"] = "";
            fields["password"] = "";
            this.setState({fields:fields});
        }
  
      }
  
      validateForm() {
  
        let fields = this.state.fields;
        let errors = {};
        let formIsValid = true;
  
        if (!fields["username"]) {
          formIsValid = false;
          errors["username"] = "*please enter your username.";
        }
  
        if (typeof fields["username"] !== "undefined") {
          if (!fields["username"].match(/^[a-zA-Z0-9 ]*$/)) {
            formIsValid = false;
            errors["username"] = "*please enter alphabet characters or numbers only.";
          }
        }
  
        if (!fields["email"]) {
          formIsValid = false;
          errors["email"] = "*please enter your email.";
        }
  
        if (typeof fields["email"] !== "undefined") {
          //regular expression for email validation
          var pattern = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
          if (!pattern.test(fields["email"])) {
            formIsValid = false;
            errors["email"] = "*please enter valid email-ID.";
          }
        }

  
        if (!fields["password"]) {
          formIsValid = false;
          errors["password"] = "*please enter your password.";
        }
  
        if (typeof fields["password"] !== "undefined") {
          if (!fields["password"].match(/^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%&]).*$/)) {
            formIsValid = false;
            errors["password"] = "*please enter secure and strong password.";
          }
        }
  
        this.setState({
          errors: errors
        });
        return formIsValid;
  
  
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
           // <div id="main-registration-container">
            //id="register"
            <div>
                <form method="post" name="userRegistrationForm" onSubmit={this.submituserRegistrationForm} >
                    <div class="input-field">
               <p class="bold_oblique">username
               <input type="text" name="username" ref="username" value={this.state.fields.username} onChange={this.handleChange} className="form-control"
                                placeholder="enter username..." /></p>
                        </div>
                    <div className="errorMsg">{this.state.errors.username}</div>
                    <div class="input-field">
               <p class="bold_oblique">email
               <input type="text" name="email" ref="email" value={this.state.fields.email} onChange={this.handleChange} className="form-control"
               placeholder="enter email..."/>
                            <div className="errorMsg">{this.state.errors.email}</div></p></div>
                        <div class="input-field">
               <p class="bold_oblique">password
               <input type="password" name="password" ref="password" value={this.state.fields.password} onChange={this.handleChange} className="form-control"
               placeholder="enter password..."/>
                            <div className="errorMsg">{this.state.errors.password}</div></p></div>
               
                <button type="submit" class="button">
                        SIGN UP
            </button>
               </form>
           </div>
      // </div>

            //<input type="submit" className="button"  value="Register"/>
       
        )}
}