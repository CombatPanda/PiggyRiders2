import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import FetchSavingInfo from "./components/SavingComponents/FetchSavingInfo";
import SavingInfoDetails from "./components/SavingComponents/SavingInfoDetails";
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' exact component={Home} />
        <Route path='/SavingsManagerInformations' exact component={FetchSavingInfo} />
        <Route path="/SavingsManagerInformations/:id" exact component={SavingInfoDetails} />
      </Layout>
    );
  }
}
