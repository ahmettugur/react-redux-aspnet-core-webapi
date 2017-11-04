import { combineReducers } from 'redux';
import Categories from "./reducer_categories";
import Products from "./reducer-products";
import Cart from "./reducer_cart";
import AccessToken from "./reducer-token";
import { reducer as formReducer } from 'redux-form';


const rootReducer = combineReducers({
  categories: Categories,
  products: Products,
  cart: Cart,
  accessToken: AccessToken,
  form: formReducer
});

export default rootReducer;

// const reducers = {
//   categoryList: CategoryList,
//   products: ProductList,
//   // product: Product,
//   adminProducts: AdminProductList,
//   cart: Cart,
//   accessToken: AccessToken,
//   form: formReducer     // <---- Mounted at 'form'
// }

// const rootReducer = combineReducers(reducers)

// export default rootReducer
