using Microsoft.OpenApi.Models;
using System.Dynamic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Program.Helpers;
using Microsoft.AspNetCore.Http;

namespace Program
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddControllers().AddNewtonsoftJson();
            services.RegisterAppServices();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        //builder.WithOrigins("https://example.com")
                        builder.AllowAnyHeader()
                        .AllowAnyMethod()
                    .WithExposedHeaders("Error-Message");
                    });
            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Program APIs", Version = "v1" });
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "Please Insert token",
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.Http,
                //    BearerFormat = "JWT",
                //    Scheme = "bearer"
                //});
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference=new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            //Id="Bearer"
                        }
                    },
                    Array.Empty<string>()
                    }
                });

            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            //app.UseMiddleware<DomainWhitelistMiddleware>(); // Use custom middleware for domain whitelisting
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            //app.UseCors("AllowSpecificOrigins"); // Apply the CORS policy

            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseCors(builder =>
            //{
            //    builder.WithOrigins("https://example.com")
            //        .AllowAnyHeader()
            //        .AllowAnyMethod();

            //});
            //app.UseCors("AllowSpecificOrigins"); // Apply the CORS policy
            //app.UseAuthentication();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                dynamic response = new ExpandoObject();
                response.Success = true;
                string responseString = JsonConvert.SerializeObject(response);
                endpoints.MapGet("{*path}", async context =>
                {
                    // Handle GET requests with no parameters
                    await context.Response.WriteAsync(responseString);
                });
                endpoints.MapPost("{*path}", async context =>
                {
                    // Handle POST requests without a body as GET requests
                    if (context.Request.Body.Length == 0)
                    {
                        await context.Response.WriteAsync(responseString);
                    }
                });
                endpoints.MapControllers();
            });
        }


    }
}
