import React, { useState, useEffect, Component } from 'react';
import { Link } from 'react-router-dom';
class FetchExpensesManagerInfo extends Component {

    constructor() {
        super();
        this.state = {
            expenses: []
        }
    }

    async getExpenses() {
        const data = await fetch('https://localhost:44312/api/ExpensesManagerInformations');
        const response = await data.json();
        this.setState({ expenses: response }, () => {  });
    }

    componentWillMount() {
        this.getExpenses();
    }

    deleteLimit(id) {
        if (window.confirm('Are you sure?')) {
            fetch('https://localhost:44312/api/ExpensesManagerInformations/' + id, {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                }
            })
          window.location.reload();
        }
    }

    getColor = (spent, limit) => {
        if (limit == null)
            return 'black';
        if (spent > limit)
            return 'red';
        else return 'black';
    }

    render() {
        return (
            <div>
                <h1>Expenses Manager</h1>
                <table cellPadding={0} cellPadding={0}>
                    <thead className="collection">
                    <th>Category</th>
                    <th>Spent</th>
                    <th>Limit</th>
                    <th>Actions</th>
                    </thead>
                    <tbody className="collection-item">
                        {this.state.expenses.map(expense =>
                            <tr key={expense.id} style={{ color: this.getColor(expense.spent, expense.limit) }}>
                                <td>{expense.category}</td>
                                <td>{expense.spent}</td>
                                <td>{expense.limit}</td>
                                <td>
                                    <button><Link to={'/ExpensesManagerInformations/edit/'+expense.id}>Edit</Link></button>
                                    <button className="mr-2" onClick={() => this.deleteLimit(expense.id)}>Remove</button>
                                </td>
                            </tr>
                        )}
                 </tbody>
                </table>
                <div className="fixed-action-btn">
                    <Link to="/ExpensesManagerInformations/add" className="btn-floating btn-large">
                        <i className="fa fa-plus"></i>
                    </Link>
                </div>
            </div>
            )
}
}
export default FetchExpensesManagerInfo;
