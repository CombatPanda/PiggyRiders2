export default (state, action) => {
    switch (action.type) {
        case 'GET_TRANSACTION':
            return {
                ...state,
                transactions: action.payload
            }
        case 'ADD_TRANSACTION':
            return {
                ...state,
                transactions: [...state.transactions, action.payload]
            }
        case 'GET_INCOMES':
            return {
                ...state,
                incomes: action.payload
            }
        case 'GET_EXPENSES':
            return {
                ...state,
                expenses: action.payload
            }
        default:
            return state;
    }
}