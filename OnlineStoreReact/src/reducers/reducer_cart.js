import { ADD_TO_CART, FETCH_CART } from "../actions/index"
import getCart from "../components/cart/cart-store"
import _ from "lodash"

const INITIAL_STATE = { cartLines: [], Total: 0 }

export default function (state = INITIAL_STATE, action) {

    switch (action.type) {
        case ADD_TO_CART:
            var cart = getCart(action.payload.data);
            return { ...state, cartLines: cart.CartLines, Total: cart.Total }
            //return { ...state, cartLines: action.payload.CartLines, Total: action.payload.Total }
        case FETCH_CART:
            return { ...state, cartLines: action.payload.CartLines, Total: action.payload.Total }
        default:
            return state;
    }
}
