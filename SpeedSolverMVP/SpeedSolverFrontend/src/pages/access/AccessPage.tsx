import React, { useState } from "react"
import "../../anystyles/centeredContainer.css"
import "../../anystyles/speedsolveruikit.css"
import PrimaryButton from "../../components/primaryButton/PrimaryButton"

import styles from "./AccessPage.module.css"
import AuthorizationType from "../../types/enums/AuthorizationType"
import axios from "axios"

import API_URL from "../../types/api/api"
import Swal from "sweetalert2"
import { toast, ToastContainer } from "react-toastify"

interface AuthTypeProp {
    action: AuthorizationType
}



const AccessPage: React.FC<AuthTypeProp> = ({ action }) => {

    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")

    async function Register(email: string, password: string) {
        
        const data = {
            'email': email,
            'password': password
        }

        try {
            var response = await axios.post(`${API_URL()}/access/register`, data)
            return response
        }
        catch(error) {
            throw error
        }
    }

    async function Authorize(email: string, password: string) {

        const data = {
            'username': email,
            'password': password
        }

        const headers = {
            'Content-Type': 'application/x-www-form-urlencoded'
        }

        try {
            var response = await axios.post(`${API_URL()}/access/authorize`, data, { headers: headers, withCredentials: true })
            return response
        }
        catch(error) {
            throw error
        }
    }


    const content = action === AuthorizationType.LOGIN ? "Авторизация" : "Регистрация"
    const text = action === AuthorizationType.LOGIN ? "Авторизоваться" : "Зарегистрироваться"
    const desc = action === AuthorizationType.REGISTER ? "Зарегистрируйтесь, используя придуманный логин и пароль" 
    : "Авторизуйтесь, используя логин и пароль"
    return (

        <>
            <div className="centered">
                <div className={styles.formBorder}>
                    <div className="mediaText">
                        <h3>{content}</h3>
                        <p>{desc}</p>
                    </div>

                    <div className={styles.mainForm}>
                        <input type="text" placeholder="Логин" className="defaultInput" onChange={(e) => { setEmail(e.target.value) }}/>
                        <input type="password" placeholder="Пароль" className="defaultInput" onChange={(e) => { setPassword(e.target.value) }}/>
                        <PrimaryButton text={text} onClick={action === AuthorizationType.LOGIN ? 
                            () => Authorize(email, password).then(res => {
                                Swal.fire({
                                    icon: 'success',
                                    title: res.data.access_token,
                                    showConfirmButton: true,
                                })
                            }).catch(() => {
                              toast.error("Что-то пошло не так.")  
                            }) 
                            : () => Register(email, password).then(() => {
                                Swal.fire({
                                    icon: 'success',
                                    title: "Вы успешно зарегистрировались в сервисе. \nСпасибо, что Вы с нами <3",
                                    showConfirmButton: true,
                                })
                            }).catch(() => {toast.error(`Вероятно, такой пользователь уже существует :(`)})}/>
                    </div>

                </div>
            </div>
            <ToastContainer/>
        </>
    )
}

export default AccessPage
