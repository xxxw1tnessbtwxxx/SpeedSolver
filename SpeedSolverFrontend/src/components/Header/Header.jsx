import styles from './Header.module.css'

const Header = () => {
    return (
        <div className={styles.header}>
            <h1 className={styles.headerText}>SpeedSolver</h1>
            <div className={styles.headerButtons}>
                <button>Исходный код</button>
                <button>Начать пользоваться</button>
            </div>
        </div>
    )
}

export default Header