import React from "react"
import "../../anystyles/centeredContainer.css"
import "../../anystyles/speedsolveruikit.css"
import PrimaryButton from "../../components/primaryButton/PrimaryButton"

import styles from "./AccessPage.module.css"
import AuthorizationType from "../../types/enums/AuthorizationType"

interface AuthTypeProp {
    action: AuthorizationType
}


const AccessPage: React.FC<AuthTypeProp> = ({ action }) => {

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
                        <input type="text" placeholder="Логин" className="defaultInput"/>
                        <input type="password" placeholder="Пароль" className="defaultInput"/>
                        <PrimaryButton text={text}/>
                    </div>

                </div>
            </div>
        </>
    )
}

export default AccessPage
