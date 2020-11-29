﻿import React, { useState, useContext } from 'react';
import { SavingContext } from './SavingContext';
import { Route } from 'react-router-dom';
import { Button } from 'reactstrap';
import DeleteSaving from './DeleteSaving';

const SavingList = () => {
    const [items, setItems] = useContext(SavingContext);
    return (
        <div>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Purpose</th>
                        <th>Cost</th>
                        <th>Date</th>
                        <th>Saved Amount</th>
                        <th>Status</th>
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
                                    onClick={DeleteSaving }
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