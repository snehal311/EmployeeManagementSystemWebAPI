using EmployeeManagementSystemWebAPI.Models;

namespace EmployeeManagementSystemWebAPI.Repositories
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllUSers();
        public void AddUser(Employee employee);
        public Employee GetUserById(int id);
        public void UpdateUser(int id, Employee employee);
        public bool DeleteUSer(int id);
    }
}
