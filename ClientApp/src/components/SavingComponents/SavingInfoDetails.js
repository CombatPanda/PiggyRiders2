import { match } from 'assert';
import React, { useState, useEffect, Component } from 'react';
import { Link } from 'react-router-dom';

class SavingInfoDetails extends Component {

    constructor(props) {
        super(props);
        this.state = {
            id: '',
            purpose: '',
            cost: '',
            date: ''
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
            date: response.data.date
        }, () => {

        });
    }

    componentWillMount() {
        this.getSaving();
    }

    onSubmit(e) {
        const newSaving = {
            purpose: this.refs.purpose.value,
            cost: (this.refs.cost.value == "") ? null : this.refs.cost.value,
            date: (this.refs.date.value == "") ? null : this.refs.date.value
        }
        e.preventDefault();
        this.editSaving(newSaving);
    }

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
                status: "Not Started",
                uID: 0
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

                <form onSubmit={this.onSubmit.bind(this)}>
                    <div className="imput-field">
                        <input type="text" name="purpose" ref="purpose" value={this.state.purpose} onChange={this.handleInputChange} />
                        <label htmlFor="purpose">Purpose</label>
                    </div>
                    <div className="imput-field">
                        <input type="text" name="cost" ref="cost" value={this.state.cost} onChange={this.handleInputChange} />
                        <label htmlFor="cost">Cost</label>
                    </div>
                    <div className="imput-field">
                        <input type="text" name="date" ref="date" value={this.state.date} onChange={this.handleInputChange} />
                        <label htmlFor="date">Date</label>
                    </div>
                    <input type="submit" value="Save" className="btn" />
                </form>

            </div>
        )
    }

}
export default SavingInfoDetails;