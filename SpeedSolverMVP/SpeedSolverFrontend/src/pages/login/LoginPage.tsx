import "../../anystyles/centeredContainer.css"
import "../../anystyles/speedsolveruikit.css"
import PrimaryButton from "../../components/primaryButton/PrimaryButton"
import styles from "./LoginPage.module.css"
const LoginPage = () => {
    return (
        <>
            <div className="centered">
                <div className={styles.formBorder}>
                    <div className="mediaText">
                        <h3>Авторизация</h3>
                        <p>Авторизуйтесь, используя свой логин и пароль.</p>
                    </div>

                    <div className={styles.mainForm}>
                        <input type="text" placeholder="Логин" className="defaultInput"/>
                        <input type="password" placeholder="Пароль" className="defaultInput"/>
                        <PrimaryButton text="Авторизоваться"/>
                    </div>

                </div>
            </div>
        </>
    )
}

export default LoginPage
