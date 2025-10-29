using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using StudentRegister.Configuration;
using StudentRegister.Models;

namespace StudentRegister.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public StudentController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiSettings = apiSettings.Value;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEmployee([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var jsonPayload = JsonSerializer.Serialize(student);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiSettings.SubscriptionKey);

            var response = await _httpClient.PostAsync(_apiSettings.ApimEndpoint, content);

            if (response.IsSuccessStatusCode)
                return Ok(new { message = "Student data submitted successfully." });

            var errorDetails = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, $"Failed to send data to APIM: {errorDetails}");
        }
    }
}
