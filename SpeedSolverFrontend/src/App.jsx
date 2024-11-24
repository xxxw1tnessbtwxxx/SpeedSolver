
import Header from './components/Header/Header'
import './App.css'
import InfoCard from './components/InfoCard/InfoCard'
import Description from './components/Description/Description'
import { Route, Router, Routes} from 'react-router-dom'
import GetService from './pages/GetService/GetService'
import WelcomePage from './pages/Welcome/WelcomePage'
export default function App() {

  return (
    <>
      <Routes>
        <Route path='/' element={<WelcomePage/>}/>
        <Route path='/getservice' element={<GetService/>}/>
      </Routes>
    </>
    
  )
}


