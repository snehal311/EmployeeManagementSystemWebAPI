using EmployeeManagementSystemWebAPI.Data;
using EmployeeManagementSystemWebAPI.Models;
using EmployeeManagementSystemWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService= employeeService;
        }
        public ActionResult Index()
        {
            return View();   
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        [HttpGet("GetEmployee")]
        public ActionResult<List<Employee>> Create()
        {
            var employee = _employeeService.GetAllUSers();
            if (employee==null || employee.Count==0)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: EmployeeController/Create
        [HttpPost("AddEmployee")]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] Employee employee)
        {
            try
            {
                if(employee == null)
                {
                    return BadRequest("Data should be empty");
                }
                _employeeService.AddUser(employee);
                return CreatedAtAction("Create",new { message = "Added Successfully" });
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("GetEmployee/{ID}")]
        public ActionResult<Employee> GetEmployeeByID(int ID)
        {
            if(ID == 0)
            {
                return BadRequest("Id cannot be 0");
            }
            return _employeeService.GetUserById(ID);
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPut("UpdateEmployee/{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromBody] Employee collection)
        {
            try
            {
                if(id == 0)
                {
                    return BadRequest();
                }
                _employeeService.UpdateUser(id, collection);
                return Ok(new { message="Edited" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: EmployeeController/Delete/5
        [HttpDelete("DeleteEmployee")]
        public ActionResult Delete(int id)
        {
            _employeeService.DeleteUSer(id);
            return Ok(new { message = "Deleted" });
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
