/* eslint-disable */
import React, { useState, useContext, Component } from 'react'
import { GlobalContext } from '../context/GlobalState';

export const AddTransaction =()=> {
    const[text, setText] = useState('');
    const [amount, setAmount] = useState(0);
    const { addTransaction, getExpenses, getIncomes, getBalance } = useContext(GlobalContext);

 const onSubmit = e => {
     e.preventDefault();
  
    const newTransaction = {
        text,
        amount: +amount
    }
     addTransaction(newTransaction);
     getBalance();
}
       return (
            <div>
                <h3>Add new transaction</h3>
                <form name="form" onSubmit={onSubmit}>
                    <div className="imput-field">
                        <label htmlFor="text" >Text</label>
                       <input type="text" name="text" value={text} onChange={(e) => setText(e.target.value)} placeholder="Enter text..." />
                    </div>
                    <div className="imput-field">
                        <label htmlFor="amount">Amount <br />(negative - expense, positive - income)</label>
                       <input type="number" name="amount" value={amount} onChange={(e) => setAmount(e.target.value)} placeholder="Enter amount..." />
                    </div>

                   <button className="btn">Add transaction</button>

               </form>
               <div className="nav-wrapper">
                   <ul className="right hide-on-med-and-down">
                       <li><a className="dropdown-trigger" href="#!" data-target="dropdown">Menu</a></li>
                   </ul>
               </div>
            </div>
        )
    }
