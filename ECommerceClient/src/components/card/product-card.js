import React, { useState } from 'react'
import {
    Card,
    CardMedia,
    CardContent,
    Typography,
    Rating
} from '@mui/material';
import StarOutlineIcon from '@mui/icons-material/StarOutline';
import FavoriteBorderOutlinedIcon from '@mui/icons-material/FavoriteBorderOutlined';
import { IconButton } from '@mui/material';
import { useDispatch } from 'react-redux'
import { addToCart } from '../../features/cart-slice'
import QuantityInput from '../quantity-input/quantity-input';
import './product-card.css'

export const ProductCard = ({ product }) => {

    const [quantity, setQuantity] = useState(1)
    const dispatch = useDispatch();

    const addProductToCart = () => {
        dispatch(addToCart({ id: product.id, quantity }));
    }

    return (
        <Card variant='outlined' sx={{ width: 350, borderRadius: 3 }}>
            <CardContent className='card-content content-top'>
                <div className='product-info'>
                    <Typography className='product-name' color='black' sx={{
                        height: '25px',
                        overflow: 'hidden',
                        textOverflow: 'ellipsis',
                        whiteSpace: 'no-wrap',
                        width: '222px'
                    }}>
                        {product.name}
                    </Typography>
                    <Typography sx={{ fontFamily: 'unset' }} className='product-brand' color='grey'>
                        {product.brand.name}
                    </Typography>
                </div>
                <IconButton className='fav-icon' >
                    <FavoriteBorderOutlinedIcon sx={{ verticalAlign: 'sub', color: 'rgb(190, 5, 5)' }} />
                </IconButton>
            </CardContent>
            <CardMedia
                component="img"
                height="194px"
                image={product.imageUrl}
                alt="Paella dish"
            />
            <CardContent className='card-content content-bottom'>
                <Typography className='product-description' color='black'>
                    {'$' + Number(product.price).toFixed(2)}
                </Typography>
                <QuantityInput initialQuantity={quantity} setQuantity={setQuantity} />
                <Typography className='product-rating' color='grey'>
                    <StarOutlineIcon sx={{ verticalAlign: 'sub', color: 'yellow' }} />
                    {Number(product.rating).toFixed(2)}
                </Typography>
            </CardContent>
            <button className='action-button add-to-cart' onClick={addProductToCart}>Add to cart</button>
        </Card>
    )
}