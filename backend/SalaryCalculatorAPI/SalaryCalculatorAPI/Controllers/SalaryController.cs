using Microsoft.AspNetCore.Mvc;
using SalaryCalculatorAPI.Handlers;
using SalaryCalculatorAPI.Models;

namespace SalaryCalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaryController : ControllerBase
    {


        private readonly ISalaryCalculator _salaryHandler;

        //service is injected to the controller via constructor injection
        public SalaryController(ISalaryCalculator salaryHandler) 
        {
            _salaryHandler = salaryHandler;
        }

        
        [HttpGet]
        public string Get() //just a wellcome message
        {
            return "wellcome to the Salary Calculator By @Hod Magori";
        }


        //listen for requests from clients to proccess new data
        [HttpPost("IncreaseSalaryCalc")]
        public IActionResult IncreaseSalaryCalc([FromBody] SalaryInputModel UserInput)
        {
            try
            {
            if (UserInput == null) {return BadRequest("Invalid Form Data");}//check if input is null

            var result = _salaryHandler.CalculateSalary(UserInput); //calling the handler, sending the data

                //data is turned into array with values for convenience
                var resultAsArray = result.GetType()
                                     .GetProperties()
                                     .Select(prop => prop.GetValue(result))
                                     .ToArray();
                return Ok(resultAsArray);
            }
            catch (Exception error)
            {                
                return BadRequest(error.Message);
            }



        }


    }
}
