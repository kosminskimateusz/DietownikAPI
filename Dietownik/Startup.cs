using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dietownik.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MediatR;
using Dietownik.ApplicationServices.API.Domain;
using Dietownik.ApplicationServices.Mappings;
using Dietownik.DataAccess.CQRS;
using FluentValidation.AspNetCore;
using Dietownik.ApplicationServices.API.Validators;
using Microsoft.AspNetCore.Authentication;
using Dietownik.Authentication;
using Dietownik.ApplicationServices.Components;

namespace Dietownik
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
            // Dodane własne:

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: "AllowBlazor",
            //       builder =>
            //       {
            //           builder.WithOrigins("https://localhost:44352/",
            //               "http://localhost:35207");
            //       });
            //});
            services.AddCors(options => {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
                });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddAuthentication("BasicAuthentication")
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddMvcCore()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddProductRequestValidator>());

            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();

            services.AddAutoMapper(typeof(ProductProfile).Assembly);

            // services.AddMediatR(typeof(ResponseBase<>)); // Klasy w których chcemy skorzystać z Mediatora, tu podajemy lokalizację np. przez ResponseBase
            services.AddMediatR(typeof(ApplicationServices.API.Domain.ResponseBase<>)); // Chyba to samo co wyżej. Sprawdzić!!!


            services.AddDbContext<RecipeStorageContext>(
                opt => opt.UseSqlServer(this.Configuration.GetConnectionString("RecipeDatabaseConnection"))
            );

            // Koniec dodanych własnych

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dietownik", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dietownik v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
