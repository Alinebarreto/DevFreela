using DevFreela.API.Models;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using IdentityServer3.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using IUserService = DevFreela.Application.Services.Interfaces.IUserService;

namespace DevFreela.API
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
            services.Configure<OpeningTimeOption>(Configuration.GetSection("OpeningTime"));

            var connectionString = Configuration.GetConnectionString("DevFreelaCs");

            services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISkillService, SkillService>();

            services.AddScoped<ExampleClass>(e => new ExampleClass { Name = "Initial Stage" });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}