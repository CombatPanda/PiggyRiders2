import React, { createContext, useReducer } from 'react';
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

    function addIncome(income) {
        dispatch({
            type: 'ADD_INCOME',
            payload: income
        });
    }

    function addExpenses(expenses) {
        dispatch({
            type: 'ADD_EXPENSES',
            payload: expenses
        });
    }

    return (<GlobalContext.Provider value={{
        transactions: state.transactions,
        addIncome,
        addExpenses
    }}>
        {children}
    </GlobalContext.Provider>);
}