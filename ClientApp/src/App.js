import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import FetchRandomUser from "./components/FetchRandomUser";
import FetchSavingInfo from "./components/FetchSavingInfo";
import SavingInfoDetails from "./components/SavingInfoDetails";
import './custom.css'
import AddSavingInfo from "./components/AddSavingInfo";

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
        <Route path="/SavingsManagerInformations/:id" exact component={SavingInfoDetails} />
        <Route path="/SavingsManagerInformations/add" exact component={AddSavingInfo} />
      </Layout>
    );
  }
}
