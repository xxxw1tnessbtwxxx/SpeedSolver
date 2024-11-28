import styles from './WelcomePage.module.css'
import Header from '../../components/header/Header'
import Description from '../../components/Description/Description'
const WelcomePage = () => {
    return (
        <div className={styles.container}>
            <div className={styles.pageHeader}>
                <Header/>
            </div>
            <div className={styles.content}>
                <Description/>
            </div>
        </div>
    )
}

export default WelcomePage