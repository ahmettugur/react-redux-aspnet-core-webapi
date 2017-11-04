import axios from "axios"
import getCart from "../components/cart/cart-store"

const API_URL = 'http://localhost:1977';
const PRODUCT_LIST_URL = "/api/products";
const PRODUCT_DETAIL_URL = "/api/products/detail"
const ACCES_TOKEN_URL = "/token";
const PRODUCT_CRUD_URL = "/api/admin/products";
const CATEGORY_CRUD_URL = "/api/categories";
export const PRODUCT_EXCEL_DOWNLOAD_URL = API_URL + "/api/admin/products/download"

export const FETCH_CATEGORY_LIST = 'FETCH_CATEGORY_LIST';
export const CATEGORY_DETAIL = 'CATEGORY_DETAIL';
export const FETCH_PRODUCT_LIST = "FETCH_PRODUCT_LIST";
export const PRODUCT_DETAIL = "PRODUCT_DETAIL";
export const ADD_TO_CART = "ADD_TO_CART";
export const FETCH_CART = "FETCH_CART";
export const FETCH_ADMIN_PRODUCT_LIST = "FETCH_ADMIN_PRODUCT_LIST";
export const ACCES_TOKEN = 'ACCES_TOKEN';

export const PRODUCT_CREATE = "PRODUCT_CREATE";
export const PRODUCT_UPDATE = "PRODUCT_UPDATE";
export const PRODUCT_DELETE = "PRODUCT_DELETE";

export const CATEGORY_CREATE = "CATEGORY_CREATE";
export const CATEGORY_UPDATE = "CATEGORY_UPDATE";
export const CATEGORY_DELETE = "CATEGORY_DELETE";

///Category Action Start
export function fetchCategories() {

    const request = axios.get(API_URL + CATEGORY_CRUD_URL);
    return {
        type: FETCH_CATEGORY_LIST,
        payload: request
    }
}

export function categoryDetail(categoryId) {
    const request = axios.get(API_URL + CATEGORY_CRUD_URL + "/" + categoryId);
    return {
        type: CATEGORY_DETAIL,
        payload: request
    }
}

export function addCategory(props) {
    var accessToken = localStorage.getItem('accessToken');
    var token = "";
    if (accessToken != null) {
        token = JSON.parse(accessToken);
    }
    var request = axios.post(API_URL + CATEGORY_CRUD_URL, props, {
        'headers': {
            "Authorization": "Bearer " + token.accessToken
        }
    }).catch((error) => {

    });

    return {
        type: CATEGORY_CREATE,
        payload: request
    }
}

export function updateCategory(props) {
    var accessToken = localStorage.getItem('accessToken');
    var token = "";
    if (accessToken != null) {
        token = JSON.parse(accessToken);
    }
    var request = axios.put(API_URL + CATEGORY_CRUD_URL, props, {
        'headers': {
            "Authorization": "Bearer " + token.accessToken
        }
    }).catch((error) => {

    });

    return {
        type: CATEGORY_UPDATE,
        payload: request
    }
}

export function deleteCategory(id) {
    var accessToken = localStorage.getItem('accessToken');
    var token = "";
    if (accessToken != null) {
        token = JSON.parse(accessToken);
    }
    var request = axios.delete(API_URL + CATEGORY_CRUD_URL + "/" + id, {
        'headers': {
            "Authorization": "Bearer " + token.accessToken
        }
    }).catch((error) => {

    });

    return {
        type: CATEGORY_DELETE,
        payload: request
    }
}
///Category Action end


///Product Action Start
export function fetchProducts(categoryId, page) {
    const request = axios.get(API_URL + PRODUCT_LIST_URL + "/" + categoryId + "/" + page);
    return {
        type: FETCH_PRODUCT_LIST,
        payload: request
    }
}

