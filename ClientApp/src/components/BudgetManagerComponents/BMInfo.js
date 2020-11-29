import React from 'react';
import { GlobalProvider } from '../BMcontextAPI/GlobalState';
import './BMapp.css';
import { addIncome } from './AddTransaction';
import { addExpenses } from './AddTransaction';
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
                <addIncome />
                <addExpenses />
            </div>
        </GlobalProvider>
    );
}

export default App;