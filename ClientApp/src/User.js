const initialState = {
    users: [],
    loading: false,
    errors: {},
    forceReload: false
}

export const actionCreators = {
    requestUsers: () => async (dispatch, getState) => {

        const url = 'api/User/Users';
        const response = await fetch(url);
        const contacts = await response.json();
        dispatch({ type: 'FETCH_USER', users });
    },
    saveUser: user => async (dispatch, getState) => {

        const url = 'api/Contact/SaveContact';
        const headers = new Headers();
        headers.append('Content-Type', 'application/json');
        const requestOptions = {
            method: 'POST',
            headers,
            body: JSON.stringify(user)
        };
        const request = new Request(url, requestOptions);
        await fetch(request);
        dispatch({ type: 'SAVE_USER', users });
    },
    deleteUser: UserId => async (dispatch, getState) => {
        const url = 'api/User/DeleteUser/' + userId;
        const requestOptions = {
            method: 'DELETE',
        };
        const request = new Request(url, requestOptions);
        await fetch(request);
        dispatch({ type: 'DELETE_USER', userId });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        case 'FETCH_USER': {
            return {
                ...state,
                users: action.users,
                loading: false,
                errors: {},
                forceReload: false
            }
        }
        case 'SAVE_USER': {
            return {
                ...state,
                users: Object.assign({}, action.user),
                forceReload: true
            }
        }
        case 'DELETE_USER': {
            return {
                ...state,
                userId: action.usersId,
                forceReload: true
            }
        }
        default:
            return state;
    }
};