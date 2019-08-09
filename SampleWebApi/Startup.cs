using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleWebApi.Core;
using SampleWebApi.Core.Data;
using Swashbuckle.AspNetCore.Swagger;
using System;
using Test.Client;

namespace SampleWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<ISampleService, SampleService>();

            services.AddHttpClient<ITestClient, TestClient>(new Uri("https://petstore.swagger.io/v2/"));

            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ContosoUniversity1;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "SampleWebApi V1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SampleWebApi V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    public static class HelperMethods
    {
        public static IServiceCollection AddHttpClient<TClient, TImplemation>(this IServiceCollection services, Uri baseUri) where TClient : class where TImplemation : class, TClient
        {
            services.AddHttpClient<TClient, TImplemation>(opts => opts.BaseAddress = baseUri);
            return services;
        }
    }
}
