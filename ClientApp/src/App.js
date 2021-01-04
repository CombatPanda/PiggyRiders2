import React, { Component } from 'react';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter as Router, Switch, Route, Link, Redirect } from "react-router-dom";
import Home from './components/Home.js';
import { Layout } from './components/Layout';
import SavingInfoApp from "./components/SavingComponents/SavingInfoApp";
import SavingInfoDetails from "./components/SavingComponents/SavingInfoDetails";
import FetchExpensesManagerInfo from "./components/ExpensenesComponents/FetchExpensesManagerInfo";
import AddLimit from "./components/ExpensenesComponents/AddLimit";
import EditExpensesInfo from "./components/ExpensenesComponents/EditExpensesInfo";
import './custom.css'
import BMInfo from "./components/BudgetManagerComponents/BMInfo";
import Login from "./components/LoginRegisterComponents/Login";
import SignUp from "./components/LoginRegisterComponents/Signup";
import Challenges from "./components/ChallangesComponents/Challenge";
import AuthApi from "./components/LoginRegisterComponents/AuthApi";
import Cookies from "C:/Users/Lenovo/source/repos/SmartSaver/node_modules/js-cookie/src/js.cookie.js";
import Leaderboard from "./components/LeaderboardComponents/Leaderboard";



function App() {
  const [auth, setAuth] = React.useState(false);
  const readCookie = () =>{
    const user = Cookies.get("user");
    if (user){
      setAuth(true);
    }
  }
  React.useEffect(()=>{
    readCookie();
  }, [])


  return(
    <div>
      <AuthApi.Provider value = {{auth, setAuth}}>
    <Router>
    <Routes/>
    </Router>
      </AuthApi.Provider>
  </div>
  )
}

const Routes = () => {
  const Auth = React.useContext(AuthApi)
    return (
      <Layout>
    <Switch>
        <ProtectedLogin path="/log-in" excat component={Login} auth = {Auth.auth}/>
        <Route path="/sign-up" exact component={SignUp} />
        <Route exact path='/' exact component={Home} />
        <ProtectedRoutes path='/ExpensesManagerInformations' auth = {Auth.auth} exact component={FetchExpensesManagerInfo} />
        <ProtectedRoutes path="/ExpensesManagerInformations/add" auth = {Auth.auth} excat component={AddLimit} />
        <ProtectedRoutes path="/ExpensesManagerInformations/edit/:id" auth = {Auth.auth} excat component={EditExpensesInfo} />
        <ProtectedRoutes path='/SavingsManagerInformations' auth = {Auth.auth} exact component={SavingInfoApp} />
        <ProtectedRoutes path="/SavingsManagerInformations/:id" auth = {Auth.auth} exact component={SavingInfoDetails} />
        <ProtectedRoutes path="/BMInfo" auth = {Auth.auth} exact component={BMInfo} />
        <ProtectedRoutes path="/BMInfo/:id" auth = {Auth.auth} exact component={BMInfo} />
        <ProtectedRoutes path="/Challenges" auth = {Auth.auth} exact component={Challenges} />
        <ProtectedRoutes path="/Leaderboard"  auth = {Auth.auth} exact component={Leaderboard} />
            </Switch>
</Layout>
        )
}

const ProtectedRoutes = ({auth, component:Component, ...rest}) =>{
  return(
    <Route
    {...rest}
    render = {() => auth? (
      <Component/>
    ):
  (
    <Redirect to = "/log-in"></Redirect>
  )
}
    />
  )
}

const ProtectedLogin = ({auth, component:Component, ...rest}) =>{
  return(
    <Route
    {...rest}
    render = {() => !auth? (
      <Component/>
    ):
  (
    <Redirect to = "/"></Redirect>
  )
}
    />
  )
}
 
export default App;

