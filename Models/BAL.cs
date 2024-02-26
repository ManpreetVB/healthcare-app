using System.Data.SqlClient;

namespace HealthCare.Models
{
    public class BAL
    {
        public Response AddEmployee(EmployeesModel1 employee, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.AddEmployee(employee, connection);
        }

        public Response UpdateEmployee(EmployeesModel1 employee, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.UpdateEmployee(employee, connection);
        }
        public Response DeleteEmployee(int employeeID, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.DeleteEmployee(employeeID, connection);
        }
        public Response GetEmployees(SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.GetEmployees(connection);
        }

        public Response GetByIDEmployee(int id, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.GetByIDEmployee(id, connection);

        }
        public Response LoginEmployee(LoginModel employee, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.LoginEmployee(employee, connection);

        }

        public Response RegistrationEmployee(RegistrationModel employee, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.RegistrationEmployee(employee, connection);
        }

        public Response GetDepartments(SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.GetDepartments(connection);
        }
    }
}