import React, { useEffect, useState } from "react";
import axios from "axios";
import Headers from "./Headers";
import { useNavigate } from "react-router-dom";
const ListEmployee = () => {

    const[employeeData, setEmployeeData] = useState([])
    const[employeeDataUpdate, setEmployeeDataUpdate] = useState(true)
    const navigate = useNavigate();

    useEffect(()=>{
    
        axios.get("http://localhost:5126/api/Employee/GetEmployees")
        .then ((result) => setEmployeeData(result.data.response.listEmployees))
        .then((error) =>console.log(error));
    },[employeeDataUpdate]);

    const editEmployee= (employeeID) => {
        if(employeeID> 0)
        {
            navigate(`/editemployee/${employeeID}`);
        //alert("Editing employee"+employeeID);
        }
    };
    const deleteEmployee = (employeeID)=> {
        if(window.confirm("Are you sure to remove this record?"))
        {
        axios.delete(`http://localhost:5126/api/Employee/DeleteEmployee?employeeID=${employeeID}`)
        .then((result)=>{
            if( result.data.response.statusCode=== 200)
            {
                setEmployeeDataUpdate(false)
                alert(result.data.response.statusMessage);
            }
            else
            {
                alert(result.data.response.statusMessage);
            }
        })
        }
      
    };
    return(
        <>
        <Headers/>
       <table class="table table-hover">
            <thead>
                <tr>
                    <th>EmployeeID</th>
                    <th>FirstName</th>
                    <th>LastName</th>
                    <th>Position</th>
                    <th>Department</th>
                    <th>HireDate</th>
                    <th>Salary</th>
                    <th>Email</th>
                    <th>Password</th>
                   <th colSpan={2}> Actions</th>
                </tr>
            </thead>
      
        <tbody>

        {
            employeeData !== undefined &&  employeeData !==null  &&   employeeData.length >0 
             ?   
            employeeData.map((employee,index) => {
             return(
                <tr key={index}>
                    <td>{employee.employeeID}</td>
                    <td>{employee.firstName}</td>
                    <td>{employee.lastName}</td>
                    <td>{employee.position}</td>
                    <td>{employee.department}</td>
                    <td>{employee.hireDate}</td>
                    <td>{employee.salary}</td>
                    <td>{employee.email}</td>
                    <td>{employee.password}</td>
                    <td>
                        <button type="button" className="btn-btn-primary" onClick={()=>editEmployee(employee.employeeID)}>Edit</button> &nbsp;
                        <button  type="button" className="btn-btn-danger" onClick={()=>deleteEmployee(employee.employeeID)}>Delete</button>
                    </td>
                </tr>

               )
            })
            :
            'No Data Available'
        }
        </tbody>
        </table>
        </>
    )
}
export default ListEmployee;