using EmployeeManagementSystemWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemWebAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
