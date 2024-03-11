import './quantity-input.css'

const QuantityInput = ({ initialQuantity, setQuantity, max = 1000 }) => {

    const handleIncrease = () => {
        setQuantity(initialQuantity < max ? ++initialQuantity : max);
    }

    const handleDecrease = () => {
        setQuantity(initialQuantity - 1 < 1 ? 1 : --initialQuantity);
    }
    return (
        <div className="quantity-input-container">
            <button className="quantity-button" onClick={handleDecrease} disabled={initialQuantity === 1}>-</button>
            <input type="text" className="quantity-number" value={initialQuantity} readOnly />
            <button className="quantity-button" onClick={handleIncrease}>+</button>
        </div>
    )
}

export default QuantityInput