﻿using System;
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
using WebApiCaracterizacion.DataGanaderia;
using WebApiCaracterizacion.DataConsultasGenerales;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.S3;
using AwsFiles.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebApiCaracterizacion.Services;
using WebApiCaracterizacion.Interfaces;

namespace WebApiCaracterizacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       // readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            //Servicios para acceder a los controladores que ejecutan los procedimientos almacenados
 
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
            services.AddScoped<PromedioMinimoOroORRepository>();
            services.AddScoped<PromedioNivelSeguridadORRepository>();
            services.AddScoped<PromedioIngresoPersonaORRepository>();
            services.AddScoped<PromedioLegalidadORRepository>();
            services.AddScoped<PromedioTipoMineriaORRepository>();
            services.AddScoped<PromedioVolumenExtraccionORRespository>();
            services.AddScoped<PromedioCausasVariacionRepositoryTF>();
            services.AddScoped<PromedioViablilidadExplotacionORRespository>();
            services.AddScoped<PromedioLugarExplotacionORRepository>();
            services.AddScoped<PromedioDistribucionIngresoORRepository>();
            services.AddScoped<PromedioCausaVariacionORRepository>();
            services.AddScoped<PromedioVolumenProduccionORRepository>();
            services.AddScoped<PromedioProduccionORRepository>();
            services.AddScoped<PromedioActividadPrimariaPredioGNRepository>();
            services.AddScoped<PromedioActividadSecundariaPredioGNRepository>();
            services.AddScoped<PromedioAsociacionGNRepository>();
            services.AddScoped<PromedioBeneficiosGNRepository>();
            services.AddScoped<PromedioActividadPrincipalOcupanteGNRepository>();
            services.AddScoped<PromedioDiscapacitadosGNRepository>();
            services.AddScoped<PromedioEtniaGNRepository>();
            services.AddScoped<PromedioGenerosGNRepository>();
            services.AddScoped<PromedioGradoEscolaridadGNRepository>();
            services.AddScoped<PromedioMujeresGNRepository>();
            services.AddScoped<PromedioNivelAgremiacionGNRepository>();
            services.AddScoped<PromedioNombreAsociacionGNRepository>();
            services.AddScoped<PromedioNombreEtniaGNRepository>();
            services.AddScoped<PromedioOcupanteDepdendeActividadGNRepository>();
            services.AddScoped<PromedioOrginarioRegionGNRepository>();
            services.AddScoped<PromedioOtraActividadOcupanteGNRepository>();
            services.AddScoped<PromedioDependenciaActividadGNRepository>();
            services.AddScoped<PromedioPromedioAreaGNRepository>();
            services.AddScoped<PromedioTenenciaGNRepository>();
            services.AddScoped<PromedioTipoBeneficioGNRepository>();
            services.AddScoped<PromedioTipoHatoGNRepository>();
            services.AddScoped<PromedioTipoPredioGNRepository>();
            services.AddScoped<PromedioRangoEdadGNRepository>();
            services.AddScoped<PromedioVariacionProductividadGNRepository>();
            services.AddScoped<PromedioCausaVariacionProductividadGNRepository>();
            services.AddScoped<PromedioPercepcionVariacionProductividadGNRepository>();
            services.AddScoped<PromedioMesesActividadGNRepository>();
            services.AddScoped<PromedioActividadPrincipalTransportadorTFRepository>();
            services.AddScoped<PromedioEstadoCivilGNRepository>();
            services.AddScoped<PromedioNivelSocioeconomicoGNRepository>();
            services.AddScoped<PromedioVolumenDiarioAgregadosORRepository>();
            services.AddScoped<PromedioNivelPoblacionVulnerableGNRepository>();
            services.AddScoped<PromedioAreaSiembraGNRepository>();
            services.AddScoped<PromedioAreaPotrerosGNRepository>();
            services.AddScoped<PromedioProduccionArrozGNRepository>();
            services.AddScoped<PromedioProduccionPlatanoGNRepository>();
            services.AddScoped<PromedioNivelDependeActividadGNRepository>();
            services.AddScoped<PromedioOtraActividadPredioGNRepository>();
            services.AddScoped<PromedioMesesCosechaGNRepository>();
            services.AddScoped<PromedioMesesLecheGNRepository>();
            services.AddScoped<PromedioMesesCarneGNRepository>();
            services.AddScoped<PromedioPorcentajeAreaGNRepository>();
            services.AddScoped<PromedioDensidadCultivoGNRepository>();
            services.AddScoped<PromedioNivelIngresoGNRepository>();
            services.AddScoped<PromedioPorcentajeCultivoGNRepository>();
            services.AddScoped<PromedioPorcentajeDiscapacitadosGNRepository>();
            services.AddScoped<PromedioArraigoActividadGNRepository>();
            services.AddScoped<PromedioDensidadSiembraGNRepository>();
            services.AddScoped<PromedioOtraActividadMineroORRepository>();
            services.AddScoped<PromedioProduccionMinidragasORRepository>();
            services.AddScoped<PromedioEstadoCivilORRepository>();
            services.AddScoped<PromedioRandoEdadORRepository>();
            services.AddScoped<PromedioTenenciaORRepository>();
            services.AddScoped<PromedioCantidadDiscapacitadosGNRepository>();
            services.AddScoped<PromedioCantidadMujeresGNRepository>();
            services.AddScoped<PromedioCosechaEstimadaGNRepository>();
            services.AddScoped<PromedioIngresoMensualGNRepository>();
            services.AddScoped<PromedioNivelProduccionGNRepository>();
            services.AddScoped<PromedioVulnerabilidadSocioeconomicaGNReposritory>();
            services.AddScoped<PromedioIngresoMineroORRepository>();
            services.AddScoped<PromedioArraigoActividadTFRepository>();
            services.AddScoped<PromedioDistribucionAfpGNRepository>();
            services.AddScoped<PromedioMesesActividadTFRepository>();
            services.AddScoped<PromedioTipoBeneficioORRepository>();
            services.AddScoped<PromedioDependenciaActividadTFRepository>();


            

            services.AddScoped<FiltrarFichasRepository>();
            services.AddScoped<FiltrarRegistrosExcelRepository>();
            services.AddScoped<FiltrarTablasExcelRepository>();
            services.AddScoped<UsersAndFormsRepostitory>();


            //Fin seccion controladores


            //Servicio para procesamiento de archivos en S3 de amazon
            services.AddDefaultAWSOptions(
            new AWSOptions
            {
                Region = RegionEndpoint.GetBySystemName("us-east-1")
            });
            services.AddSingleton<IS3Service, S3Service>();
            services.AddAWSService<IAmazonS3>();
            //Servicio para el envio de correos
            services.AddTransient<IMailService, MailService>();
         
            services.Configure<EmailSenderOptions>(Configuration.GetSection("EmailSenderOptions"));
            //Servicio para el logueo con captcha
            services.AddTransient<GooglereCaptchaService>();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
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

            //Enable Cors
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();

                });

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

            app.UseCors("EnableCORS");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}