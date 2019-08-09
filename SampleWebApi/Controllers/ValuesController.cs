using Microsoft.AspNetCore.Mvc;
using SampleWebApi.Core;
using SampleWebApi.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ISampleService _sampleService;

        public ValuesController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [HttpGet, Route("students")]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            return await _sampleService.GetStudentsAsync();
        }

        [HttpGet, Route("courses")]
        public async Task<ActionResult<List<Course>>> GetCourses()
        {
            return await _sampleService.GetCourses();
        }

        [HttpGet, Route("enrollments")]
        public async Task<ActionResult<List<Enrollment>>> GetEnrollments()
        {
            return await _sampleService.GetEnrollmentsAsync();
        }

        [HttpGet, Route("store/inventory")]
        public async Task<ActionResult<IDictionary<string, int>>> GetInventory()
        {
            return Ok(await _sampleService.GetInventory());
        }
    }
}
