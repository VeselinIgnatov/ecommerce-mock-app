import { configureStore } from "@reduxjs/toolkit";
import productReducer from '../features/product-slice'
import cartReducer from '../features/cart-slice'
import userReducer from '../features/user-slice'
import { combineReducers } from 'redux';

const reducer = combineReducers({
    products: productReducer,
    cart: cartReducer,
    user: userReducer
})
const store = configureStore({
    reducer
});

export default store;

