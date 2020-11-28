import React, { useState, useEffect } from 'react';

function DeleteSaving() {
    const [status, setStatus] = useState(null);

    useEffect(() => {
        // DELETE request using fetch inside useEffect React hook
        fetch('https://localhost:44312/api/SavingsManagerInformations/1', { method: 'DELETE' })
            .then(() => setStatus('Delete successful'));

        // empty dependency array means this effect will only run once (like componentDidMount in classes)
    }, []);

    return (
        <div className="card text-center m-3">
            <h5 className="card-header">DELETE Request with React Hooks</h5>
            <div className="card-body">
                Status: {status}
            </div>
        </div>
    );
}

export default DeleteSaving;