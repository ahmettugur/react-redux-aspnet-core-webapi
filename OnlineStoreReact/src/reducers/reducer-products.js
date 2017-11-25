import {
    FETCH_PRODUCT_LIST,
    FETCH_ADMIN_PRODUCT_LIST,
    PRODUCT_DETAIL,
    PRODUCT_CREATE,
    PRODUCT_UPDATE,
    PRODUCT_DELETE,
} from "../actions/index"

const INITIAL_STATE = {
    products: [],
    adminProducts: [],
    PageCount: 0,
    PageSize: 0,
    product: null,
    message: '',
    status: 0,
    statusClass: ''
}

export default function (state = INITIAL_STATE, action) {
    switch (action.type) {
        case `${FETCH_PRODUCT_LIST}_PENDING`:
            return { ...state }
            break;
        case `${FETCH_PRODUCT_LIST}_FULFILLED`:
            return {
                ...state, products: action.payload.data.Products,
                PageSize: action.payload.data.PageSize,
                PageCount: action.payload.data.PageCount,
                product: null,
                message: action.payload.statusText,
                status: action.payload.status,
                statusClass: 'ok'
            }
            break;
        case `${FETCH_PRODUCT_LIST}_REJECTED`:
            return {
                ...state,
                message: action.payload.response.data,
                status: action.payload.response.status,
                statusClass: 'error'
            }
            break;
        case `${FETCH_ADMIN_PRODUCT_LIST}_PENDING`:
            return { ...state }
            break;
        case `${FETCH_ADMIN_PRODUCT_LIST}_FULFILLED`:
            return {
                ...state, products: action.payload.data.Products,
                PageCount: action.payload.data.PageCount,
                PageSize: action.payload.data.PageSize,
                product: null,
                message: action.payload.statusText,
                status: action.payload.status,
                statusClass: 'ok'
            }
        case `${FETCH_ADMIN_PRODUCT_LIST}_REJECTED`:
            return {
                ...state,
                message: action.payload.response.data,
                status: action.payload.response.status,
                statusClass: 'error'
            }
            break;
        case `${PRODUCT_DETAIL}_PENDING`:
            return { ...state }
            break;
        case `${PRODUCT_DETAIL}_FULFILLED`:
            console.log(action.payload.data);
            return {
                ...state,
                product: action.payload.data,
                message: action.payload.statusText,
                status: action.payload.status,
                statusClass: 'ok'
            }
            break;
        case `${PRODUCT_DETAIL}_REJECTED`:
            return {
                ...state,
                message: action.payload.response.data,
                status: action.payload.response.status,
                statusClass: 'error'
            }
            break;

        case `${PRODUCT_CREATE}_PENDING`:
            return { ...state };
            break;
        case `${PRODUCT_CREATE}_FULFILLED`:
            return {
                ...state,
                message: action.payload.statusText,
                status: action.payload.status,
                statusClass: 'ok'
            }
            break;
        case `${PRODUCT_CREATE}_REJECTED`:
            return {
                ...state,
                message: action.payload.response.data,
                status: action.payload.response.status,
                statusClass: 'error'
            }
            break;
        case `${PRODUCT_UPDATE}_PENDING`:
            return { ...state };
            break;
        case `${PRODUCT_UPDATE}_FULFILLED`:
            return {
                ...state,
                message: action.payload.statusText,
                status: action.payload.status,
                statusClass: 'ok'
            }
            break;
        case `${PRODUCT_UPDATE}_REJECTED`:
            return {
                ...state,
                message: action.payload.response.data,
                status: action.payload.response.status,
                statusClass: 'error'
            }
            break;
        case `${PRODUCT_DELETE}_PENDING`:
            return { ...state };
        case `${PRODUCT_DELETE}_FULFILLED`:
            return {
                ...state,
                message: action.payload.statusText,
                status: action.payload.status,
                statusClass: 'ok'
            }
        case `${PRODUCT_DELETE}_REJECTED`:
            return {
                ...state,
                message: action.payload.response.data,
                status: action.payload.response.status,
                statusClass: 'error'
            }
            break;

        default:
            return state;
    }
}
