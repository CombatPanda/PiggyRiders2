/* eslint-disable */
import React, { useState, useContext, Component } from 'react'
import { GlobalContext } from '../BMcontextAPI/GlobalState';

export class AddTransaction extends Component {
  
    addIncome(newIncome) {
        fetch('https://localhost:44312/api/UserIncomes', {
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
        })
    }

    addExpenses(newExpenses) {
        fetch('https://localhost:44312/api/UserExpenses', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                expensesInfo: newExpenses.info,
                expenses: newExpenses.expenses,
                userID: newExpenses.userID
            })
        })
    }  


    onSubmit(e) {
        var value= document.activeElement.value;
        e.preventDefault();
        if (value == "incomes") {
            const newIncome = {
                info: this.refs.text.value,
                income: this.refs.amount.value,
                userID: 1
            }
            console.log(newIncome);
            this.addIncome(newIncome);
        }
        if (value == "expenses") {
            const newExpenses = {
                info: this.refs.text.value,
                expenses: this.refs.amount.value,
                userID: 1
            }
            this.addExpenses(newExpenses);
        }
    };
    render() {
        return (
            <div>
                <h3>Add new transaction</h3>
                <form name="form" onSubmit={this.onSubmit.bind(this)}>
                    <div className="imput-field">
                        <label htmlFor="text" >Text</label>
                        <input type="text" name="text" ref="text" placeholder="Enter text..." />
                    </div>
                    <div className="imput-field">
                        <label htmlFor="amount">Amount <br />(negative - expense, positive - income)</label>
                        <input type="number" name="amount" ref="amount" placeholder="Enter amount..." />
                    </div>

                    <input type="submit" value="incomes" className="btn" name="incomes" />
                    <input type="submit" value="expenses" className="btn" name="expenses" />

                </form>
            </div>
        )
    }
}