import { useEffect, useState } from "react"
import { useSelector } from "react-redux"
import CartLineItem from "../cart-list-item/cart-list-item"
import './cart.css'

const Cart = () => {
    const items = useSelector((state) => state.cart.items)
    const user = useSelector((state) => state.user.user)
    const [products, setProducts] = useState([])

    console.log(user)

    useEffect(() => {
        const fetchProducts = async () => {
            const itemIds = items.map(item => item.id)
            const params = new URLSearchParams();
            itemIds.forEach(id => params.append('ids', id));

            return fetch(`https://localhost:7147/product/getbyids?${params}`)
                .then(response => {
                    return response.json()
                })
                .then(data => {
                    const productsWithQuantities = data.map((product) => {
                        return {
                            ...product,
                            selectedQuantity: items.find((item) => item.id === product.id).quantity
                        }
                    })

                    setProducts(productsWithQuantities)
                    return data
                })
        }

        if (items.length > 0) fetchProducts()
    }, [])

    const updateProduct = (id, quantity) => {

        setProducts(prevProducts => {
            return prevProducts.map(product => {
                if (product.id === id) {
                    return { ...product, selectedQuantity: quantity };
                } else {
                    return product;
                }
            });
        });
    }

    const deleteProduct = (id) => {
        setProducts(prevProducts => {
            return prevProducts.filter(product => product.id !== id);
        });
    }

    const calculateTotalPrice = () => {
        const totalPrice = products.reduce((total, product) => {
            const subtotal = product.selectedQuantity * product.price;
            return total + subtotal;
        }, 0);

        return totalPrice
    }

    const handleCheckout = () => {

        if(Object.keys(user).length === 0) {
            alert('Please register or login to complete your purchase')
        }
    }

    return (
        <div className='cart-container'>
            {products.length > 0
                ?
                <>
                    <ul className='cart-items-list'>
                        {products.map((product) => {
                            return <CartLineItem
                                product={product}
                                updateProduct={updateProduct}
                                deleteProduct={deleteProduct}
                            />
                        })}
                    </ul>
                    <div className='checkout-container'>
                        <h2>Total price: {'$' + calculateTotalPrice()}</h2>
                        <button className='checkout-button' onClick={handleCheckout}>Checkout</button>
                    </div>
                </>
                : <div className='cart-empty'><h1>Cart is empty</h1></div>
            }
        </div>
    )
}

export default Cart