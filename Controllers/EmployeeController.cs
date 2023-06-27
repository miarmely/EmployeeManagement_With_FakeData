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
    }
}
