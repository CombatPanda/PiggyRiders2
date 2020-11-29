import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import SavingInfoApp from "./components/SavingComponents/SavingInfoApp";
import SavingInfoDetails from "./components/SavingComponents/SavingInfoDetails";
import FetchSavingInfo from "./components/SavingComponents/FetchSavingInfo";
import FetchExpensesManagerInfo from "./components/ExpensenesComponents/FetchExpensesManagerInfo";
import AddLimit from "./components/ExpensenesComponents/AddLimit";
import EditExpensesInfo from "./components/ExpensenesComponents/EditExpensesInfo";
import './custom.css'
import { Header } from './components/BudgetManagerComponents/Header';
import { Balance } from './components/BudgetManagerComponents/Balance';
import { IncomeExpenses } from './components/BudgetManagerComponents/IncomeExpenses';
import { TransactionList } from './components/BudgetManagerComponents/TransactionList';
import { AddTransaction } from './components/BudgetManagerComponents/AddTransaction';
import { GlobalProvider } from './components/BMcontextAPI/GlobalState'
import './BMapp.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' exact component={Home} />
        <Route path='/SavingsManagerInformations' exact component={FetchSavingInfo} />
        <Route path="/SavingsManagerInformations/:id" component={SavingInfoDetails} />
        <Route path='/ExpensesManagerInformations' exact component={FetchExpensesManagerInfo} />
        <Route path="/ExpensesManagerInformations/add" excat component={AddLimit} />
        <Route path="/ExpensesManagerInformations/edit/:id" excat component={EditExpensesInfo} />
        <Route path='/SavingsManagerInformations' exact component={SavingInfoApp} />
        <Route path="/SavingsManagerInformations/:id" exact component={SavingInfoDetails} />

        <GlobalProvider>
        <Header />
            <div className="container">
                <Balance />
                <IncomeExpenses />
                <TransactionList />
                <AddTransaction />
            </div>
        </GlobalProvider>
      </Layout>
    );
  }
}