export function fetchAdminProducts(page) {
    var accessToken = localStorage.getItem('accessToken');
    var token = "";
    if (accessToken != null) {
        token = JSON.parse(accessToken);
    }
    var data = { Products: [], PageSize: 0, PageCount: 0 }

    var request = axios.get(API_URL + PRODUCT_CRUD_URL + "/" + page, {
        'headers': {
            "Authorization": "Bearer " + token.accessToken
        }
    }).catch((error) => {
        console.log('Sorry, something is wrong: ' + error);
        if (error.response) {
            // console.log(error.response.data.error_description);
            // console.log(error.response.status);
            // console.log(error.response.headers);

            // tokenData.accessToken = '';
            // tokenData.message = response.data.error_description

        } else {
            console.log('Error', error.message);
            tokenData.accessToken = '';
            tokenData.message = error.message
        }
        console.log(error.config);
    });
    return {
        type: FETCH_ADMIN_PRODUCT_LIST,
        payload: request
    }
}

export function addproduct(props) {

    var accessToken = localStorage.getItem('accessToken');
    var token = "";
    if (accessToken != null) {
        token = JSON.parse(accessToken);
    }
    var request = axios.post(API_URL + PRODUCT_CRUD_URL, props, {
        'headers': {
            "Authorization": "Bearer " + token.accessToken
        }
    }).catch((error) => {

    });

    return {
        type: PRODUCT_CREATE,
        payload: request
    }
}

export function updateProduct(props) {
    var accessToken = localStorage.getItem('accessToken');
    var token = "";
    if (accessToken != null) {
        token = JSON.parse(accessToken);
    }
    var request = axios.put(API_URL + PRODUCT_CRUD_URL, props, {
        'headers': {
            "Authorization": "Bearer " + token.accessToken
        }
    }).catch((error) => {

    });

    return {
        type: PRODUCT_UPDATE,
        payload: request
    }
}

export function deleteProduct(id) {
    var accessToken = localStorage.getItem('accessToken');
    var token = "";
    if (accessToken != null) {
        token = JSON.parse(accessToken);
    }
    var request = axios.delete(API_URL + PRODUCT_CRUD_URL + "/" + id, {
        'headers': {
            "Authorization": "Bearer " + token.accessToken
        }
    }).catch((error) => {

    });

    return {
        type: PRODUCT_DELETE,
        payload: request
    }
}

export function productDetail(productId) {
    const request = axios.get(API_URL + PRODUCT_DETAIL_URL + "/" + productId)
    return {
        type: PRODUCT_DETAIL,
        payload: request
    }
}
///Product Action END

export function login(props) {
    var accessToken = localStorage.getItem('accessToken');
    var tokenData = {
        accessToken: '',
        message: ''
    }


    const data = {
        "Email": props.Email,
        "Password": props.Password
    };
    var request = axios.post(API_URL + ACCES_TOKEN_URL, data).catch((error) => {

    });

    return {
        type: ACCES_TOKEN,
        payload: request
    }

    // var hours = 24; // Reset when storage is more than 24hours
    // var now = new Date().getTime();
    // var setupTime = localStorage.getItem('setupTime');
    // if (setupTime == null) {
    //     1
    //     localStorage.setItem('setupTime', now)
    // } else {
    //     if (now - setupTime > hours * 60 * 60 * 1000) {
    //         localStorage.clear()
    //         localStorage.setItem('setupTime', now);
    //     }
    // }

}

export function addToCart(productId) {
    const request = axios.get(API_URL + PRODUCT_DETAIL_URL + "/" + productId)
    // const request = axios.get(API_URL + PRODUCT_DETAIL_URL + "/" + productId)
    console.log(request);
    return {
        type: ADD_TO_CART,
        payload: request
    }
}
export function fetchCart() {
    return {
        type: FETCH_CART,
        payload: getCart(null)
    }
}

function transformDataToParams(data) {
    var str = [];
    for (var p in data) {
        if (data.hasOwnProperty(p) && data[p]) {
            if (typeof data[p] === 'string') {
                str.push(encodeURIComponent(p) + '=' + encodeURIComponent(data[p]));
            }
            if (typeof data[p] === 'object') {
                for (var i in data[p]) {
                    str.push(encodeURIComponent(p) + '=' + encodeURIComponent(data[p][i]));
                }
            }
        }
    }
    return str.join('&');
}
