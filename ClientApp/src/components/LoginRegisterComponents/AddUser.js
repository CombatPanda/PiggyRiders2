import React, { useState, useEffect, Component } from 'react';
import { Link } from 'react-router-dom';

class AddUser extends Component {

    onSubmit(e) {
        const newUser = {
            Username: (this.Username.value == ""), //? null : this.Username.value,
            Password: (this.Password.value == ""), //? null : this.Password.value,     
            Email: (this.Email.value == "") //? null : this.Email.value,
        }
        this.addUser(newUser);
        e.preventDefault();
    }

    addUser(newUser) {
        fetch('https://localhost:3001/api/UserInformations', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
            Username: newUser.Username,
            Password: newUser.Password,
            Email: newUser.Email 
            })
        }).then(response => {
            this.props.history.push('/log-in')
        })
    }

    // render() {
    //     return (
    //         <div>
    //             <br />
    //             <Link to='/sign-up'>Back</Link>
    //             <br />
    //             {/* <h1>Add Limit</h1> */}

    //             <form onSubmit={this.onSubmit.bind(this)}>
    //                 <div className="imput-field">
    //                     <input type="text" name="category" ref="category" />
    //                     <label htmlFor="category">Category</label>
    //                 </div>
    //                 <div className="imput-field">
    //                     <input type="text" name="spent" ref="spent" />
    //                     <label htmlFor="spent">Spent</label>
    //                 </div>
    //                 <div className="imput-field">
    //                     <input type="text" name="limit" ref="limit"/>
    //                     <label htmlFor="limit">Limit</label>
    //                 </div>
    //                 <input type="submit" value="Save" className="btn" />
    //             </form>

    //         </div>
    //     )
    // }

}
export default AddUser;