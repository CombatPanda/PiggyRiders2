
import React, { useContext } from 'react';
import { GlobalContext } from '../context/GlobalState';

export const Transaction = ({ transaction }) => {

    const sign = transaction.income < 0 ? '-' : '+';

    return (
        <li className={transaction.income < 0 ? 'minus' : 'plus'}>
            {transaction.incomeInfo} <span>{sign}${Math.abs(transaction.income)}</span>
        </li>
    )
}