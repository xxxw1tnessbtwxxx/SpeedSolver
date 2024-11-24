import Description from "../../components/Description/Description"
import Header from "../../components/Header/Header"
import InfoCard from "../../components/InfoCard/InfoCard"
import styles from './WelcomePage.module.css'


const WelcomePage = () => {
    return (
        <>
            <Header/>
            <div className={styles.container}>
                <Description/>

                <div className={styles.cards}>
                <InfoCard title="Планируйте." description="Создавайте необходимые задачи."/>
                <InfoCard title="Распределяйте." description="Назначайте сотрудников команды на проекты."/>
                <InfoCard title="Контролируйте." description="Устанавливайте дедлайны."/>
                </div>
            </div>
        </>

    
    )
}

export default WelcomePage