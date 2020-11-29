import React from 'react';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import './components/LoginRegisterComponents/LRApp.css';
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import SavingInfoApp from "./components/SavingComponents/SavingInfoApp";
import SavingInfoDetails from "./components/SavingComponents/SavingInfoDetails";
import FetchSavingInfo from "./components/SavingComponents/FetchSavingInfo";
import SavingInfoDetails from "./components/SavingComponents/SavingInfoDetails";
import FetchExpensesManagerInfo from "./components/ExpensenesComponents/FetchExpensesManagerInfo";
import AddLimit from "./components/ExpensenesComponents/AddLimit";
import EditExpensesInfo from "./components/ExpensenesComponents/EditExpensesInfo";
import './custom.css'

export default class App extends Component {
  static displayName = App.name;
import Login from "./components/LoginRegisterComponents/login.component";
import SignUp from "./components/LoginRegisterComponents/signup.component";

  render () {
    return (
      <Layout>
        <Route exact path='/' exact component={Home} />
        <Route path='/SavingsManagerInformations' exact component={FetchSavingInfo} />
        <Route path="/SavingsManagerInformations/:id" component={SavingInfoDetails} />
        <Route path='/ExpensesManagerInformations' exact component={FetchExpensesManagerInfo} />
         <Route path="/ExpensesManagerInformations/add" excat component={AddLimit} />
         <Route path="/ExpensesManagerInformations/edit/:id" excat component={EditExpensesInfo} />
            <Route exact path='/' exact component={Home} />
            <Route path='/SavingsManagerInformations' exact component={SavingInfoApp} />
            <Route path="/SavingsManagerInformations/:id" exact component={SavingInfoDetails} />
      </Layout>
function App() {
  return (<Router>
    <div className="App">
      <nav className="navbar navbar-expand-lg navbar-light fixed-top">
        <div className="container">
          <Link className="navbar-brand" to={"/log-in"}>SmartSaver</Link>
          <div className="collapse navbar-collapse" id="navbarTogglerDemo02">
            <ul className="navbar-nav ml-auto">
              <li className="nav-item">
                <Link className="nav-link" to={"/log-in"}>Login</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to={"/sign-up"}>Sign up</Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>

      <div className="auth-wrapper">
        <div className="auth-inner">
          <Switch>
            <Route exact path='/' component={Login} />
            <Route path="/log-in" component={Login} />
            <Route path="/sign-up" component={SignUp} />
          </Switch>
        </div>
      </div>
    </div></Router>
  );
}
}
export default App;
