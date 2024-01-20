import React from "react";
import Login from "./components/Login";
import Dashboard from "./components/Dashboard";
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom'
import AddEmployee from "./components/AddEmployee";
import ListEmployee from "./components/ListEmployee";
import EditEmployee from "./components/EditEmployee";
const RouterPage = () => {
    return(
        <>
        <Router>
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/dashboard" element={<Dashboard />} />
                <Route path="/addemployee" element={<AddEmployee />} />
                <Route path="/listemployee" element={<ListEmployee/>} />
                <Route path="/editemployee/:employeeID" element={<EditEmployee/>} />
            </Routes>
        </Router>
        </>
    )
  
}

export default RouterPage;