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
using WebApiCaracterizacion.DataMineria;
using WebApiCaracterizacion.DataTransporte;

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
            services.AddScoped<PromedioEpocasRepository>();
            services.AddScoped<PromedioArraigoRepository>();
            services.AddScoped<PromedioProductividadRepository>();
            services.AddScoped<PromedioUnidadRepository>();
            services.AddScoped<PromedioMesesMayorRepository>();
            services.AddScoped<PromedioMesesMenorRepository>();
            services.AddScoped<PromedioActLpRepository>();
            services.AddScoped<PromedioNivelFormalizacionTFRepository>();
            services.AddScoped<PromedioCapacidadCargaTFRepository>();
            services.AddScoped<PromedioUnidadTFRepository>();
            services.AddScoped<PromedioNivelSeguridadTFRepository>();
            services.AddScoped<PromedioGeneroTFRepository>();
            services.AddScoped<PromedioOriginarioTFRepository>();
            services.AddScoped<PromediosEdadTFRepository>();
            services.AddScoped<PromedioEscolaridadTFRepository>();
            services.AddScoped<PromedioViviendaTFRepository>();
            services.AddScoped<PromedioEstadoTFRepository>();
            services.AddScoped<PromedioOtrasActividadesTFRepository>();
            services.AddScoped<PromedioVariacionTFRepository>();
            services.AddScoped<PromedioUtilidadTFRepository>();
            services.AddScoped<PromedioMasProductividadTFRepository>();
            services.AddScoped<PromedioVulnerabilidadORRepository>();
            services.AddScoped<PromedioDistribucionGeneroORRepository>();
            services.AddScoped<PromedioDependenciaActividadORRepository>();
            services.AddScoped<PromediosEscolaridadORRepository>();
            services.AddScoped<PromedioNivelIngresosORRepository>();
            services.AddScoped<PromedioBeneficiosORRepository>();
            services.AddScoped<PromedioTipoMineroORRepository>();
            services.AddScoped<PromedioVariacionORRepository>();
            services.AddScoped<PromedioArraigoORRepository>();
            services.AddScoped<PromedioMesesORRepository>();
            services.AddScoped<PromedioTecnificacionORRepository>();
            services.AddScoped<PromedioGenerosUsuariosTFRepository>();
            services.AddScoped<PromedioEdadUsuariosTFRepository>();
            services.AddScoped<PromedioEscoloridadUsuariosTFRepository>();
            services.AddScoped<PromedioActividadUsuariosTFRepository>();
            services.AddScoped<PromedioMenosProductividadTFRepository>();
            services.AddScoped<PromedioVulnerabilidadTFRepository>();

            

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

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:8080");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();

            }); 
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}