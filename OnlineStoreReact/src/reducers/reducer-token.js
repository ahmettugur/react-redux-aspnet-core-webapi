import { ACCES_TOKEN } from "../actions/index"

var INITIAL_STATE = {
    token: '',
    message: '',
    status: 0,
    statusClass: ''
}

export default function (state = INITIAL_STATE, action) {
    switch (action.type) {
        case `${ACCES_TOKEN}_PENDING`:
            return { ...state };
        case `${ACCES_TOKEN}_FULFILLED`:
            return {
                ...state,
                accessToken: action.payload.data.token,
                message: action.payload.statusText,
                status: action.payload.status,
                statusClass: 'ok'
            }
        case `${ACCES_TOKEN}_REJECTED`:
            return {
                ...state,
                accessToken: '',
                message: action.payload.response.data,
                status: action.payload.response.status,
                statusClass: 'error'
            }
            break;
        default:
            return state;
    }
}