import React, { useState, useContext } from 'react';
import { SavingContext } from './SavingContext';

const AddSavingInfo = () => {

    const [purpose, setPurpose] = useState('');
    const [cost, setCost] = useState('');
    const [date, setDate] = useState('');
    const [items, setItems] = useContext(SavingContext);

    const updatePurpose = e => {
        setPurpose(e.target.value);
    };
    const updateCost = e => {
        setCost(e.target.value);
    };
    const updateDate = e => {
        setDate(e.target.value);
    };

    const addSavingInfo = e => {
        e.preventDefault();
        fetch('https://localhost:44312/api/SavingsManagerInformations', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                purpose: purpose,
                Cost: cost,
                Date: date,
                savedAmount: 0,
                Status: "Not started"
            })
        })
        setItems(prevItems => [...prevItems, { purpose: purpose, cost: cost, date: date }])

    };

    return (
        <form onSubmit={addSavingInfo}>
            <input type="text" name="purpose" value={purpose} onChange={updatePurpose} />
            <input type="text" name="cost" value={cost} onChange={updateCost} />
            <input type="text" name="date" value={date} onChange={updateDate} />
            <button>Submit</button>
        </form>
    );
};
export default AddSavingInfo;