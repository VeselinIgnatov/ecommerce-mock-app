import { HeaderContainer } from './components/header-container/header-container'
import { RegistrationForm } from './components/forms/registration-form';
import { SignInForm } from './components/forms/sign-in-form';
import Cart from './components/cart/cart'
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Container } from './components/container/content-container'
import ScrollToTop from './components/scroll-to-top/scroll-to-top';
import './App.css';

function App() {
  return (
    <div className="App">
      <HeaderContainer />
      <Routes>
        <Route path="/" element={<Container />} />
        <Route path="register" element={<RegistrationForm />} />
        <Route path="sign-in" element={<SignInForm />} />
        <Route path="cart" element={<Cart />} />
      </Routes>
      <ScrollToTop />
    </div>
  );
}

export default App;
