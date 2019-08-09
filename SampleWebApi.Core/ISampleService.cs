using SampleWebApi.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleWebApi.Core
{
    public interface ISampleService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<List<Course>> GetCourses();
        Task<List<Enrollment>> GetEnrollmentsAsync();
        Task<IDictionary<string, int>> GetInventory();
    }
}