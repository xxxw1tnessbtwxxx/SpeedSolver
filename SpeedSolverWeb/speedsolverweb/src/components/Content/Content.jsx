import styles from './Content.module.css'

export default function Content() {
    return (
        <div className={styles.content}>
          <div className={styles.leftColumn}>
            <div className={styles.buttonWrapper}>
              <a href="/start" className={styles.button}>Начать пользоваться</a>
            </div>
            <div className={styles.buttonWrapper}>
              <a href="/first-time" className={styles.button}>Я тут первый раз</a>
            </div>
          </div>
          <div className={styles.rightColumn}>
            <div className={styles.description}>
              <h2>О проекте</h2>
              <p>
                Speedsolver — это уникальное приложение, которое помогает пользователям быстро и эффективно решать различные задачи. Наше приложение предлагает множество функций, которые делают процесс работы максимально удобным и продуктивным.
              </p>
              <p>
                Мы стремимся к тому, чтобы наши пользователи могли легко и быстро находить решения для своих задач, независимо от их сложности. Speedsolver — это ваш надежный помощник в повседневной работе.
              </p>
            </div>
          </div>
        </div>
      );
}