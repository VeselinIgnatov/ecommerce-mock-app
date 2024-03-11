import React, { useState } from 'react'
import { useDispatch } from 'react-redux'
import { loginUser } from '../../features/user-slice'

import './sign-in-form.css'

export const SignInForm = () => {

    const dispatch = useDispatch();

    const [values, setValues] = useState({
        email: "",
        password: ""
    });

    const handleInputChange = (event) => {
        /* event.persist(); NO LONGER USED IN v.17*/
        event.preventDefault();

        const { name, value } = event.target;
        setValues((values) => ({
            ...values,
            [name]: value
        }));

    };

    const [submitted, setSubmitted] = useState(false);
    const [valid, setValid] = useState(false);

    const handleSubmit = (e) => {
        e.preventDefault();
        if (values.firstName && values.lastName && values.email) {
            setValid(true);
        }
        setSubmitted(true);
        dispatch(loginUser(values));

    };

    return (
        <div className="form-container">
            <form className="register-form" onSubmit={handleSubmit}>
                {submitted && valid && (
                    <div className="success-message">
                        <h3>
                            {" "}
                            Welcome {values.firstName} {values.lastName}{" "}
                        </h3>
                        <div> Your registration was successful! </div>
                    </div>
                )}
                {!valid && (
                    <input
                        className="form-field"
                        type="email"
                        placeholder="Email"
                        name="email"
                        value={values.email}
                        onChange={handleInputChange}
                    />
                )}

                {submitted && !values.email && (
                    <span id="email-error">Please enter an email address</span>
                )}
                {!valid && (
                    <input
                        className="form-field"
                        type="password"
                        placeholder="Password"
                        name="password"
                        value={values.password}
                        onChange={handleInputChange}
                    />
                )}

                {submitted && !values.firstName && (
                    <span id="first-name-error">Please enter a valid password</span>
                )}
                {!valid && (
                    <button className="form-field" type="submit">
                        Sign in
                    </button>
                )}
            </form>
        </div>
    );
}