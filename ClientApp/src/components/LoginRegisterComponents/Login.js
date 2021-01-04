import React, { Component, useRef } from "react";
import AuthApi from "./AuthApi";
import Cookies from "C:/Users/Veronika/source/repos/lauratumaite/SmartSaver/node_modules/js-cookie/src/js.cookie.js";

 const Login = (e) =>{

  const Auth = React.useContext(AuthApi);
  const inputEmailRef = useRef(null);
  const inputPasswordRef = useRef(null);

  const handleOnClick = (e) => {
    console.log(inputPasswordRef.current.value + " , " + inputEmailRef.current.value);
    console.log("bandom Fetchint");
    Fetch();

  };

  function Fetch(){
    var email =  inputEmailRef.current.value;
    var password = inputPasswordRef.current.value;
    console.log("vyksta Fetchinimas");
    console.log(email, password);
    return (fetch("https://localhost:44312/api/Login", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        Password: password,
        Email: email
      })
    }).then(response => {
      console.log(response);
      if (response.ok) {
        Auth.setAuth(true);
        Cookies.set ("user", "loginTrue");
        //this.props.history.push("/SavingsManagerInformations");
      } else {
        console.log(response.ok);
        alert("Failed to login, try signing up");
        //this.props.history.push("/log-in");
      } 
    }))
  }

  return(
    <form>
    <h3>Log In</h3>

    <div className="input-field">
      <label>Email address</label>
      <input
        type="email"
        name="email"
        ref = {inputEmailRef}
        className="form-control"
        placeholder="Enter email"
      />
    </div>

    <div className="input-field">
      <label htmlFor="password">Password</label>
      <input
        type="password"
        name="password"
        ref = {inputPasswordRef}
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

    <button  onClick = { handleOnClick.bind(this)} type="submit" className="btn btn-primary btn-block">
      Submit
    </button>
    <p className="forgot-password text-right">
      Forgot <a href="#">password?</a>
    </p>
  </form>
)
}
export default Login;

// export default class login extends Component {
  // onSubmit(e) {
  //   const newUser = {
  //     email: this.refs.email.value,
  //     password: this.refs.password.value
  //   };

  //   this.getUser(newUser);
  //   e.preventDefault();
  // }

  // getUser(newUser) { 
  //   const Auth = React.useContext(AuthApi)
  //   fetch("https://localhost:44312/api/Login", {
  //     method: "POST",
  //     headers: {
  //       Accept: "application/json",
  //       "Content-Type": "application/json"
  //     },
  //     body: JSON.stringify({
  //       Password: newUser.password,
  //       Email: newUser.email
  //     })
  //   }).then(response => {
  //     console.log(response);

  //     if (response.ok) {
  //       //document.cookie = response;
  //       Auth.setAuth(true);
  //       console.log("loginas sekmingas" + Auth.auth);
  //       Cookies.set ("user", "loginTrue");
  //       this.props.history.push("/SavingsManagerInformations");
  //     } else {
  //       console.log(response.ok);
  //       alert("Failed to login, try signing up");
  //       this.props.history.push("/log-in");
  //     }
  //   });
  // }


//   render() {
//     return (
//       <form >
//         <h3>Log In</h3>

//         <div className="imput-field">
//           <label>Email address</label>
//           <input
//             type="email"
//             name="email"
//             ref="email"
//             className="form-control"
//             placeholder="Enter email"
//           />
//         </div>

//         <div className="imput-field">
//           <label htmlFor="password">Password</label>
//           <input
//             type="password"
//             name="password"
//             ref="password"
//             placeholder="Enter password"
//           />
//         </div>

//         <div className="form-group">
//           <div className="custom-control custom-checkbox">
//             <input
//               type="checkbox"
//               className="custom-control-input"
//               id="customCheck1"
//             />
//             <label className="custom-control-label" htmlFor="customCheck1">
//               Remember me
//             </label>
//           </div>
//         </div>

//         <button onClick = {handleOnClick} type="submit" className="btn btn-primary btn-block">
//           Submit
//         </button>
//         <p className="forgot-password text-right">
//           Forgot <a href="#">password?</a>
//         </p>
//       </form>
//     );
//   }
// }
