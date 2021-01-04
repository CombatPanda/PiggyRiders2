import React, { createContext, useReducer } from 'react';
import AppReducer from './AppReducer';

// Initial state
const initialState = {
    transactions: [],
    incomes: 0,
    expenses: 0,
    balance: ''
}

// Create context
export const GlobalContext = createContext(initialState);

// Provider component
export const GlobalProvider = ({ children }) => {
    const [state, dispatch] = useReducer(AppReducer, initialState);

    // Actions
    async function getTransactions() {
        const data = await fetch('https://localhost:44312/api/UserBudgets');
        const response = await data.json();
        dispatch({
            type: 'GET_TRANSACTION',
            payload: response
        });
    }

    async function getExpenses() {
        const data = await fetch('https://localhost:44312/api/UserBudgets/expenses');
        const response = await data.json();
        dispatch({
            type: 'GET_EXPENSES',
            payload: response
        });
    }

    async function getBalance() {
        const data = await fetch(`https://localhost:44312/api/UserBalance`);
        const response = await data.json();
        dispatch({
            type: 'GET_BALANCE',
            payload: response.data.balance
        });
    }

        async function getIncomes() {
            const data = await fetch('https://localhost:44312/api/UserBudgets/incomes');
            const response = await data.json();
            dispatch({
                type: 'GET_INCOMES',
                payload: response
            });
        }

        async function addTransaction(transaction) {
            if (transaction.amount < 0) {
                fetch('https://localhost:44312/api/ExpensesManagerInformations', {
                    method: 'PUT',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        Category: transaction.text,
                        Spent: transaction.amount * -1,
                        Limit: null,
                        uId: 1
                    })
                })
            }
            fetch('https://localhost:44312/api/UserBalance', {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    add: (transaction.amount > 0) ? transaction.amount : 0,
                    remove: (transaction.amount < 0) ? transaction.amount * -1 : 0
                })
            })
            fetch('https://localhost:44312/api/UserBudgets', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    text: transaction.text,
                    amount: transaction.amount,
                    userID: 1
                })
            })
            dispatch({
                type: 'ADD_TRANSACTION',
                payload: transaction
            });
        }

        return (
            <GlobalContext.Provider value={{
                transactions: state.transactions,
                expenses: state.expenses,
                incomes: state.incomes,
                balance: state.balance,
                addTransaction,
                getExpenses,
                getIncomes,
                getBalance,
                getTransactions
            }}>
                {children}
            </GlobalContext.Provider>);
    }