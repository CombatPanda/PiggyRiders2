import React, { useState, useContext } from 'react';
import { SavingContext } from './SavingContext';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import { Link } from 'react-router-dom';
import './styles.css';

export default class AddSavingInfo extends React.Component {
    constructor() {
        super();
        var today = new Date(),
        date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
        this.state = {
            fields: {},
            errors: {},
            currentDate: date
             
        }

        this.handleChange = this.handleChange.bind(this);
        this.submitSavingForm = this.submitSavingForm.bind(this);

    };

    handleChange(e) {
        let fields = this.state.fields;
        fields[e.target.name] = e.target.value;
        this.setState({
            fields
        });

    }

    submitSavingForm(e) {
        e.preventDefault();
        if (this.validateForm()) {
            const newSaving = {
                purpose: this.refs.purpose.value,
                date: this.refs.date.value,
                cost: this.refs.cost.value
            }
            this.addSaving(newSaving);
            let fields = {};
            fields["purpose"] = "";
            fields["date"] = "";
            fields["cost"] = "";
            this.setState({ fields: fields });
        }

    }

    validateForm() {

        let fields = this.state.fields;
        let errors = {};
        let formIsValid = true;

        if (!fields["purpose"]) {
            formIsValid = false;
            errors["purpose"] = "*Please enter a purpose.";
        }

        if (typeof fields["purpose"] !== "undefined") {
            if (!fields["purpose"].match(/^[a-zA-Z0-9 ]*$/)) {
                formIsValid = false;
                errors["purpose"] = "*Please enter alphabet characters or numbers only.";
            }
        }
        if (!fields["cost"]) {
            formIsValid = false;
            errors["cost"] = "*Please enter a cost.";
        }

        if (typeof fields["cost"] !== "undefined") {
            if (!fields["cost"].match(/^[0-9]*$/) > 0) {
                formIsValid = false;
                errors["cost"] = "*Please enter a valid cost.";
            }
        }

        if (!fields["date"]) {
            formIsValid = false;
            errors["date"] = "*Please enter a date.";
        }

        if (typeof fields["date"] !== "undefined") {
            var pattern = new RegExp(/([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))/);
            if (!pattern.test(fields["date"])) {
                formIsValid = false;
                errors["date"] = "*Please enter a valid date.";
            }
            else {
                var res = new Date(fields["date"]).getTime();
                var res2 = new Date(this.state.currentDate).getTime();
            }
            if (res < res2) {
                formIsValid = false;
                errors["date"] = "*Please enter a valid date. One that is after today.";
            }
        }


        this.setState({
            errors: errors
        });
        return formIsValid;


    }

    addSaving(newSaving) {
        fetch('https://localhost:44312/api/SavingsManagerInformations', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                purpose: newSaving.purpose,
                date: newSaving.date,
                cost: newSaving.cost
            })
        }).then(response => {
            if (response.ok) {
                alert("Successfully added a saving")
                window.location.reload();
            }
            
            
        });

    }
    render() {
        return (
            <div>
                <form onSubmit={this.submitSavingForm}>
                    <div class="input-field">
                        <p class="bold_oblique" htmlFor="purpose">purpose
                        <input type="text" name="purpose" ref="purpose" value={this.state.fields.purpose} onChange={this.handleChange} className="form-control"
                                placeholder="enter purpose..."/>
                        <div className="errorMsg">{this.state.errors.purpose}</div></p>
                    </div>
                    <div class="input-field">
                        <p class="bold_oblique" htmlFor="cost">cost
                        <input type="text" name="cost" ref="cost" value={this.state.fields.cost} onChange={this.handleChange} className="form-control"
                                placeholder="enter cost..."/>
                        <div className="errorMsg">{this.state.errors.cost}</div></p>
                        
                    </div>
                    <div class="input-field">
                       <p class="bold_oblique" htmlFor="date">date
                        <input type="text" name="date" className="form-control" placeholder="yyyy-mm-dd" ref="date" value={this.state.fields.date} onChange={this.handleChange} />
                            <div className="errorMsg">{this.state.errors.date}</div></p>
                    </div>
                    <button type="submit" class="button_save">SAVE</button>
                </form>

            </div>
        )
    }
}