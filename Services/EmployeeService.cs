using EmployeeManagementSystemWebAPI.Models;
using EmployeeManagementSystemWebAPI.Repositories;

namespace EmployeeManagementSystemWebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void AddUser(Employee employee)
        {
             _employeeRepository.AddUser(employee);
        }

        public bool DeleteUSer(int id)
        {
            return (_employeeRepository.DeleteUSer(id));
        }

        public List<Employee> GetAllUSers()
        {
            return _employeeRepository.GetAllUSers();
        }

        public Employee GetUserById(int id)
        {
            return _employeeRepository.GetUserById(id);
        }

        public void UpdateUser(int id, Employee employee)
        {
             _employeeRepository.UpdateUser(id,employee);
        }
    }
}
