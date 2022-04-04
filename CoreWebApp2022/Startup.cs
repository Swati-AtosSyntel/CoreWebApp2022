using CoreWebApp2022.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp2022
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
            services.AddRazorPages();
            services.AddDbContextPool<EmployeeDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddMvc(options=>options.EnableEndpointRouting=false);
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            //DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("~/pages1/abc.html");
            //app.UseDefaultFiles(options);//change the request path to default file

            //app.UseStaticFiles();//process the static content stored under default webroot folder
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "pages1"))
            //});
            
            //FileServerOptions options = new FileServerOptions();
            //options.DefaultFilesOptions.DefaultFileNames.Clear();
            //options.DefaultFilesOptions.DefaultFileNames.Add("~/pages1/abc.html");
            //app.UseFileServer(options);
            //app.Run(async context =>
            //{
            //    //throw new Exception("Error Ocurred");
            //    await context.Response.WriteAsync(Directory.GetCurrentDirectory());
            //});
            app.UseRouting();

            app.UseAuthorization();
           // app.UseMvcWithDefaultRoute();
            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
            
        }
    }
}
