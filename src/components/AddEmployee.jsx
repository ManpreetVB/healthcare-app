import React, { useState } from "react";
import axios from "axios";
import Headers from "./Headers";

const AddEmployee = () => {
  const [firstName,setFirstName]=useState("");
  const [lastName,setLastName]=useState("");
  const [position,setPosition]=useState("");
  const [department,setDepartment]=useState("");
  const [hireDate,setHireDate]=useState("");
  const [salary,setSalary]=useState("");
  const [email,setEmail]=useState("");
  const [password,setPassword]=useState("");

  const handelNewEmployee = (e) => {
    const apiUrl = 'http://localhost:5126/api/Employee/RegistrationEmployee' ;
    const requestBody={
      "firstName": firstName,
      "lastName": lastName,
      "position": position,
      "department": department,
      "hireDate": hireDate,
      "salary": salary,
      "email": email,
      "password": password
    };
    axios.post(apiUrl,requestBody)
    .then((result) => {
      if(result.data.response.statusCode === 200)
      {
        alert(result.data.response.statusMessage);
      }
      else{
        alert(result.data.response.statusMessage);
      }
    })
    .catch((error) => {
      console.log(error)
    })
  };
  return (
    <>
    
    
    <div className="container" style={{ width: "50%", margin: "0 auto" }}>
        <div className="row">
        <label className="label">FirstName</label>
        <input
          type="text"
          className="form-control"
          placeholder="Enter First Name"
          onChange={(e) => setFirstName(e.target.value)}
          value={firstName}
        />
      </div>

     
        <div className="row">
        <label className="label">LastName</label>
        <input
          type="text"
          className="form-control"
          placeholder="Enter Last Name"
          onChange={(e) => setLastName(e.target.value)}
          value={lastName}
        />
      </div>

      <div className="row">
        <label className="label">Position</label>
        <input
          type="text"
          className="form-control"
          placeholder="Enter Position"
          onChange={(e) => setPosition(e.target.value)}
          value={position}
        />
      </div> 

      <div className="row">
      <label className="label">Department</label>
        <div className="form-control"
          placeholder="Enter DepartmentId"
          >
       
        <select onChange={(e) => setDepartment(e.target.value)}
          value={department} >
        <option value="#"></option>
        <option value="#">Internal Medicine</option>
        <option value="#">Cardiology</option>  
        <option value="#">HealthResource</option>  
        <option value="#"> Medical Care</option>  
          </select>
          
       </div> 
       </div>

       <div className="row">
        <label className="label">HireDate</label>
        <input
          type="date"
          className="form-control"
          placeholder="Enter HireDate"
          onChange={(e) => setHireDate(e.target.value)}
          value={hireDate}
        />
      </div>
      <div className="row">
        <label className="label">Salary</label>
        <input
          type="text"
          className="form-control"
          placeholder="Enter Salary"
          onChange={(e) => setSalary(e.target.value)}
          value={salary}
        />
      </div>

        <div className="row">
        <label className="label">Email</label>
        <input
          type="text"
          className="form-control"
          placeholder="Enter Email"
          onChange={(e) => setEmail(e.target.value)}
          value={email}
        />
      </div> 

            <div className="row">
        <label className="label">Password</label>
        <input
          type="password"
          className="form-control"
          placeholder="Enter Password"
          onChange={(e) => setPassword(e.target.value)}
          value={password}
        />
      </div>    

      <br></br>
      <div className="row">
        <button className="btn btn-primary" onClick={(e) => handelNewEmployee(e)}>
          {" "}
          Submit{" "}
        </button>
        &nbsp;
        <button className="btn btn-danger">Clear</button>
      </div>
    </div>
    </>
  );
   
  
};

export default AddEmployee;
