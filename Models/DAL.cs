using System.Data;
using System.Data.SqlClient;

namespace HealthCare.Models
{
    public class DAL
    {
        public Response AddEmployee(EmployeesModel1 employee, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_ManageAddEmployee", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@Position", employee.Position);
            cmd.Parameters.AddWithValue("@Department", employee.Department);
            cmd.Parameters.AddWithValue("@HireDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@Password", employee.Password);
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;

            Response response = new Response();
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }


        public Response UpdateEmployee(EmployeesModel1 employee, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_ManageUpdateEmployee", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@Position", employee.Position);
            cmd.Parameters.AddWithValue("@Department", employee.Department);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@IsActive", employee.IsActive);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@Password", employee.Password);

            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;

            Response response = new Response();
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }
        public Response DeleteEmployee(int employeeID , SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_ManageDeleteEmployee", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;

            Response response = new Response();
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }
        //public List<Employees> GetEmployees(SqlConnection connection)
        public Response GetEmployees(SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_ManageEmployeeList", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            da.SelectCommand.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employees> listEmployees = new List<Employees>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employees employee = new Employees();
                    employee.EmployeeID = Convert.ToInt32(dt.Rows[i]["EmployeeID"]);
                    employee.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    employee.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    employee.Position = Convert.ToString(dt.Rows[i]["Position"]);
                    employee.Department = Convert.ToString(dt.Rows[i]["Department"]);
                    employee.HireDate = Convert.ToDateTime(dt.Rows[i]["HireDate"]);
                    employee.Salary = Convert.ToDecimal(dt.Rows[i]["Salary"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    employee.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    employee.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    listEmployees.Add(employee);
                }
            }
                if (listEmployees.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                    response.listEmployees = listEmployees;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                    response.listEmployees = null;
                }
            
            return response;
        }
        public Response GetByIDEmployee(int id, SqlConnection connection)
        {
            Employees employee = new Employees();
            SqlCommand cmd = new SqlCommand("sp_ManageEmployeeGetById", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeID", id);

            da.SelectCommand.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            da.SelectCommand.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            da.Fill(dt);

            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                employee.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                employee.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                employee.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                employee.Position = Convert.ToString(dt.Rows[0]["Position"]);
                employee.Department = Convert.ToString(dt.Rows[0]["Department"]);
                employee.HireDate = Convert.ToDateTime(dt.Rows[0]["HireDate"]);
                employee.Salary = Convert.ToDecimal(dt.Rows[0]["Salary"]);
                employee.Email = Convert.ToString(dt.Rows[0]["Email"]);
                employee.Password = Convert.ToString(dt.Rows[0]["Password"]);

                response.StatusCode = 200;
                response.StatusMessage = "Employee details found";  Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                response.employee = employee;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Employee details not found"; Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                response.employee = null;
            }
            return response;
        }

        public Response LoginEmployee(LoginModel employee, SqlConnection connection)
        {
            Response response = new Response();

            SqlDataAdapter da = new SqlDataAdapter("sp_ManageEmployeeLogin", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", employee.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", employee.Password);
            da.SelectCommand.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            da.SelectCommand.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if ( dt != null && dt.Rows.Count > 0)
            {
                Employees emp = new Employees();
                emp.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                emp.Email = Convert.ToString(dt.Rows[0]["Email"]);
                emp.Password = Convert.ToString(dt.Rows[0]["Password"]);
                emp.Department = Convert.ToString(dt.Rows[0]["Department"]);
                response.employee = emp;
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(da.SelectCommand.Parameters["@Output_Message"].Value);
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(da.SelectCommand.Parameters["@Output_Message"].Value);
            }

            return response;
        }

        public Response RegistrationEmployee(RegistrationModel employee, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_ManageRegistrationEmployee", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@Position", employee.Position);
            cmd.Parameters.AddWithValue("@Department", employee.Department);
            cmd.Parameters.AddWithValue("@HireDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@Password", employee.Password);
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;

            Response response = new Response();
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }

        public Response GetDepartments(SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_GetDepartmentsList", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Departments> listDepartments = new List<Departments>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Departments departments = new Departments();
                    departments.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    departments.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    departments.Description = Convert.ToString(dt.Rows[i]["Description"]);
                    listDepartments.Add(departments);
                }
            }
            if (listDepartments.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.listDepartments = listDepartments;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.listDepartments = null;
            }

            return response;
        }
    }
}