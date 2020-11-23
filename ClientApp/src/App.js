import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import FetchRandomUser from "./components/FetchRandomUser";
import FetchSavingInfo from "./components/FetchSavingInfo";
import SavingInfoDetails from "./components/SavingInfoDetails";
import FetchExpensesManagerInfo from "./components/FetchExpensesManagerInfo";
import ExpensesInfoDetails from "./components/ExpensesInfoDetails";
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' exact component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/fetch-random' component={FetchRandomUser} />
        <Route path='/SavingsManagerInformations' exact component={FetchSavingInfo} />
        <Route path="/SavingsManagerInformations/:id" component={SavingInfoDetails} />
        <Route path='/ExpensesManagerInformations' exact component={FetchExpensesManagerInfo} />
        <Route path="/ExpensesManagerInformations/:id" component={ExpensesInfoDetails} />
      </Layout>
    );
  }
}
