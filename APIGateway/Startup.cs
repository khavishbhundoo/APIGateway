using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using APIGateway.Contracts;
using APIGateway.Contracts.V1;
using APIGateway.Domain;
using APIGateway.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace APIGateway
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

            services.AddSingleton<IApiClient, ApiClient>();

            services.AddScoped<IBankRequest, BankRequest>();

            services.AddScoped<IPaymentResponse, PaymentResponse>();

            services.AddScoped<IPaymentResponse, PaymentResponse>();

            services.AddHttpContextAccessor();

            //services.AddScoped<IBankResponse, BankResponse>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "PaymentGateway",
                    Description = "PaymentGateway for Checkout.com",
                    Contact = new Contact() { Name = "Khavish Anshudass Bhundoo", Email = "k.bhundoo@gmail.com", Url = "https://github.com/khavishbhundoo" }
                });

                c.ExampleFilters();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, xmlFile);
                
                c.IncludeXmlComments(xmlPath);

            });
            services.AddSwaggerExamples();
            services.AddSwaggerExamplesFromAssemblyOf<Startup>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            APIGateway.Swagger.SwaggerOptions swaggerOptions = new APIGateway.Swagger.SwaggerOptions();
            Configuration.GetSection(nameof(swaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(option => 
            {
                option.RouteTemplate = swaggerOptions.JsonRoute;
            });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.UIEndpoint);
            });


            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
