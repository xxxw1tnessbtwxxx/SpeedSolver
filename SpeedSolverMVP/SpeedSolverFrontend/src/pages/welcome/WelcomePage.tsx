import PrimaryButton from "../../components/primaryButton/PrimaryButton"
import styles from "./WelcomePage.module.css"
import "../../swalfire.css"
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Swal from "sweetalert2";
const WelcomePage = () => {
    
    return (
        <div className={styles.container}>

            <div className={styles.description}>
                <h1 className={styles.title}>SpeedSolver</h1>
                <p>SPEEDSOLVER — это система управления проектами, предназначенная для эффективного управления командами, проектами, задачами, подзадачами и дедлайнами. Проект помогает командам организовать свою работу, отслеживать прогресс и достигать поставленных целей в срок.</p>
            </div>

            <div className={styles.contentButtons}>
                <PrimaryButton text="Авторизоваться" onClick={() => {
                    toast.success("asd", {
                        position: "top-right",
                        autoClose: 5000,
                        hideProgressBar: false
                    })
                }}/>
                <PrimaryButton text="Зарегистрироваться" onClick={() => {
                    Swal.fire({
                        title: 'Авторизация',
                        text: 'В разработке',
                        icon: 'info',
                        confirmButtonText: 'OK'     
                    })
                }}/>
            </div>
            <ToastContainer/>
        </div>
    )
}

export default WelcomePage