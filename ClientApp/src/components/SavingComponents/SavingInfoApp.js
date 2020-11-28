import React from 'react';
import {SavingProvider} from './SavingContext'
import SavingList from './SavingList';
import AddSavingInfo from './AddSavingInfo';

function SavingInfoApp() {
    return (
        <SavingProvider>
            <div>
                <AddSavingInfo />
                <SavingList />
            </div>
        </SavingProvider>
        );
}

export default SavingInfoApp;