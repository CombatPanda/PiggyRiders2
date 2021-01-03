import React from 'react';
import axios from 'axios';

class Leaderboard extends React.Component {

    constructor() {
        super();
        this.state = {
            leaderboards: []
        }
    }

    async getScore() {
        const data = await fetch('https://localhost:44312/api/UserInformations');
        const response = await data.json();
        this.setState({ leaderboards: response.data }, () => { });
        console.log(response.data)
    }

    componentWillMount() {
        this.getScore();
    }



    render() {
        return (
            <div>
                <h1> Leaderboards</h1>
                {   this.state.leaderboards
                    .sort((a, b) => b.itemM - a.itemM ? -1 : 1)
                    .map(user =>
                    <h1 key={user.id} >
                        <h2>{user.username} {user.score}</h2>
                        
                     
                    </h1>

                )}

            </div>
        );
    }
}

export default Leaderboard;
