import React, { useContext, useEffect } from 'react';
import { useState } from 'react';
import { GlobalContext } from '../context/GlobalState';


export const IncomeExpenses = () => {
    const { getIncomes, getExpenses, incomes, expenses } = useContext(GlobalContext);
    const [e, setE] = useState(0);
    const [i, setI] = useState(0);

    const fetchInfo = () => {
        getExpenses();
        setE(expenses);
        getIncomes();
        setI(incomes);
    }
    useEffect(() => { fetchInfo();});

    return (
        <div className="inc-exp-container">
            <div>
                <h4>Income</h4>
                <p className="money plus">${i}</p>
            </div>
            <div>
                <h4>Expense</h4>
                <p className="money minus">${e}</p>
            </div>
        </div>
    )
}