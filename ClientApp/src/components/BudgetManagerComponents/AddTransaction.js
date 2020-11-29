/* eslint-disable */
import React, { useState, useContext, Component } from 'react'
import { GlobalContext } from '../BMcontextAPI/GlobalState';

export const AddTransaction = () => {
    const [text, setText] = useState('');
    const [amount, setAmount] = useState(0);

    const { addIncome } = useContext(GlobalContext);
    const { addExpenses } = useContext(GlobalContext);

    const onSubmit = e => {

        const newIncome = {
            info: this.refs.text,
            income: this.refs.amount,
            userID: 1
        }
        const newExpenses = {
            info: this.refs.text,
            expenses: this.refs.amount,
            userID: 1
        }

        this.addIncome(newIncome);
        this.addExpenses(newExpenses);
        e.preventDefault();
    }

    this.addIncome = newIncome => {
        fetch('https://localhost:44312/api/BMInfo', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                incomeInfo: newIncome.info,
                income: newIncome.income,
                userID: newIncome.userID
            })
        }).then(response => {
            this.props.history.push('/BMInfo')
        })
    }

    this.addExpenses = newExpenses => {
        fetch('https://localhost:44312/api/BMInfo', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                expensesInfo: newExpenses.info,
                epenses: newExpenses.expenses,
                userID: newExpenses.userID
            })
        }).then(response => {
            this.props.history.push('/BMInfo')
        })
    }

    render => {
        return (
            <div>
                <h3>Add new transaction</h3>
                <form>
                    <div>
                        <label htmlFor="text">Text</label>
                        <input type="text" value={text} onChange={(e) => setText(e.target.value)} placeholder="Enter text..." />
                    </div>
                    <div>
                        <label htmlFor="amount">Amount <br />(negative - expense, positive - income)</label>
                        <input type="number" value={amount} onChange={(e) => setAmount(e.target.value)} placeholder="Enter amount..." />
                    </div>
                </form>
                <form onSubmit={onSubmit.bind(addIncome)}>
                    <button className="btn">Add income</button>
                </form>

                <form onSubmit={this.onSubmit.bind(addExpenses)}>
                    <button className="btn">Add expenses</button>
                </form>

            </div>
        )
    }
}

export default AddTransaction;