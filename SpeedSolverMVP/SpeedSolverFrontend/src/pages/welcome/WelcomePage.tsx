import PrimaryButton from "../../components/primaryButton/PrimaryButton"
import styles from "./WelcomePage.module.css"
import "../../swalfire.css"
import 'react-toastify/dist/ReactToastify.css';
import { Link } from "react-router-dom";
const WelcomePage = () => {

    return (
        <div className={styles.container}>

            <div className={styles.description}>
                <h1 className={styles.title}>SpeedSolver</h1>
                <p>SPEEDSOLVER — это система управления проектами, предназначенная для эффективного управления командами, проектами, задачами, подзадачами и дедлайнами. Проект помогает командам организовать свою работу, отслеживать прогресс и достигать поставленных целей в срок.</p>
            </div>

            <div className={styles.contentButtons}>
                <Link to="/login">
                    <PrimaryButton text="Авторизоваться"/>
                </Link>
                <Link to="/register">
                    <PrimaryButton text="Зарегистрироваться"/>
                </Link>
            </div>
        </div>
    )
}

export default WelcomePage