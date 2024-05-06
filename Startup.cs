using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _configuration; 
        // Notice we are using Dependency Injection here
         public Startup(IConfiguration configuration) 
        
            { _configuration = configuration; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddDbContextPool<AppDbContext>(
            options => options.UseSqlServer(_configuration.GetConnectionString("EmployeeDBConnection")));


            services.AddScoped<IEmployeeRepository,SQLEmployeeRepository>();    
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env , ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseStatusCodePages();
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
               // app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }


            // Day-6
            app.UseStaticFiles();


            //app.UseMvcWithDefaultRoute();
            // day -10
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseMvc();

            // Day-4 sample code 
            //app.Use(async (context,next) =>
            //{
            //    //await context.Response.WriteAsync("Hello World!!");
            //    logger.LogInformation("Log information 1");
            //    await next();
            //});

            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync("Hello World 2!!");
            //    logger.LogInformation("Log information 2");
            //    await next();
            //});


            //Day-5 Class codes

            // Set default page
            //app.UseDefaultFiles(new DefaultFilesOptions
            //{
            //    DefaultFileNames = new List<string> { "index.html" }
            //});
            //app.UseStaticFiles();


            //app.Run(async (context) =>
            //{
            //    //await context.Response.WriteAsync("Hello World !!");
            //    await context.Response.WriteAsync("My Environment is" + env.EnvironmentName);
            //});

        }
    }
}
