import React from 'react'
import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from 'axios'


export const registerUser = createAsyncThunk('user/registerUser', (user) => {

    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
            'Accept': 'application/json',
        },
        body: JSON.stringify({ command: user })
    }


    return fetch("https://localhost:7147/user/register", requestOptions)
        .then(response => {
            return response.json()
        })
        .then(data => {
            return data
        })
})

export const loginUser = createAsyncThunk('user/login', (credentials) => {

    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
            'Accept': 'application/json',
        },
        body: JSON.stringify(credentials)
    }

    return fetch("https://localhost:7147/user/login/", requestOptions)
        .then(response => {
            return response.json()
        })
        .then(data => {
            return data
        })
})

const initialState = {
    user: {},
    loadging: false,
    error: null
}

const userSlice = createSlice({
    name: 'user',
    initialState,
    extraReducers: (builder) => {
        builder.addCase(registerUser.pending, (state, action) => {
            state.loading = true;
        })
        builder.addCase(registerUser.fulfilled, (state, action) => {
            state.user = action.payload
            state.loading = false;
        })
        builder.addCase(registerUser.rejected, (state, action) => {
            state.user = {}
            state.loading = false;
            state.error = "ERROR"
        })
        builder.addCase(loginUser.pending, (state, action) => {
            state.loading = true;
        })
        builder.addCase(loginUser.fulfilled, (state, action) => {
            state.user = action.payload
            state.loading = false;
        })
        builder.addCase(loginUser.rejected, (state, action) => {
            state.user = {}
            state.loading = false;
            state.error = "ERROR"
        })
    }
});

export default userSlice.reducer;
