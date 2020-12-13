import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class EditAchievementInfo extends Component {

    constructor(props) {
        super(props);
        this.state = {
            id: '',
            status: ''
        }
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    async getAchievement(id) {
        let AchievementId = id;
        const data = await fetch(`https://localhost:44312/api/UserAchievement/${AchievementId}`);
        const response = await data.json();
        this.setState({
            id: response.data.id,
            status: response.data.status
        }, () => {

        });
    }

    componentWillMount() {
        this.getExpense();
    }

    completeChallenge(challengeId, newStatus) {
        fetch(`https://localhost:44312/api/UserAchievement/${this.state.id}`, {
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

    render() {
        return (
            <div>

            </div>
        )
    }

}
export default EditAchievementInfo;