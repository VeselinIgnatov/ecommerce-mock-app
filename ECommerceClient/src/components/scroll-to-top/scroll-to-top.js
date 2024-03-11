import React, { useState, useEffect } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronUp, faRemove } from '@fortawesome/free-solid-svg-icons';
import './scroll-to-top.css';

const ScrollToTop = () => {
    const [isVisible, setIsVisible] = useState(false);

    useEffect(() => {
        // Function to handle scroll event
        const toggleVisibility = () => {
            if (window.scrollY > 300) {
                setIsVisible(true);
            } else {
                setIsVisible(false);
            }
        };

        // Event listener for scroll
        window.addEventListener('scroll', toggleVisibility);

        // Clean up
        return () => window.removeEventListener('scroll', toggleVisibility);
    }, []);

    const scrollToTop = () => {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    };

    return (
        <div className={`scroll-to-top${isVisible ? ' visible' : ''}`} onClick={scrollToTop}>
            <FontAwesomeIcon icon={faChevronUp} style={{ position: 'relative', top: '10px', left: '12px' }} />
        </div>
    );
};

export default ScrollToTop;