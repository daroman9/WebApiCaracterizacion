﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200623230225_LogInitial")]
    partial class LogInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("caracterizacion.Models.Campo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion")
                        .HasMaxLength(250);

                    b.Property<string>("disableCategories");

                    b.Property<string>("disableFields");

                    b.Property<bool?>("disabled");

                    b.Property<string>("enableCategories");

                    b.Property<string>("enableFields");

                    b.Property<int>("id_categoria");

                    b.Property<int>("id_plantilla");

                    b.Property<int?>("id_selector");

                    b.Property<int?>("id_validacion");

                    b.Property<string>("nombre")
                        .HasMaxLength(250);

                    b.Property<int?>("orden");

                    b.Property<string>("rangos");

                    b.Property<bool?>("required");

                    b.Property<string>("tipo");

                    b.Property<string>("unidad");

                    b.Property<int?>("valor_defecto");

                    b.Property<int?>("valor_maximo");

                    b.Property<int?>("valor_minimo");

                    b.Property<bool?>("visible");

                    b.HasKey("id");

                    b.HasIndex("id_categoria");

                    b.HasIndex("id_plantilla");

                    b.HasIndex("id_selector");

                    b.HasIndex("id_validacion");

                    b.ToTable("Campos");
                });

            modelBuilder.Entity("caracterizacion.Models.Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("color")
                        .HasMaxLength(20);

                    b.Property<int?>("id_padre");

                    b.Property<int>("id_plantilla");

                    b.Property<string>("image");

                    b.Property<string>("nombre")
                        .HasMaxLength(250);

                    b.Property<int?>("orden");

                    b.Property<bool?>("visible");

                    b.HasKey("id");

                    b.HasIndex("id_plantilla");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("caracterizacion.Models.Formulario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion");

                    b.Property<string>("emailLider");

                    b.Property<DateTime?>("fecha_fin");

                    b.Property<DateTime?>("fecha_inicio");

                    b.Property<int>("id_plantilla");

                    b.Property<string>("id_usuario");

                    b.Property<string>("lider");

                    b.Property<string>("nombreCampaña");

                    b.Property<string>("objetivo");

                    b.Property<string>("telefonoLider");

                    b.HasKey("id");

                    b.HasIndex("id_plantilla");

                    b.HasIndex("id_usuario");

                    b.ToTable("Formularios");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Anla", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("car");

                    b.Property<string>("codigo");

                    b.Property<string>("contrato");

                    b.Property<double>("coor_este");

                    b.Property<double>("coor_norte");

                    b.Property<string>("expediente");

                    b.Property<string>("observacion");

                    b.Property<string>("operador");

                    b.Property<string>("proyecto");

                    b.HasKey("id");

                    b.ToTable("Anla");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Apellido")
                        .HasMaxLength(250);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("Documento");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Foto");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nombre")
                        .HasMaxLength(250);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("Password");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("Rol");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Telefono");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Car", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("car");

                    b.Property<string>("departamento");

                    b.Property<string>("municipio");

                    b.HasKey("id");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Entidad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("contacto");

                    b.Property<string>("direccion");

                    b.Property<string>("emailContacto");

                    b.Property<string>("grupoInvestigacion");

                    b.Property<int>("identificacion");

                    b.Property<string>("nombre");

                    b.Property<string>("telContacto");

                    b.HasKey("id");

                    b.ToTable("Entidad");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.EntidadesXCampana", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("contrato");

                    b.Property<int>("id_entidad");

                    b.Property<int>("id_formulario");

                    b.HasKey("id");

                    b.HasIndex("id_entidad");

                    b.HasIndex("id_formulario");

                    b.ToTable("EntidadesXCampana");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Ficha", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("date");

                    b.Property<int>("estado");

                    b.Property<int>("id_formulario");

                    b.Property<int>("id_plantilla");

                    b.Property<string>("id_usuario");

                    b.Property<string>("latitud");

                    b.Property<string>("longitud");

                    b.HasKey("id");

                    b.HasIndex("id_formulario");

                    b.HasIndex("id_plantilla");

                    b.HasIndex("id_usuario");

                    b.ToTable("Ficha");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Log", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("camposCambiado");

                    b.Property<DateTime?>("date");

                    b.Property<string>("estadoFinal");

                    b.Property<string>("estadoInicial");

                    b.Property<string>("id_ficha");

                    b.Property<string>("id_usuario");

                    b.Property<int>("noConformidades");

                    b.Property<string>("valorAnterior");

                    b.Property<string>("valorNuevo");

                    b.HasKey("id");

                    b.HasIndex("id_ficha");

                    b.HasIndex("id_usuario");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Plantilla", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("color");

                    b.Property<string>("nombre");

                    b.HasKey("id");

                    b.ToTable("Plantillas");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.ProfesionalesXCampana", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_entidad");

                    b.Property<string>("id_usuario");

                    b.HasKey("id");

                    b.HasIndex("id_entidad");

                    b.HasIndex("id_usuario");

                    b.ToTable("ProfesionalesXCampana");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Registro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("fecha");

                    b.Property<int>("id_campo");

                    b.Property<string>("id_ficha");

                    b.Property<DateTime?>("valor_date");

                    b.Property<float?>("valor_float");

                    b.Property<int?>("valor_integer");

                    b.Property<string>("valor_string");

                    b.HasKey("id");

                    b.HasIndex("id_campo");

                    b.HasIndex("id_ficha");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Registro_Tabla", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("fecha");

                    b.Property<int>("id_campo");

                    b.Property<string>("id_column");

                    b.Property<string>("id_ficha");

                    b.Property<string>("row");

                    b.Property<DateTime?>("valor_date");

                    b.Property<float?>("valor_float");

                    b.Property<int?>("valor_integer");

                    b.Property<string>("valor_string");

                    b.HasKey("id");

                    b.HasIndex("id_campo");

                    b.HasIndex("id_ficha");

                    b.ToTable("Registros_Tablas");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Selector", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre");

                    b.HasKey("id");

                    b.ToTable("Selectores");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Selector_Detail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("etiqueta");

                    b.Property<int>("id_selector");

                    b.Property<int?>("parent_selector");

                    b.Property<int?>("parent_value");

                    b.Property<string>("valor");

                    b.HasKey("id");

                    b.HasIndex("id_selector");

                    b.ToTable("Selector_Detail");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Tablas_Campo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("disableFields");

                    b.Property<bool?>("disabled");

                    b.Property<string>("enableFields");

                    b.Property<int>("id_campo");

                    b.Property<int?>("id_selector");

                    b.Property<int?>("id_validacion");

                    b.Property<string>("nombre")
                        .HasMaxLength(250);

                    b.Property<int?>("orden");

                    b.Property<string>("rangos")
                        .HasMaxLength(250);

                    b.Property<string>("tipo")
                        .HasMaxLength(100);

                    b.Property<string>("unidad");

                    b.Property<int?>("valor_defecto");

                    b.Property<int?>("valor_maximo");

                    b.Property<int?>("valor_minimo");

                    b.Property<bool?>("visible");

                    b.HasKey("id");

                    b.HasIndex("id_campo");

                    b.HasIndex("id_selector");

                    b.HasIndex("id_validacion");

                    b.ToTable("Tablas_Campos");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Validacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("mensaje");

                    b.Property<string>("nombre");

                    b.Property<string>("validacion");

                    b.HasKey("id");

                    b.ToTable("Validacion");
                });

            modelBuilder.Entity("caracterizacion.Models.Campo", b =>
                {
                    b.HasOne("caracterizacion.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("id_categoria")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCaracterizacion.Models.Plantilla", "Plantilla")
                        .WithMany()
                        .HasForeignKey("id_plantilla")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCaracterizacion.Models.Selector", "Selector")
                        .WithMany()
                        .HasForeignKey("id_selector");

                    b.HasOne("WebApiCaracterizacion.Models.Validacion", "Validacion")
                        .WithMany()
                        .HasForeignKey("id_validacion");
                });

            modelBuilder.Entity("caracterizacion.Models.Categoria", b =>
                {
                    b.HasOne("WebApiCaracterizacion.Models.Plantilla", "Plantilla")
                        .WithMany()
                        .HasForeignKey("id_plantilla")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("caracterizacion.Models.Formulario", b =>
                {
                    b.HasOne("WebApiCaracterizacion.Models.Plantilla", "Plantilla")
                        .WithMany()
                        .HasForeignKey("id_plantilla")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCaracterizacion.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("id_usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApiCaracterizacion.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApiCaracterizacion.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCaracterizacion.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApiCaracterizacion.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.EntidadesXCampana", b =>
                {
                    b.HasOne("WebApiCaracterizacion.Models.Entidad", "Entidad")
                        .WithMany()
                        .HasForeignKey("id_entidad")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("caracterizacion.Models.Formulario", "Formulario")
                        .WithMany()
                        .HasForeignKey("id_formulario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Ficha", b =>
                {
                    b.HasOne("caracterizacion.Models.Formulario", "Formulario")
                        .WithMany()
                        .HasForeignKey("id_formulario")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCaracterizacion.Models.Plantilla", "Plantilla")
                        .WithMany()
                        .HasForeignKey("id_plantilla")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCaracterizacion.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("id_usuario");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Log", b =>
                {
                    b.HasOne("WebApiCaracterizacion.Models.Ficha", "Ficha")
                        .WithMany()
                        .HasForeignKey("id_ficha");

                    b.HasOne("WebApiCaracterizacion.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("id_usuario");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.ProfesionalesXCampana", b =>
                {
                    b.HasOne("WebApiCaracterizacion.Models.EntidadesXCampana", "EntidadesXCampana")
                        .WithMany()
                        .HasForeignKey("id_entidad")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCaracterizacion.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("id_usuario");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Registro", b =>
                {
                    b.HasOne("caracterizacion.Models.Campo", "Campo")
                        .WithMany()
                        .HasForeignKey("id_campo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCaracterizacion.Models.Ficha", "Ficha")
                        .WithMany()
                        .HasForeignKey("id_ficha");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Registro_Tabla", b =>
                {
                    b.HasOne("caracterizacion.Models.Campo", "Campo")
                        .WithMany()
                        .HasForeignKey("id_campo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCaracterizacion.Models.Ficha", "Ficha")
                        .WithMany()
                        .HasForeignKey("id_ficha");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Selector_Detail", b =>
                {
                    b.HasOne("WebApiCaracterizacion.Models.Selector", "Selector")
                        .WithMany()
                        .HasForeignKey("id_selector")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Tablas_Campo", b =>
                {
                    b.HasOne("caracterizacion.Models.Campo", "Campo")
                        .WithMany()
                        .HasForeignKey("id_campo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCaracterizacion.Models.Selector", "Selector")
                        .WithMany()
                        .HasForeignKey("id_selector");

                    b.HasOne("WebApiCaracterizacion.Models.Validacion", "Validacion")
                        .WithMany()
                        .HasForeignKey("id_validacion");
                });
#pragma warning restore 612, 618
        }
    }
}
