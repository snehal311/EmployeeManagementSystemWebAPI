using EmployeeManagementSystemWebAPI.Models;

namespace EmployeeManagementSystemWebAPI.Services
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllUSers();
        public void AddUser(Employee employee);
        public Employee GetUserById(int id);
        public void UpdateUser(int id,Employee employee);
        public bool DeleteUSer(int id);
    }
}
