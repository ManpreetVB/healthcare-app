﻿namespace HealthCare.Models
{
    public class Employees
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public string Department{ get; set; }

        public DateTime HireDate  { get; set; }

        public decimal  Salary{ get; set; }

        public int IsActive { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
