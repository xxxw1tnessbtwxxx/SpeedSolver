import { Route, Routes } from "react-router-dom"
import WelcomePage from "./pages/welcome/WelcomePage"
import LoginPage from "./pages/login/LoginPage"
function App() {
  return (
    <Routes>
      <Route path="/" element={<WelcomePage />} />
      <Route path="/login" element={<LoginPage />} />
    </Routes>  
  )
}

export default App
