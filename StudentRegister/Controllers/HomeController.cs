using Microsoft.AspNetCore.Mvc;

namespace Student.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Invalid payload.");
            }

            // Process the payload (e.g., save to database, log, etc.)
            return Ok(new { Message = "Studend registered successfully!", Student = student });
        }
    }

    public class Student
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Level { get; set; }
        public string StartDate { get; set; }
    }
}
