import PrimaryButton from "../../components/primaryButton/PrimaryButton"
import styles from "./WelcomePage.module.css"

const WelcomePage = () => {
    return (
        <div className={styles.container}>

            <div className={styles.description}>
                <h1>SpeedSolver</h1>
            </div>

            <div className={styles.contentButtons}>
                <PrimaryButton text="123"/>
            </div>
        </div>
    )
}

export default WelcomePage