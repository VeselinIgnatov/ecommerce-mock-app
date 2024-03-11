import React, { useEffect, useState } from 'react'
import { ProductCard } from '../card/product-card'
import { useDispatch, useSelector } from 'react-redux'
import { getProducts } from '../../features/product-slice'
import { Spinner } from '../shared/spinner'
import './card-list.css'


export const CardList = () => {

    const dispatch = useDispatch();
    const productState = useSelector((state) => state.products);
    const loading = productState.loading;
    const products = productState.products;

    useEffect(() => {

        dispatch(getProducts())
    }, [])

    return (
        <div className='card-list'>
            {loading ? <Spinner />
                : products.length !== 0 ?
                    <ul>
                        {products.map((product) => {
                            return <li key={product.id}><ProductCard product={product}></ProductCard></li>
                        })
                        }
                    </ul>
                    : <div className="no-products-found">
                        <span>NO PRODUCTS FOUND</span>
                    </div>
            }
        </div>
    )
}