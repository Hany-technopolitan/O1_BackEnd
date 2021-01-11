using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Techno_Project.Contexts;
using Microsoft.EntityFrameworkCore;
using Techno_Project.Repos;
using Techno_Project.Models;

namespace Techno_Project
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
            services.AddCors();
         
            services.AddDbContext<GenericDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));            
            services.AddScoped<IFormDbRepository, FormRepository>();
            services.AddScoped<ImailFormRepository, MailFormRepository>();
            services.AddScoped<IMovableRepository, MovableRepository>();
            services.AddScoped<IRequeststatus, RequestStatusRepository>();
            services.AddScoped<IAuthentication, AuthenticationRepository>();
            var emailConfig = Configuration
       .GetSection("EmailConfiguration")
       .Get<EmailModel>();

            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCors(x => x
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .SetIsOriginAllowed(origin => true) // allow any origin
            //    .AllowCredentials()); // allow credentials



            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(
            //    builder => builder.WithOrigins("http://techno-politan.xyz")
            //    .AllowAnyHeader()
            //    .AllowAnyMethod()
            //);


            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthentication();
            

             app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
