import React, { useState, useContext, useEffect } from 'react';
import { SavingContext } from './SavingContext';
import { Route } from 'react-router-dom';
import { Button } from 'reactstrap';
//import DeleteSaving from './DeleteSaving';

const SavingList = () => {
    const [items, setItems] = useContext(SavingContext);

    const deleteLimit = (id) => {
        if (window.confirm('Are you sure?')) {
            fetch('https://localhost:44312/api/SavingsManagerInformations/' + id, {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                }
            })
            window.location.reload();
        }
    }
    useEffect(() => {
        fetchBalance();
    }, []);

    const [balance, setBalance] = useState('');

    const fetchBalance = async () => {
        const data = await fetch(`https://localhost:44312/api/UserBalance`);

        const balance = await data.json();
        console.log(balance);
        setBalance(balance.data);
    };

    return (
        <div>
            <p class="bold_oblique">your balance: { balance.balance}</p>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr class="simple_oblique">
                        <th>purpose</th>
                        <th>cost</th>
                        <th>date</th>
                        <th>saved amount</th>
                        <th>status</th>
                    </tr>
                </thead>
                <tbody>
                    {items.map(item =>
                        <tr key={item.id}>
                            <td>{item.purpose}</td>
                            <td>{item.cost}</td>
                            <td>{item.date}</td>
                            <td>{item.savedAmount}</td>
                            <td>{item.status}</td>
                            <td>
                                <Button
                                    type="primary"
                                    onClick={() => deleteLimit(item.id)}
                                >
                                    Delete
                                </Button>
                            </td>
                            <td>
                                <Route render={({ history }) => (
                                    <Button
                                        type="primary"
                                        onClick={() => { history.push(`/SavingsManagerInformations/${item.id}`) }}
                                    >
                                        Edit
                                    </Button>
                                )} />
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
};

export default SavingList;