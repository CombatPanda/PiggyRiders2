export default (state, action) => {
    switch (action.type) {
        case 'ADD_INCOME':
            return {
                ...state,
                transactions: [action.payload, ...state.transactions]
            }
        case 'ADD_EXPENSES':
            return {
                ...state,
                transactions: [action.payload, ...state.transactions]
            }
        default:
            return state;
    }
}