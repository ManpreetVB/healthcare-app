namespace HealthCare.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Employees> listEmployees { get; set; }
        public Employees employee { get; set; }


        public List<Departments> listDepartments { get; set; }

}
}
