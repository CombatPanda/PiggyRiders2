import React from 'react';
import { GlobalProvider } from '../BMcontextAPI/GlobalState';
import './BMapp.css';
import { Balance } from './Balance';
import { IncomeExpenses } from './IncomeExpenses';
import { TransactionList } from './TransactionList';
import { AddTransaction } from './AddTransaction';;


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