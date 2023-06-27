using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly ILogger<EmployeeController> _logger;


        public EmployeeController(ILogger<EmployeeController> logger) => _logger = logger;


        [HttpGet]
        public IActionResult DisplayEmployees()  // get all employees
        {
            // when database is empty
            if (FakeData.Employees.Count == 0)
                return NotFound(new
                {
                    statusCode = 404,
                    message = "Database Is Empty!.."
                });

            _logger.LogInformation("All Employees Displayed.");
            return Ok(FakeData.Employees);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetEmployee([FromRoute(Name = "id")] int id)
        {
            var entity = FakeData.Employees.Find(e => e.ID == id);

            // when not matched any employee
            if (entity is null)
                return BadRequest(new
                {
                    statusCode = 400,
                    message = $"ID:{id} Isn't Exists On Database!.."
                });

            _logger.LogInformation($"ID:{id} Employee Displayed.");
            return Ok(entity);
        }


        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee newEmployee)
        {
            // when ID is invalid
            if (newEmployee.ID <= 0)
                return BadRequest(new
                {
                    statusCode = 400,
                    message = "ID Must Be Greater Than 0"
                });

            var entity = FakeData.Employees.Find(e => e.ID == newEmployee.ID);

            // when ID is already exists on database.
            if (entity is not null)
                return BadRequest(new
                {
                    statusCode = 400,
                    message = $"ID:{newEmployee.ID} Is Already Exists On Database!.."
                });

            FakeData.Employees.Add(newEmployee);
            _logger.LogInformation($"New Employee Who ID:{newEmployee.ID} Added!..");

            return Ok(newEmployee);
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee([FromRoute(Name = "id")] int id)
        {
            var entity = FakeData.Employees.Find(e => e.ID == id);

            // when ID not exists on database
            if (entity is null)
                return NotFound(new
                {
                    statusCode = 404,
                    message = $"id:{id} Isn't Exists On Database!.."
                });

            FakeData.Employees.Remove(entity);
            _logger.LogWarning($"Employee Who ID:{id} Deleted!..");

            return NoContent();
        }


        [HttpDelete]
        public IActionResult DeleteEmployees()
        {
            // when database is empty
            if (FakeData.Employees.Count == 0)
                return NotFound(new
                {
                    statusCode = 404,
                    message = "Database Is Empty!.."
                });

            FakeData.Employees.Clear();
            _logger.LogWarning("All Employees Deleted!..");

            return NoContent();
        }
    }
}
