import { Link, useNavigate } from 'react-router-dom';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import { useSelector } from 'react-redux'
import './upper-header.css';

export const UpperHeader = () => {

    const itemCount = useSelector((state) => state.cart.items.length)
    const user = useSelector((state) => state.user)
    const navigate = useNavigate()

    return (
        <div className="upper-header">
            <div>
                <Link to='/'><button className="home-button navbar-button" >Home</button></Link>
            </div>
            <div className="buttons">
                <Link to='sign-in'><button className="sign-in-button navbar-button">Sign in</button></Link>
                <Link to='register'><button className="join-us-button navbar-button">Join us</button></Link>
                <ShoppingCartIcon className='cart-icon-button' sx={{ paddingLeft: '5px' }} onClick={() => navigate('/cart')} />
                {itemCount > 0 && <div className='cart-indicator' >
                    <span>{itemCount}</span>
                </div>}
            </div>
        </div>
    )
}