using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApiApplication.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookApiProject
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection = @"Server=.\;Database=BookApiProject;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<BookDBContext>(options => options.UseSqlServer(connection));

            //var connectionString = Configuration["connectionStrings:bookDbConnectionString"];
            //services.AddDbContext<BookDBContext>(c => c.UseSqlServer(Configuration.GetConnectionString("bookDbConnectionString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BookDBContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // context.SeedDataContext();
            app.UseMvc();
        }
    }
}
