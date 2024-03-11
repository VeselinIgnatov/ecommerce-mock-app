import { useState } from "react"
import QuantityInput from "../quantity-input/quantity-input"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faRemove } from '@fortawesome/free-solid-svg-icons';
import './cart-list-item.css'

const CartLineItem = ({ product, updateProduct, deleteProduct }) => {

    console.log('product', product)
    const updateProductQuantity = (newQuantity) => {
        updateProduct(product.id, newQuantity)
    }

    const removeProduct = () => {
        deleteProduct(product.id)
    }

    return (
        <li className='cart-item-line' onChange={() => console.log('change')}>
            <img src={product.imageUrl}></img>
            <div className='item-info-container'>
                <div className='item-info'>
                    <span>{product.name}</span>
                    <span>{'$' + product.price}</span>
                </div>
                <div className='item-actions'>
                    <QuantityInput
                        initialQuantity={product.selectedQuantity}
                        setQuantity={updateProductQuantity}
                        max={product.quantity}
                    />
                    <button className='delete-item-button' onClick={removeProduct}>
                        <FontAwesomeIcon className='remove-item-icon' icon={faRemove} />
                    </button>
                </div>
            </div>
        </li>
    )
}

export default CartLineItem