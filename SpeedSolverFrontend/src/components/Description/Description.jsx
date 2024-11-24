import styles from './Description.module.css'


export default function Description() {
    return (
        <div className={styles.welcomeText}>
          <h2>Добро пожаловать в SpeedSolver</h2>
          <p>SpeedSolver - ваш помощник в управлении ресурсами вашей команды.</p> 
        </div>
    )
}