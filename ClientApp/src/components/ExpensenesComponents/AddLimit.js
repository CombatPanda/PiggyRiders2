import React, { Component } from 'react';
import { Link } from 'react-router-dom';

class AddLimit extends Component {

    onSubmit(e) {
        const newLimit = {
            category: this.refs.category.value,
            spent: (this.refs.spent.value == "") ? null : this.refs.spent.value,
            limit: (this.refs.limit.value == "") ? null : this.refs.limit.value,     
            uid: 1
        }
        e.preventDefault();
        if (this.handleValidation(newLimit)) {
            this.addLimit(newLimit);
        }
       
    }

    handleValidation(newLimit) {
        var formIsValid = true;
        if (!newLimit.category)
        {
            formIsValid = false;
            alert("Category field cannot be empty!");
            return formIsValid;
        }
       else return formIsValid;
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
                        <label htmlFor="category">Category</label>
                        <input type="text" name="category" ref="category" />
                    </div>
                    <div className="imput-field">
                        <label htmlFor="spent">Spent</label>
                        <input type="number" name="spent" ref="spent" />                        
                    </div>
                    <div className="imput-field">                       
                        <label htmlFor="limit">Limit</label>
                        <input type="number" name="limit" ref="limit" />
                    </div>
                    <input type="submit" value="Save" className="btn" />
                </form>

            </div>
        )
    }

}
export default AddLimit;