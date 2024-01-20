import React, { useEffect, useState } from "react";
import axios from "axios";
import Headers from "./Headers";
import { useParams } from "react-router-dom";
import { BaseUrl } from "../Constants";

const EditEmployee = () => {
  const { employeeID } = useParams("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [position, setPosition] = useState("");
  const [department, setDepartment] = useState("");
  const [hireDate, setHireDate] = useState("");
  const [salary, setSalary] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [departmentsData, setDepartmentsData] = useState([]);

  useEffect(() => {
    GetEmployeeData();
    GetDepartmentsData();
  }, []);

  const GetEmployeeData = () => {
    axios
      .get(`${BaseUrl}Employee/GetByIDEmployee?id=${employeeID}`)
      .then((result) => {
        setFirstName(result.data.response.employee.firstName);
        setLastName(result.data.response.employee.lastName);
        setPosition(result.data.response.employee.position);
        setDepartment(result.data.response.employee.department);
        setHireDate(result.data.response.employee.hireDate);
        setSalary(result.data.response.employee.salary);
        setEmail(result.data.response.employee.email);
        setPassword(result.data.response.employee.password);
      })
      .then((error) => console.log(error));
  };

  const GetDepartmentsData = () => {
    axios
      .get(`${BaseUrl}Employee/GetDepartments`)
      .then((result) => {
        setDepartmentsData(result.data.response.listDepartments);
      })
      .then((error) => console.log(error));
  };

  const handelNewEmployee = (e) => {
    const apiUrl = "http://localhost:5126/api/Employee/RegistrationEmployee";
    const requestBody = {
      firstName: firstName,
      lastName: lastName,
      position: position,
      department: department,
      hireDate: hireDate,
      salary: salary,
      email: email,
      password: password,
    };
    axios
      .post(apiUrl, requestBody)
      .then((result) => {
        if (result.data.response.statusCode === 200) {
          alert(result.data.response.statusMessage);
        } else {
          alert(result.data.response.statusMessage);
        }
      })
      .catch((error) => {
        console.log(error);
      });
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
          <div className="form-control" placeholder="Enter Department">
            <select
              onChange={(e) => setDepartment(e.target.value)}
              value={department} >
              {departmentsData && departmentsData.length > 0
                ? departmentsData.map((item, index) => {
                    return (
                      <option key={index} value={item.id}>
                        {item.name}
                      </option>
                    );
                  })
                : ""}
            </select>
          </div>
        </div>

        <div className="row">
          <label className="label">HireDate</label>
          <input
            type="datetime"
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
          <button
            className="btn btn-primary"
            onClick={(e) => handelNewEmployee(e)}
          >
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

export default EditEmployee;
