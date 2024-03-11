import React, { useState } from 'react'
import { useDispatch } from 'react-redux';
import { searchProducts, getProducts } from '../../features/product-slice'
import './search.css';

export const Search = () => {

    const dispatch = useDispatch();
    const [search, setSearch] = useState('');

    const handleInput = (e) => {
        setSearch(e.target.value)
    }
    const handleSearch = () => {

        const str = search;
        setSearch('');

        if (str) {
            dispatch(searchProducts(str));

        } else {
            dispatch(getProducts());
        }

    }
    return (
        <div className='search-container'>
            <input placeholder="Enter product name" onChange={handleInput} value={search}/>
            <button onClick={handleSearch}>Search</button>
        </div>)
}