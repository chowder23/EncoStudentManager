import logo from "./logo.svg";
import "./App.css";

import { StudentStatistics } from "./pages/StudentStatistics";
import { AllStudent } from "./pages/AllStudent";
import { Navigation } from "./components/Navigation";

import { BrowserRouter, Route, Routes } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <div className="container">
        <h3 className="m-3 d-flex justify-content-center">Student manager for EN-CO</h3>

        <Navigation />

        <Routes>
          <Route exact path="/" element={<AllStudent />} />
          <Route exact path="/statistics" element={<StudentStatistics />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
