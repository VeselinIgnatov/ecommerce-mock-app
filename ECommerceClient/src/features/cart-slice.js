import React from 'react'
import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

const initialState = {
    items: []
}

const cartSlice = createSlice({
    name: 'cart',
    initialState,
    reducers: {
        addToCart: (state, action) => {

            const index = state.items.findIndex(item => item.id === action.payload.id)
            if (index > -1) {
                state.items[index].quantity += action.payload.quantity
            } else {
                state.items.push(action.payload)
            }
        }
    }
});

export const { addToCart } = cartSlice.actions;
export default cartSlice.reducer;
