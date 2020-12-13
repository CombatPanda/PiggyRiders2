import React, { createContext, useReducer } from 'react';
import { formatWithOptions } from 'util';
import AppReducer from './AppReducer';

// Initial state
const initialState = {
    transactions: [],
    error: null,
    loading: true
}

// Create context
export const GlobalContext = createContext(initialState);

// Provider component
export const GlobalProvider = ({ children }) => {
    const [state, dispatch] = useReducer(AppReducer, initialState);

    // Actions
    async function getTransactions() {
        try {
            const data = await fetch('https://localhost:44312/api/UserIncomes');
            const response = await data.json();
            dispatch({
                type: 'GET_TRANSACTION',
                payload: response
            });
        } catch (err) {
            dispatch({
                type: 'TRANSACTION_ERROR',
                payload: err.response.error
            });
        }
    }

    function addTransaction(transaction) {
        dispatch({
            type: 'ADD_TRANSACTION',
            payload: transaction
        });
    }

    return (
        <GlobalContext.Provider value={{
        transactions: state.transactions,
        error: state.error,
        loading: state.loading,
        addTransaction,
        getTransactions
    }}>
        {children}
        </GlobalContext.Provider>);
    console.log(state.payload)
}