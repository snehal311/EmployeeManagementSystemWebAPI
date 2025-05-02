using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemWebAPI.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string email {  get; set; }
        public string phone { get; set; }
        public string department { get; set; }
        public string position {  get; set; }
    }
}
