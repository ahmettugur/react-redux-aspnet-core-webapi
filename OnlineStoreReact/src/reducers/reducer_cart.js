import {
    ADD_TO_CART,
    FETCH_CART
} from "../actions/index"
import getCart from "../components/cart/cart-store"

const INITIAL_STATE = {
    cartLines: [],
    Total: 0,
    message: '',
    status: 0,
    statusClass: ''
}

export default function (state = INITIAL_STATE, action) {

    switch (action.type) {
        case `${ADD_TO_CART}_PENDING`:
            return { ...state }
        case `${ADD_TO_CART}_FULFILLED`:
            var cart = getCart(action.payload.data);
            return {
                ...state,
                cartLines:
                cart.CartLines,
                Total:
                cart.Total,
                message: action.payload.statusText,
                status: action.payload.status,
                statusClass: 'ok'
            }
        case `${ADD_TO_CART}_REJECTED`:
            return {
                ...state,
                message: action.payload.response.data,
                status: action.payload.response.status,
                statusClass: 'error'
            }
            break;
        case FETCH_CART:
            return { ...state, cartLines: action.payload.CartLines, Total: action.payload.Total }
        default:
            return state;
    }
}
