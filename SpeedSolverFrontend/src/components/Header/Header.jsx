import { Button, Divider } from 'antd';
import styles from './Header.module.css'
import { Link, Navigate } from 'react-router-dom';

const Header = () => {
    return (
        <header className={styles.headerMain}>
            <div className={styles.container}>
                <h1>SpeedSolver</h1>
                <div className={styles.headerButtons}>
                    <button className={styles.headerButton}><Link to='/getservice' className={styles.nounderline} replace reloadDocument>Начать пользоваться</Link></button>
                    <button className={styles.headerButton}><Link to='https://github.com/w1tnessbtwwwww/SpeedSolver' className={styles.nounderline} replace reloadDocument>Исходный код</Link></button>
                </div>
            </div>
        </header>
    )
}

export default Header