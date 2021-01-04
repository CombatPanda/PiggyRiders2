import React, { Component } from "react";
import AuthApi from "./LoginRegisterComponents/AuthApi.js";
import Cookies from "C:/Users/Veronika/source/repos/lauratumaite/SmartSaver/node_modules/js-cookie/src/js.cookie.js";

const Home = () => {
  const Auth = React.useContext(AuthApi);
  const handleOnClick = () => {
    Auth.setAuth(false);
    Cookies.remove("user");
  };
  return (
    <div>
      <h1>Hello, world!</h1>
      <p>Welcome to Smart saver!</p>
      <button onClick={handleOnClick}> Logout </button>
    </div>
  );
}
export default Home;
// export class Home extends Component {
//   static displayName = Home.name;

//     Home() {
//     const Auth = React.useContext(AuthApi);
//     const handleOnClick = () => {
//       Auth.setAuth(false);
//       Cookies.remove("user");
//     };
//     return (
//       <div>
//         <h1>Hello, world!</h1>
//         <p>Welcome to Smart saver!</p>
//         <button onClick={handleOnClick}> Logout </button>
//       </div>
//     );
//   } 
// }
