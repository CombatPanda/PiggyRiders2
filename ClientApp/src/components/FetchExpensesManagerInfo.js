import React, { useState, useEffect } from 'react';
import axios from "axios";
import { Link } from 'react-router-dom';

function FetchExpensesManagerInfo() {


    return (
        <div>
            <h1>Expenses Manager</h1>
            <div className="fixed-action-btn">
                <Link to="/ExpensesManagerInformations/add" className="btn-floating btn-large">
                    <i className="fa fa-plus"></i>
                </Link>
            </div>
        </div>
    );

}
export default FetchExpensesManagerInfo;