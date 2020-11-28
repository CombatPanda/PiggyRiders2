import React, { useState, useEffect, Component } from 'react';
import { Link } from 'react-router-dom';

class AddLimit extends Component {

    onSubmit(e) {
        const newLimit = {
            category: this.refs.category.value,
            spent: (this.refs.spent.value == "") ? null : this.refs.spent.value,
            limit: (this.refs.limit.value == "") ? null : this.refs.limit.value,     
            uid: 1
        }
        this.addLimit(newLimit);
        e.preventDefault();
    }

    addLimit(newLimit) {
        fetch('https://localhost:44312/api/ExpensesManagerInformations', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                Category: newLimit.category,
                Spent: newLimit.spent,
                Limit: newLimit.limit,
                uId: newLimit.uid
            })
        }).then(response => {
            this.props.history.push('/ExpensesManagerInformations')
        })
    }

    render() {
        return (
            <div>
                <br />
                <Link to='/ExpensesManagerInformations'>Back</Link>
                <br />
                <h1>Add Limit</h1>

                <form onSubmit={this.onSubmit.bind(this)}>
                    <div className="imput-field">
                        <input type="text" name="category" ref="category" />
                        <label htmlFor="category">Category</label>
                    </div>
                    <div className="imput-field">
                        <input type="text" name="spent" ref="spent" />
                        <label htmlFor="spent">Spent</label>
                    </div>
                    <div className="imput-field">
                        <input type="text" name="limit" ref="limit"/>
                        <label htmlFor="limit">Limit</label>
                    </div>
                    <input type="submit" value="Save" className="btn" />
                </form>

            </div>
        )
    }

}
export default AddLimit;