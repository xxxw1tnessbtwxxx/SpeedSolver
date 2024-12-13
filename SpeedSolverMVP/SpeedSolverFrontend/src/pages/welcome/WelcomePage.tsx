import PrimaryButton from "../../components/primaryButton/PrimaryButton"
import styles from "./WelcomePage.module.css"
import "../../swalfire.css"
import 'react-toastify/dist/ReactToastify.css';
import axios from "axios";
import API_URL from "../../types/api/api";
import { ToastContainer } from "react-toastify";
const WelcomePage = () => {
    
    const authorize = async () => {
        const response = await axios.post(`${API_URL()}/access/authorize`, {
            'username': 'string',
            'password': 'string'
        }, {
            headers: {
                'accept': 'application/json',
                'Content-Type': 'application/x-www-form-urlencoded',
            }
        })

        console.log(response.data)
        
    }

    return (
        <div className={styles.container}>

            <div className={styles.description}>
                <h1 className={styles.title}>SpeedSolver</h1>
                <p>SPEEDSOLVER — это система управления проектами, предназначенная для эффективного управления командами, проектами, задачами, подзадачами и дедлайнами. Проект помогает командам организовать свою работу, отслеживать прогресс и достигать поставленных целей в срок.</p>
            </div>

            <div className={styles.contentButtons}>
                <PrimaryButton text="Авторизоваться" onClick={authorize}/>
                <PrimaryButton text="Зарегистрироваться"/>
            </div>
            <ToastContainer/>
        </div>
    )
}

export default WelcomePage