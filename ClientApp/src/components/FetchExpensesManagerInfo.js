import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

function FetchExpensesManagerInfo() {

    useEffect(() => {
        fetchItems();
    }, []);

    const [items, setItems] = useState([]);

    const fetchItems = async () => {
        const data = await fetch('https://localhost:44312/api/ExpensesManagerInformations');

        const items = await data.json();
        console.log(items);
        setItems(items);
    };

    return (
        <div>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Category</th>
                        <th>Spent</th>
                        <th>Limit</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {items.map(item =>
                        <tr key={item.id}>
                            <td>{item.category}</td>
                            <td>{item.spent}</td>
                            <td>{item.limit}</td>
                            <td>
                                <button className="btn btn-primary">Edit</button>{"   "}
                                <button classNmae="btn btn-danger">Delete</button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );

}
export default FetchExpensesManagerInfo;