import { Button, Divider } from 'antd';
import styles from './Header.module.css'
import { Link, Navigate } from 'react-router-dom';

const Header = () => {
    return (
        <header className={styles.headerMain}>
            <div className={styles.container}>
                <h1>SpeedSolver</h1>
                <div className={styles.headerButtons}>
                    <button>
                        <Link to='/login' replace reloadDocument>Login</Link>
                    </button>
                </div>
            </div>
        </header>
    )
}

export default Header