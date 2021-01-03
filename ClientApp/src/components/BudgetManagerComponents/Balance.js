import React from 'react';
import { useEffect, useContext } from 'react';
import { GlobalContext } from '../context/GlobalState';

export const Balance = () => {
    const { balance, getBalance } = useContext(GlobalContext);

    useEffect(() => {
        getBalance();
    }, []);

    return (
        <>
            <h4>Your Balance</h4>
            <h1>${balance}</h1>
        </>
    )
}