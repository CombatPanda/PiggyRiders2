import React, { Component } from "react";
import AuthApi from "./LoginRegisterComponents/AuthApi.js";
import Cookies from "C:/Users/Lenovo/source/repos/SmartSaver/node_modules/js-cookie/src/js.cookie.js";

const Home = () => {
  const displayName = Home.name;
  const Auth = React.useContext(AuthApi);
  const handleOnClick = () => {
    Auth.setAuth(false);
    Cookies.remove("user");
  };
  return (
    <div>
      <button onClick={handleOnClick}> Logout </button>
    </div>
  );
}
export default Home;