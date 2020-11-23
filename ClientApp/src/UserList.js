import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../User';

class UserList extends Component {

    constructor() {
        super();
        this.state = {};
        this.onUserSelect = this.onUserSelect.bind(this);
        this.dialogHide = this.dialogHide.bind(this);
        this.addNew = this.addNew.bind(this);
        this.save = this.save.bind(this);
        this.delete = this.delete.bind(this);
    }

    componentDidMount() {
        this.fetchData();
    }

    componentDidUpdate() {
        // This method is called when the route parameters change
        if (this.props.forceReload) {
            this.fetchData();
        }
    }

    fetchData() {
        this.props.requestUser();
    }

    updateProperty(property, value) {
        let User = this.state.User;
        User[property] = value;
        this.setState({ User: User });
    }

    onUserSelect(e) {
        this.newUser = false;
        this.setState({
            displayDialog: true,
            User: Object.assign({}, e.data)
        });
    }

    dialogHide() {
        this.setState({ displayDialog: false });
    }

    addNew() {
        this.newUser = true;
        this.setState({
            User: { Usename: '', password: '', email: '' },
            displayDialog: true
        });
    }

    save() {
        this.props.saveUser(this.state.User);
        this.dialogHide();
        this.growl.show({ severity: 'success', detail: this.newUser ? 
                  "Data Saved Successfully" : "Data Updated Successfully" });
    }

    delete() {
        this.props.deleteUser(this.state.User.UserId);
        this.dialogHide();
        this.growl.show({ severity: 'error', detail: "Data Deleted Successfully" });
    }


export default connect(
    mapStateToProps,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(UserList);