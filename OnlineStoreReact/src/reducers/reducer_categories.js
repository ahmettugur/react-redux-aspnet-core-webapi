import { FETCH_CATEGORY_LIST,CATEGORY_DETAIL } from "../actions/index"

const INITIAL_STATE = { categories: [],category: null }

export default function (state = INITIAL_STATE, action) {

    switch (action.type) {
        case FETCH_CATEGORY_LIST:
            return { ...state, categories: action.payload.data }
        case CATEGORY_DETAIL:
            return {...state, category: action.payload.data}
        default:
            return state;
    }

}