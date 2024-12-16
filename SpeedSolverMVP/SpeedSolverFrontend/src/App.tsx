import { Route, Routes } from "react-router-dom"
import WelcomePage from "./pages/welcome/WelcomePage"
import AccessPage from "./pages/access/AccessPage"
import AuthorizationType from "./types/enums/AuthorizationType"

function App() {
  return (
    <Routes>
      <Route path="/" element={<WelcomePage />} />
      <Route path="/login" element={<AccessPage action={AuthorizationType.LOGIN} />} />
      <Route path="/register" element={<AccessPage action={AuthorizationType.REGISTER}/>}/>
    </Routes>  
  )
}

export default App
