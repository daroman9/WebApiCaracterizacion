﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("disabled");

                    b.Property<int>("id_categoria");

                    b.Property<int>("id_plantilla");

                    b.Property<string>("nombre")
                        .HasMaxLength(80);

                    b.Property<int>("orden");

                    b.Property<int>("tipo");

                    b.Property<int>("valor_defecto");

                    b.Property<int>("valor_maximo");

                    b.Property<int>("valor_minimo");

                    b.Property<int>("visible");

                    b.HasKey("id");

                    b.HasIndex("id_categoria");

                    b.HasIndex("id_plantilla");

                    b.ToTable("Campos");
                });

            modelBuilder.Entity("caracterizacion.Models.Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("color")
                        .HasMaxLength(7);

                    b.Property<int>("id_padre");

                    b.Property<string>("image");

                    b.Property<string>("nombre")
                        .HasMaxLength(80);

                    b.Property<int>("orden");

                    b.Property<int>("visible");

                    b.HasKey("id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("caracterizacion.Models.Formulario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fecha_fin");

                    b.Property<DateTime>("fecha_inicio");

                    b.Property<int>("id_plantilla");

                    b.Property<string>("id_usuario");

                    b.Property<string>("usuarioid");

                    b.HasKey("id");

                    b.HasIndex("id_plantilla");

                    b.HasIndex("usuarioid");

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

            modelBuilder.Entity("WebApiCaracterizacion.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Apellido")
                        .HasMaxLength(80);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nombre")
                        .HasMaxLength(80);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

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

            modelBuilder.Entity("WebApiCaracterizacion.Models.Plantilla", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre");

                    b.HasKey("id");

                    b.ToTable("Plantillas");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Registro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fecha");

                    b.Property<int>("id_campo");

                    b.Property<DateTime>("valor_date");

                    b.Property<float>("valor_float");

                    b.Property<int>("valor_integer");

                    b.Property<string>("valor_string");

                    b.HasKey("id");

                    b.HasIndex("id_campo");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Registro_Tabla", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_formulario");

                    b.Property<string>("value");

                    b.HasKey("id");

                    b.HasIndex("id_formulario");

                    b.ToTable("Registros_Tablas");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Selector", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_campo");

                    b.Property<int>("id_padre");

                    b.Property<string>("nombre")
                        .HasMaxLength(80);

                    b.Property<int>("orden");

                    b.Property<int>("value");

                    b.Property<bool>("visible");

                    b.HasKey("id");

                    b.HasIndex("id_campo");

                    b.ToTable("Selectores");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Tablas_Campo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_campo");

                    b.Property<string>("nombre")
                        .HasMaxLength(80);

                    b.Property<string>("tipo")
                        .HasMaxLength(80);

                    b.HasKey("id");

                    b.HasIndex("id_campo");

                    b.ToTable("Tablas_Campos");
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Usuario", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("apellido")
                        .HasMaxLength(80);

                    b.Property<string>("email");

                    b.Property<string>("nombre")
                        .HasMaxLength(80);

                    b.Property<string>("password");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
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
                });

            modelBuilder.Entity("caracterizacion.Models.Formulario", b =>
                {
                    b.HasOne("WebApiCaracterizacion.Models.Plantilla", "Plantilla")
                        .WithMany()
                        .HasForeignKey("id_plantilla")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCaracterizacion.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioid");
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

            modelBuilder.Entity("WebApiCaracterizacion.Models.Registro", b =>
                {
                    b.HasOne("caracterizacion.Models.Campo", "Campo")
                        .WithMany()
                        .HasForeignKey("id_campo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Registro_Tabla", b =>
                {
                    b.HasOne("caracterizacion.Models.Formulario", "Formulario")
                        .WithMany()
                        .HasForeignKey("id_formulario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Selector", b =>
                {
                    b.HasOne("caracterizacion.Models.Campo", "Campo")
                        .WithMany()
                        .HasForeignKey("id_campo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCaracterizacion.Models.Tablas_Campo", b =>
                {
                    b.HasOne("caracterizacion.Models.Campo", "Campo")
                        .WithMany()
                        .HasForeignKey("id_campo")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
