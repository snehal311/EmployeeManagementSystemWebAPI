using EmployeeManagementSystemWebAPI.Data;
using EmployeeManagementSystemWebAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemWebAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public ApplicationDbContext dbContext;
        public EmployeeRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void AddUser(Employee employee)
        {
            try
            {

                Employee employee2 = new Employee()
                {
                    name=employee.name,
                    email=employee.email,
                    phone=employee.phone,
                    department=employee.department,
                    position=employee.position,
                };

                dbContext.Employees.Add(employee2);
                dbContext.SaveChanges();
                
            }
            catch (Exception ex) { }
        }

        public bool DeleteUSer(int id)
        {
            try
            {
                var employeeExist = dbContext.Employees.Where(e => e.id==id).FirstOrDefault();

                if (employeeExist!=null)
                {
                    dbContext.Employees.Remove(employeeExist);
                    dbContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<Employee> GetAllUSers()
        {
            List<Employee> list = new List<Employee>();
            try
            {
                list=dbContext.Employees.ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public Employee GetUserById(int id)
        {
            Employee employee = new Employee();
            try
            {
                var employeeDetails = dbContext.Employees.Where(s => s.id==id);
                employee=employeeDetails.FirstOrDefault();
            }
            catch(Exception ex)
            {

            }
            return employee;
        }

        public void UpdateUser(int id,Employee collection)
        {
            try
            {
                var isemployeeExists = dbContext.Employees.FirstOrDefault(e => e.id==id);
                if (isemployeeExists!=null)
                {
                    isemployeeExists.name=collection.name;
                    isemployeeExists.email=collection.email;
                    isemployeeExists.phone=collection.phone;
                    isemployeeExists.position=collection.position;
					dbContext.SaveChanges();
				}
                
            }
            catch(Exception ex)
            {

            }
        }
    }
}
