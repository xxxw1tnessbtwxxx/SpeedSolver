
import Header from './components/Header/Header'
import './App.css'
import InfoCard from './components/InfoCard/InfoCard'
import Description from './components/Description/Description'
export default function App() {

  return (
    <>
      <Header/>
      <div className="container">
        <Description/>

        <div className="cards">
          <InfoCard title="Планируйте." description="Создавайте необходимые задачи."/>
          <InfoCard title="Распределяйте." description="Назначайте сотрудников команды на проекты."/>
          <InfoCard title="Контролируйте." description="Устанавливайте дедлайны."/>
        </div>
      </div>
    </>
    
  )
}


