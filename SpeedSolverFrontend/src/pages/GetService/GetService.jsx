import styles from './GetService.module.css'
import Header from '../../components/Header/Header'
import { useState } from 'react';
import axios from 'axios';

const GetService = () => {

    const [isLogin, setIsLogin] = useState(true);

    return (
        <>
            <Header/>
            <div>
                <button onClick={() => setIsLogin(!isLogin)}>{isLogin ? "Авторизация" : "Регистрация"}</button>
                <div>
                {isLogin ? <LoginForm /> : <RegisterForm />}
                </div>
            </div>
            
        </>
        
    )
}


const LoginForm = () => {

    const [login, setLogin] = useState('')
    const [password, setPassword] = useState('')

    function makeRequest() {
        var response = axios.post('https://api.speedsolver.ru/v1/auth/authorize', {
            'login': login,
            'password': password
        })
        return response
    }

    const handleSumbit = () => {
        console.log(makeRequest())
    }

    return (
        <form>
            <div className={styles.formMain}>
                <input type="email" placeholder="Email" />
                <input type="password" placeholder="Password" />
                <button type="submit" onClick={handleSumbit}>Login</button>
            </div>
        </form>
    )
}

const RegisterForm = () => {
    return (
        <form>
            <div className={styles.formMain}>

            </div>
        </form>
    )
}

export default GetService