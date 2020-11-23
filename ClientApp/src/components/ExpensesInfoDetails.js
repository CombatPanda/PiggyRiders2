import React, { useState, useEffect } from 'react';


function ExpensesInfoDetails({ match }) {

    useEffect(() => {
        fetchItem();
        console.log(match);
    }, []);

    const [item, setItem] = useState({});

    const fetchItem = async () => {
        const fetchItem = await fetch(`https://localhost:44312/api/ExpensesManagerInformations/${match.params.id}`);
        const item = await fetchItem.json();
        setItem(item);
        console.log(item);
    };

    return (
        <div>
            <h1>{item.category}</h1>
        </div>
    );
}
export default ExpensesInfoDetails;