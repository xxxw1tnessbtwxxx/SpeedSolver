
import Header from './components/Header/Header'
import './App.css'
import InfoCard from './components/InfoCard/InfoCard'
import Description from './components/Description/Description'
import { Route, Router, Routes} from 'react-router-dom'
import Login from './pages/Login'
import WelcomePage from './pages/WelcomePage'
export default function App() {

  return (
    <>
      <Header/>
      <Routes>
        <Route path='/' element={<WelcomePage/>}/>
        <Route path='/login' element={<Login/>}/>
      </Routes>
    </>
    
  )
}


