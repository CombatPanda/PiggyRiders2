import { match } from 'assert';
import React, { useState, useEffect, Component } from 'react';
import { Link } from 'react-router-dom';
import './styles.css';

class SavingInfoDetails extends Component {

    constructor(props) {
        super(props);
        var today = new Date(),
        date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
        this.state = {
            id: '',
            purpose: '',
            cost: '',
            date: '',
            addition: '',
            user_id: '',
            balance: '',
            purposeError: '',
            costError: '',
            dateError: '',
            additionError: '',
            currentDate: date,
            savedAmount: '', 

        }
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    async getSaving() {
        let savingId = this.props.match.params.id;
        const data = await fetch(`https://localhost:44312/api/SavingsManagerInformations/${savingId}`);
        const response = await data.json();
        this.setState({
            id: response.data.id,
            purpose: response.data.purpose,
            cost: response.data.cost,
            date: response.data.date,
            savedAmount: response.data.savedAmount,
            addition: response.data.lastAddition
        }, () => {

        });
    }
    async getBalance() {
        let balanceId = this.props.match.params.user_id;
        const data = await fetch(`https://localhost:44312/api/UserBalance`);
        const response = await data.json();
        this.setState({
            balance: response.data.balance,
        }, () => {

        });
    }

    componentWillMount() {
        this.getSaving();
        this.getBalance();
    }

    onSubmit(e) {
        e.preventDefault();
        const isValid = this.validate();
        if (isValid) {
            const newSaving = {
                purpose: this.refs.purpose.value,
                cost: (this.refs.cost.value == "") ? null : this.refs.cost.value,
                date: (this.refs.date.value == "") ? null : this.refs.date.value,
                addition: (this.refs.addition.value == "") ? null : this.refs.addition.value
            }

            this.editSaving(newSaving);
            this.editBalance(newSaving);
        }
    }
    validate = () => {
        let purposeError = "";
        let costError = "";
        let dateError = "";
        let additionError = "";

        if (!this.state.purpose) {
            purposeError = "*Please enter a purpose.";
        }
        if (!this.state.purpose.match(/^[a-zA-Z0-9 ]*$/)) {
            purposeError = "*Please enter alphabet characters or numbers only.";
        }

        if (!this.state.cost) {
            costError = "*Please enter a cost.";
        }
        var pattern2 = new RegExp(/^[0-9]*$/);
        if (!pattern2.test(this.state.cost) >  0 ) {
            costError = "*Please enter a valid cost.";
        }



        var pattern = new RegExp(/([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))/);
        if (!pattern.test(this.state.date)) {
            dateError = "*Please enter a valid date.";
        }
        else {
            var res = new Date(this.state.date).getTime();
            var res2 = new Date(this.state.currentDate).getTime();
        }
        if (res < res2) {
            dateError = "*Please enter a valid date. One that is after today.";
        }

        if (!this.state.date) {
            dateError = "*Please enter a date.";
        }
        
        var pattern = new RegExp(/([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))/);
        if (!pattern.test(this.state.date)) {
            dateError = "*Please enter a valid date.";
        }
        else {
            var res = new Date(this.state.date).getTime();
            var res2 = new Date(this.state.currentDate).getTime();
        }
        if (res < res2) {
            dateError = "*Please enter a valid date. One that is after today.";
        }

        if (!pattern2.test(this.state.addition)) {
            additionError = "*Please enter a valid addition.";
        }
        else {
            var saved = parseInt(this.state.savedAmount) + parseInt(this.state.addition);
            var cost = parseInt(this.state.cost);
        }
        if (parseInt(this.state.addition) > parseInt(this.state.balance)) {
            additionError = "*You do not have enough money.";
        }

        if (saved > cost) {
            var diff = parseInt(this.state.cost) - parseInt(this.state.savedAmount);
            var diff2 = diff.toString();
            var text = "*Please add no more than: ";
            additionError = text + diff2;
        }

       

        if (purposeError || costError || dateError || additionError) {
            this.setState({ purposeError, costError, dateError, additionError });
            return false;
        }
        return true;
    };

    editSaving(newSaving) {
        fetch(`https://localhost:44312/api/SavingsManagerInformations/${this.state.id}`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                ID: this.state.id,
                purpose: newSaving.purpose,
                cost: newSaving.cost,
                date: newSaving.date,
                lastAddition: newSaving.addition
            })
        }).then(response => {
            this.props.history.push('/SavingsManagerInformations')
        })
    }

    editBalance(newSaving) {
        fetch(`https://localhost:44312/api/UserBalance`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                remove: newSaving.addition
            })
        }).then(response => {
            this.props.history.push('/SavingsManagerInformations')
        })
    }

    handleInputChange(e) {
        const target = e.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    render() {
        return (
            <div>
                <br />
                <Link to='/SavingsManagerInformations'>Back</Link>
                <br />
                <h1>Edit Saving</h1>
                <h1>You have saved: {this.state.savedAmount}</h1>
                <h1>Cost: {this.state.cost}</h1>
                <p class="bold_oblique"> Your balance: {this.state.balance}</p>

                <form onSubmit={this.onSubmit.bind(this)}>
                    <div className="imput-field">
                        <label htmlFor="purpose">Purpose</label>
                        <input type="text" name="purpose" ref="purpose" value={this.state.purpose} onChange={this.handleInputChange} />
                        <div className="errorMsg">{this.state.purposeError}</div>
                    </div>
                    <div className="imput-field">
                        <label htmlFor="cost">Cost</label>
                        <input type="text" name="cost" ref="cost" value={this.state.cost} onChange={this.handleInputChange} />
                        <div className="errorMsg">{this.state.costError}</div>
                    </div>
                    <div className="imput-field">
                        <label htmlFor="date">Date</label>
                        <input type="text" name="date" placeholder="yyyy-mm-dd" ref="date" value={this.state.date} onChange={this.handleInputChange} />
                        <div className="errorMsg">{this.state.dateError}</div>
                    </div>
                    <div className="imput-field">
                        <label htmlFor="addition">Add to your saving</label>
                        <input type="text" name="addition" ref="addition" value={this.state.addition} onChange={this.handleInputChange} />
                        <div className="errorMsg">{this.state.additionError}</div>
                    </div>
                    <input type="submit" value="Save" className="btn" />
                </form>

            </div>
        )
    }

}
export default SavingInfoDetails;