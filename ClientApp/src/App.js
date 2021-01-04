import React, { Component } from 'react';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import './components/LoginRegisterComponents/LRApp.css';
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import { Home } from './components/Home';
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
import Leaderboard from "./components/LeaderboardComponents/Leaderboard";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
       <Route path="/" excat component={Login} />
            <Route path="/sign-up" exact component={SignUp} />
        <Route path='/ExpensesManagerInformations' exact component={FetchExpensesManagerInfo} />
        <Route path="/ExpensesManagerInformations/add" excat component={AddLimit} />
        <Route path="/ExpensesManagerInformations/edit/:id" excat component={EditExpensesInfo} />
        <Route path='/SavingsManagerInformations' exact component={SavingInfoApp} />
        <Route path="/SavingsManagerInformations/:id" exact component={SavingInfoDetails} />
        <Route path="/BMInfo" exact component={BMInfo} />
        <Route path="/BMInfo/:id" exact component={BMInfo} />
        <Route path="/Challenges" exact component={Challenges} />
        <Route path="/Leaderboard" exact component={Leaderboard} />
      </Layout>
    );
  }
}

