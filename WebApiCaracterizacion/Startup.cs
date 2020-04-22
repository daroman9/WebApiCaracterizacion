using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiCaracterizacion.Models;
using WebApiCaracterizacion.Data;

namespace WebApiCaracterizacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           //Servicios para acceder a los controladores que ejecutan los procedimientos almacenados
            services.AddScoped<PromedioGenerosRepository>();
            services.AddScoped<PromedioAntiguedadRepository>();
            services.AddScoped<PromedioEdadesRepository>();
            services.AddScoped<PromedioEstadosRespository>();
            services.AddScoped<PromedioEscolaridadRepository>();
            services.AddScoped<PromedioBeneficiariosRepository>();
            services.AddScoped<PromedioViviendasRepository>();
            services.AddScoped<PromedioEpsRepository>();
            services.AddScoped<PromedioArlRepository>();
            services.AddScoped<PromedioFpsRepository>();
            services.AddScoped<PromedioSisbenRepository>();
            services.AddScoped<PromedioActividadRepository>();


            //Fin seccion controladores
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(
                option =>
                {
                    option.Password.RequireDigit = false;
                    option.Password.RequireNonAlphanumeric = false;
                    option.Password.RequireUppercase = false;
                    option.Password.RequireLowercase = false;
                }
                )
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = false,
                    ValidIssuer = "yourdomain.com",
                    ValidAudience = "yourdomain.com",
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"])),
                    ClockSkew = TimeSpan.Zero
                });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",

               builder => builder.AllowAnyOrigin());

            });

            services.AddMvc().AddJsonOptions(ConfigureJson);

        }
        private void ConfigureJson(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}