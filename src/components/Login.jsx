import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
const Login = () =>{

    const [email,setEmail]=useState("");
    const [password,setPassword]=useState(""); 
    const navigate = useNavigate();

    const handleLogin = (e) =>{
        debugger
       const apiUrl='http://localhost:5126/api/Employee/LoginEmployee'; 
        const requestBody={
            "email": email,
            "password": password
          };
          axios.post(apiUrl,requestBody)
          .then((result) =>{
            if (result.data.response.statusCode === 200)
            {
                localStorage.setItem("logedInUserEmail",result.data.employee.email)
                navigate("/dashboard")
                //alert(result.data.response.statusMessage)
            }
           else
           {
            alert(result.data.response.statusMessage)
           }
           })
           .catch((error)=>{
            console.log(error)
           })


         //alert(`Email is ${email} , Password is ${password}`);
    };
    return(
        <div className ='container' style={{ width: "50%", margin: "0 auto" }}>
           <div className ='row'>
           <label className = 'label'>Email</label>
           <input type = "text" className = 'form-control' placeholder='Enter Email' onChange={(e)=>setEmail(e.target.value)}
           value={email}/>
           </div>

           <div className ='row'>
           <label className = 'label'>Password</label>
           <input type = "password" className = 'form-control' placeholder='Enter Password' onChange={(e)=>setPassword(e.target.value)}
           value={password}/>
           </div>

           <div className ='row'>
           
           <button className = 'btn btn-primary'onClick={(e)=>handleLogin(e)} >
            {""}
            Login{""}
            </button>&nbsp;
           <button className = 'btn btn-danger' >Cancel</button>&nbsp;
           </div>
           
           
        </div>
    )
}
export default Login;