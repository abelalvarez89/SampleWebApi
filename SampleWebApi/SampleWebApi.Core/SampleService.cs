using System;
using System.Linq;
using SampleWebApi.Core.Model;

namespace SampleWebApi.Core
{
    public class SampleService : ISampleService
    {
        public Blog GetBlog()
        {
            Blog blogResponse = null;
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }
                blogResponse = db.Blogs.First();
            }
            return blogResponse;
        }
    }
}
