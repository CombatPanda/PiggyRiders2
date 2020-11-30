import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';



function FetchSavingInfo() {

    useEffect(() => {
        fetchItems();
    }, []);

    const [items, setItems] = useState([]);

    const fetchItems = async () => {
        const data = await fetch('https://localhost:44312/api/SavingsManagerInformations');

        const items = await data.json();
        console.log(items);
        setItems(items);
    };

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
                            <td><Link to={`/SavingsManagerInformations/${item.id}`}>{item.purpose}</Link></td>
                            <td>{item.cost}</td>
                            <td>{item.date}</td>
                            <td>{item.savedAmount}</td>
                            <td>{item.status}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
}
export default FetchSavingInfo;
