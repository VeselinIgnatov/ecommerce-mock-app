import React from 'react'
import { CircularProgress } from '@mui/material'
import './spinner.css'

export const Spinner = () => {
    return (
        <div className='whole-page-spinner'>
            <CircularProgress />
        </div>
    )
}