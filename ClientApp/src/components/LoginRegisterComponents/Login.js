import React, { Component, useRef } from "react";
import AuthApi from "./AuthApi";
import Cookies from "C:/Users/Lenovo/source/repos/SmartSaver/node_modules/js-cookie/src/js.cookie.js";

const Login = (e) => {

    const Auth = React.useContext(AuthApi);
    const inputEmailRef = useRef(null);
    const inputPasswordRef = useRef(null);

    const handleOnClick = (e) => {
        Fetch();

    };

    function Fetch() {
        var email = inputEmailRef.current.value;
        var password = inputPasswordRef.current.value;
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
            if (response.ok) {
                Auth.setAuth(true);
                Cookies.set("user", "loginTrue");
            } else {
                alert("Failed to login, try signing up");
            }
        }))
    }

    return (
        <form>
            <h3>Log In</h3>

            <div className="input-field">
                <p class="bold_oblique">email
                 <input
                        type="email"
                        name="email"
                        ref={inputEmailRef}
                        className="form-control"
                        placeholder="enter email..."
                    /></p>
            </div>
            <div className="input-field">
                <p class="bold_oblique" htmlFor="password">password
                 <input
                        className="input_color"
                        type="password"
                        name="password"
                        ref={inputPasswordRef}
                        placeholder="enter password..."
                    /></p>
            </div>

            <button onClick={handleOnClick.bind(this)} type="submit" className="myButton">
                LOG IN
    </button>
        </form>
    )
}
export default Login;