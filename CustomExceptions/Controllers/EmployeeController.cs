using CustomExceptions.Domain;
using CustomExceptions.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomExceptions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        EmployeeManager employeeManager;

        public EmployeeController()
        {
            employeeManager= new EmployeeManager();
        }


        [HttpPost("SaveEmployee")]
        public void SaveEmployeeDetails([FromBody] EmployeeRequest employeeRequest) {

            employeeManager.SaveEmployeeDetails(employeeRequest);
        
        }

        [HttpGet("GetEmployee")]
        public EmployeeResponse GetEmployeeDetails(int id) {

           return employeeManager.GetEmployeeDetails(id);
        
        }
    }
}
