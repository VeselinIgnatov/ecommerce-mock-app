import React from 'react'
import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

const initialState = {
    products: [],
    loading: false,
    error: null
}

export const getProducts = createAsyncThunk('products/getProducts', () => {
    return fetch("https://localhost:7147/product/getall")
        .then(response => {
            return response.json()
        })
        .then(data => {
            console.log(data)
            return data
        })
})

export const searchProducts = createAsyncThunk('products/search', (search) => {
    return fetch("https://localhost:7147/product/search" + `?search=${search}`)
        .then(response => {
            return response.json()
        })
        .then(data => {
            return data
        })
})

const productSlice = createSlice({
    name: 'products',
    initialState,
    extraReducers: (builder) => {
        builder.addCase(getProducts.pending, (state, action) => {
            state.loading = true;
        })
        builder.addCase(getProducts.fulfilled, (state, action) => {
            state.products = action.payload
            state.loading = false;
        })
        builder.addCase(getProducts.rejected, (state, action) => {
            state.products = []
            state.loading = false;
            state.error = "ERROR"
        })
        builder.addCase(searchProducts.pending, (state, action) => {
            state.loading = true;
        })
        builder.addCase(searchProducts.fulfilled, (state, action) => {
            state.products = action.payload
            state.loading = false;
        })
        builder.addCase(searchProducts.rejected, (state, action) => {
            state.products = action.payload
            state.loading = false;
            state.error = "ERROR"
        })        
    }
});

export default productSlice.reducer;
