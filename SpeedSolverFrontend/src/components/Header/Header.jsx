import { Button, Divider } from 'antd';
import styles from './Header.module.css'


export default function Header() {
    return (
        <header className={styles.headerMain}>
            <div className={styles.container}>
                <h1>SpeedSolver</h1>
                <div className={styles.headerButtons}>
                    <Button type='primary'>Login</Button>
                    <Button type='primary'>Register</Button>
                </div>
            </div>
            <Divider/>
        </header>
    )
}