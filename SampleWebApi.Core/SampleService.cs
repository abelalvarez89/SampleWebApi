using Microsoft.EntityFrameworkCore;
using SampleWebApi.Core.Data;
using SampleWebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Client;

namespace SampleWebApi.Core
{
    public class SampleService : ISampleService
    {
        private readonly SchoolContext _schoolContext;
        private readonly ITestClient _testClient;

        public SampleService(SchoolContext schoolContext, ITestClient testClient)
        {
            _schoolContext = schoolContext;
            _testClient = testClient;
        }

        public async Task<IDictionary<string, int>> GetInventory()
        {
            var inventory = await _testClient.GetInventoryAsync();
            return inventory;
        }

        public async Task<List<Course>> GetCourses()
        {
            var courses = await _schoolContext.Courses.ToListAsync();
            return courses;
        }

        public async Task<List<Enrollment>> GetEnrollmentsAsync()
        {
            var enrollments = await _schoolContext.Enrollments.ToListAsync();

            return enrollments;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            var students = await _schoolContext.Students.ToListAsync();

            return students;
        }
    }
}
