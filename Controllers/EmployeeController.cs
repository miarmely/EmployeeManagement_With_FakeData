using EmployeeManagement.Data;
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
        public IActionResult getEmployee([FromRoute(Name = "id")] int id)
        {
            // when not matched any employee
            var entity = FakeData.Employees.Find(e => e.ID == id);
            if (entity is null)
                return BadRequest(new
                {
                    statusCode = 400,
                    message = $"ID:{id} Is Not Exists On Database!.."
                });

            _logger.LogInformation($"ID:{id} Employee Displayed.");
            return Ok(entity);
        }
    }
}
