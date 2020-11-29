import React, { Component } from 'react';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import './components/LoginRegisterComponents/LRApp.css';
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import { Home } from './components/Home';
import { Layout } from './components/Layout';
import SavingInfoApp from "./components/SavingComponents/SavingInfoApp";
import LRApp from "./components/LoginRegisterComponents/LRApp";
import SavingInfoDetails from "./components/SavingComponents/SavingInfoDetails";
import FetchExpensesManagerInfo from "./components/ExpensenesComponents/FetchExpensesManagerInfo";
import AddLimit from "./components/ExpensenesComponents/AddLimit";
import EditExpensesInfo from "./components/ExpensenesComponents/EditExpensesInfo";
import './custom.css'
import Login from "./components/LoginRegisterComponents/login.component";
import SignUp from "./components/LoginRegisterComponents/signup.component";


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
      <Route path="/log-in" excat component={Login} />
       <Route path="/sign-up" exact component={SignUp} />
        <Route exact path='/' exact component={Home} />
        <Route path="/SavingsManagerInformations/:id" component={SavingInfoDetails} />
        <Route path='/ExpensesManagerInformations' exact component={FetchExpensesManagerInfo} />
         <Route path="/ExpensesManagerInformations/add" excat component={AddLimit} />
         <Route path="/ExpensesManagerInformations/edit/:id" excat component={EditExpensesInfo} />
            <Route path='/SavingsManagerInformations' exact component={SavingInfoApp} />
            <Route path="/SavingsManagerInformations/:id" exact component={SavingInfoDetails} />
      </Layout>
    );
  }
}
