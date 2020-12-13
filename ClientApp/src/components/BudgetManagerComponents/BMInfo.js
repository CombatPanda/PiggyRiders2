import React from 'react';
import { GlobalProvider } from '../context/GlobalState';
import './BMapp.css';
import { AddTransaction } from './AddTransaction';
import { Balance } from './Balance';
import { IncomeExpenses } from './IncomeExpenses';
import { TransactionList } from './TransactionList';




function App() {
    return (
        <GlobalProvider>
            <div>
                <Balance />
                <IncomeExpenses />
                <TransactionList />
                <AddTransaction />
            </div>
        </GlobalProvider>
    );
}

export default App;