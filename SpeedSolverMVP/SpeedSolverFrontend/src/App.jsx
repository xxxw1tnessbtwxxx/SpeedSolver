import './App.css'
import { Route, Router, Routes} from 'react-router-dom'
import WelcomePage from './pages/WelcomePage/WelcomePage'
export default function App() {

  return (
    <>
     <Routes>
        <Route path='/' element={<WelcomePage/>}/>
      </Routes>
    </>
  )
}


