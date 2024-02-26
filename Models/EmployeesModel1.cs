namespace HealthCare.Models
{
    public class EmployeesModel1
    {
        public int EmployeeID { get; set; }
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Position { get; set; }

        public String Department{ get; set; }

        public DateTime HireDate  { get; set; }

        public Decimal  Salary{ get; set; }

        public int IsActive { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
