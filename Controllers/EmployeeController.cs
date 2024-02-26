using HealthCare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace HealthCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        [HttpPost]
        [Route("AddNewEmployee")]
        public ActionResult AddNewEmployee(EmployeesModel1 employee)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.AddEmployee(employee, connection);

            if (response.StatusCode == 200)
                return Ok(new { Employees = employee, Response = response });
            else
                return Ok(new { Response = response });


        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public ActionResult UpdateEmployee(EmployeesModel1 employee)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.UpdateEmployee(employee, connection);

            if (response.StatusCode == 200)
                return Ok(new { Employees = employee, Response = response });
            else
                return Ok(new { Response = response });

        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        public ActionResult DeleteEmployee(int employeeID)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.DeleteEmployee(employeeID, connection);

            if (response.StatusCode == 200)
                return Ok(new { Employees = employeeID, Response = response });
            else
                return Ok(new { Response = response });
        }
        [HttpGet]
        [Route("GetEmployees")]
        public ActionResult GetEmployee()
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.GetEmployees(connection);

            if (response.listEmployees.Count > 0)
                return Ok(new { Response = response });
            else
                return NoContent();
        }

        [HttpGet]
        [Route("GetByIDEmployee")]
        public ActionResult GetByIDEmployee(int id)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.GetByIDEmployee(id, connection);

            if (response != null)
                return Ok(new { Response = response });
            else
                return NoContent();
        }
        [HttpPost]
        [Route("LoginEmployee")]
        public ActionResult LoginEmployee(LoginModel employee)
        {

            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.LoginEmployee(employee, connection);

            if (response.StatusCode == 200)
                return Ok(new { Employee = employee, Response = response });
            else
                return Ok(new { Response = response });


        }

        [HttpPost]
        [Route("RegistrationEmployee")]
       
        public ActionResult RegistrationEmployee(RegistrationModel employee)
        {

            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.RegistrationEmployee(employee, connection);

            if (response.StatusCode == 200)
                return Ok(new { Employee = employee, Response = response });
            else
                return Ok(new { Response = response });


        }

        [HttpGet]
        [Route("GetDepartments")]
        public ActionResult GetDepartments()
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.GetDepartments(connection);

            if (response.listDepartments.Count > 0)
                return Ok(new { Response = response });
            else
                return NoContent();
        }

    }
}