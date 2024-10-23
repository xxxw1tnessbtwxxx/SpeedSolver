import styles from './Header.module.css'

export default function Header() {

    return (
        <header className={styles.header}>
            <div className={styles.headerTitle}>SpeedSolver</div>
            <div className={styles.headerButtons}>
                <a href="https://github.com/xxxw1tnessbtwxxx/SpeedSolver" className={styles.headerButton}>Исходный код</a>
            </div>
    </header>
    )

}