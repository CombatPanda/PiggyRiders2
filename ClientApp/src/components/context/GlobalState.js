import React, { createContext, useReducer } from 'react';
import { formatWithOptions } from 'util';
import AppReducer from './AppReducer';

// Initial state
const initialState = {
    transactions: []
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

    async function addTransaction(transaction) {
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
        addTransaction,
        getTransactions
    }}>
        {children}
        </GlobalContext.Provider>);
}