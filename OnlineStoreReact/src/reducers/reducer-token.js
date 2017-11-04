import { ACCES_TOKEN } from "../actions/index"

var INITIAL_STATE = { token: '', message: '' }

export default function (state = INITIAL_STATE, action) {
    switch (action.type) {
        case ACCES_TOKEN:
        console.log(action.payload);
            return {
                ...state,
                accessToken: action.payload.data.token,
                message: action.payload.statusText
            }
        default:
            return state;
    }
}