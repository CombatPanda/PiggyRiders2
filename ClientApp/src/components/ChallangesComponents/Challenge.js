import React from 'react';
import { achievement } from './AchievementData.js';
import axios from 'axios';
import ChallangeCard from './ChallangeCard';
import './styles.css'
import uncompletedChallenge from './imgUncompleted.png';
import completedChallenge from './imgCompleted.jpg';

class Challenges extends React.Component {

    constructor() {
        super();
        this.state = {
            achievements: []
        }
    }

    async getExpenses() {
        const data = await fetch('https://localhost:44312/api/UserAchievement');
        const response = await data.json();
        this.setState({ achievements: response.data }, () => { });
        console.log(response.data)
    }

    componentWillMount() {
        this.getExpenses();
    }

    getColor = (status) => {
        if (status == 0)
            return 'red';
        if (status > 1)
            return 'green';
        else return 'red';
    }

    getImage = (status) => {
        if (status == 0)
            return uncompletedChallenge;
        if (status > 1)
            return completedChallenge;
        else return uncompletedChallenge;
    }

    getStatus = (status) => {
        if (status == 0)
            return "Ongoing";
        if (status > 1)
            return "Completed";
        else return "Ongoing";
    }

    completeChallenge(challengeId, newStatus) {
        fetch(`https://localhost:44312/api/ExpensesManagerInformations/${this.state.id}`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                ID: challengeId.id,
                Status: newStatus.status,
                uID: 1
            })
        }).then(response => {
            this.props.history.push('/Challenges')
        })
    }
    //Challenges.completeChallenge(1, 1);
    render() {
        return (
            <div>
                <h1> Achievement List</h1>
                {   this.state.achievements.map(challenge => 
                  
                    <h3 key={challenge.id} >
                        <img src={this.getImage(challenge.status)} width="70" height="50"></img>
                        <>{challenge.name + ": "}</>
                        <>{challenge.description}</>
                        <hright style={{ color: this.getColor(challenge.status), flex: 1, textAlign: 'right', alignSelf: 'stretch'}} >{challenge.status =" " + this.getStatus(challenge.status) }</hright>
                    </h3>
               
                      //  <><h3><img src={challange.ImageSrc} width="70" height="50"></img>  {challange.Name} {challange.Description} <hright> {challange.Status} </hright></h3></>)    
                )}
            </div>
        );
    }
}

export default Challenges;
