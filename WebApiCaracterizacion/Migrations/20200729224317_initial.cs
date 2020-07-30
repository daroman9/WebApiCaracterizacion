using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCaracterizacion.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anla",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    coor_este = table.Column<double>(nullable: false),
                    coor_norte = table.Column<double>(nullable: false),
                    expediente = table.Column<string>(nullable: true),
                    operador = table.Column<string>(nullable: true),
                    proyecto = table.Column<string>(nullable: true),
                    contrato = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true),
                    car = table.Column<string>(nullable: true),
                    observacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anla", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 250, nullable: true),
                    Apellido = table.Column<string>(maxLength: 250, nullable: true),
                    Documento = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    Rol = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    departamento = table.Column<string>(nullable: true),
                    municipio = table.Column<string>(nullable: true),
                    car = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Entidad",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    identificacion = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    contacto = table.Column<string>(nullable: true),
                    telContacto = table.Column<string>(nullable: true),
                    emailContacto = table.Column<string>(nullable: true),
                    grupoInvestigacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Plantillas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantillas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Selectores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selectores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Validacion",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    validacion = table.Column<string>(nullable: true),
                    mensaje = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_padre = table.Column<int>(nullable: true),
                    nombre = table.Column<string>(maxLength: 250, nullable: true),
                    orden = table.Column<int>(nullable: true),
                    visible = table.Column<bool>(nullable: true),
                    color = table.Column<string>(maxLength: 20, nullable: true),
                    image = table.Column<string>(nullable: true),
                    id_plantilla = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.id);
                    table.ForeignKey(
                        name: "FK_Categorias_Plantillas_id_plantilla",
                        column: x => x.id_plantilla,
                        principalTable: "Plantillas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formularios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fecha_inicio = table.Column<DateTime>(nullable: true),
                    fecha_fin = table.Column<DateTime>(nullable: true),
                    id_plantilla = table.Column<int>(nullable: false),
                    id_usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formularios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Formularios_Plantillas_id_plantilla",
                        column: x => x.id_plantilla,
                        principalTable: "Plantillas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Formularios_AspNetUsers_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Selector_Detail",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    valor = table.Column<string>(nullable: true),
                    etiqueta = table.Column<string>(nullable: true),
                    parent_value = table.Column<int>(nullable: true),
                    parent_selector = table.Column<int>(nullable: true),
                    id_selector = table.Column<int>(nullable: false),
                    orden = table.Column<double>(nullable: true),
                    color = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selector_Detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_Selector_Detail_Selectores_id_selector",
                        column: x => x.id_selector,
                        principalTable: "Selectores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 250, nullable: true),
                    descripcion = table.Column<string>(maxLength: 250, nullable: true),
                    valor_maximo = table.Column<int>(nullable: true),
                    valor_minimo = table.Column<int>(nullable: true),
                    valor_defecto = table.Column<int>(nullable: true),
                    rangos = table.Column<string>(nullable: true),
                    orden = table.Column<int>(nullable: true),
                    visible = table.Column<bool>(nullable: true),
                    tipo = table.Column<string>(nullable: true),
                    required = table.Column<bool>(nullable: true),
                    unidad = table.Column<string>(nullable: true),
                    disabled = table.Column<bool>(nullable: true),
                    enableCategories = table.Column<string>(nullable: true),
                    enableFields = table.Column<string>(nullable: true),
                    disableCategories = table.Column<string>(nullable: true),
                    disableFields = table.Column<string>(nullable: true),
                    id_categoria = table.Column<int>(nullable: false),
                    id_plantilla = table.Column<int>(nullable: false),
                    id_selector = table.Column<int>(nullable: true),
                    id_validacion = table.Column<int>(nullable: true),
                    tipo_teclado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Campos_Categorias_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "Categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campos_Plantillas_id_plantilla",
                        column: x => x.id_plantilla,
                        principalTable: "Plantillas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campos_Selectores_id_selector",
                        column: x => x.id_selector,
                        principalTable: "Selectores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campos_Validacion_id_validacion",
                        column: x => x.id_validacion,
                        principalTable: "Validacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntidadesXCampana",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contrato = table.Column<string>(nullable: true),
                    id_entidad = table.Column<int>(nullable: false),
                    id_formulario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadesXCampana", x => x.id);
                    table.ForeignKey(
                        name: "FK_EntidadesXCampana_Entidad_id_entidad",
                        column: x => x.id_entidad,
                        principalTable: "Entidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntidadesXCampana_Formularios_id_formulario",
                        column: x => x.id_formulario,
                        principalTable: "Formularios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ficha",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    latitud = table.Column<string>(nullable: true),
                    longitud = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: true),
                    id_usuario = table.Column<string>(nullable: true),
                    id_formulario = table.Column<int>(nullable: false),
                    id_plantilla = table.Column<int>(nullable: false),
                    estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficha", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ficha_Formularios_id_formulario",
                        column: x => x.id_formulario,
                        principalTable: "Formularios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ficha_Plantillas_id_plantilla",
                        column: x => x.id_plantilla,
                        principalTable: "Plantillas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ficha_AspNetUsers_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tablas_Campos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 250, nullable: true),
                    tipo = table.Column<string>(maxLength: 100, nullable: true),
                    valor_maximo = table.Column<int>(nullable: true),
                    valor_minimo = table.Column<int>(nullable: true),
                    valor_defecto = table.Column<int>(nullable: true),
                    rangos = table.Column<string>(maxLength: 250, nullable: true),
                    orden = table.Column<int>(nullable: true),
                    visible = table.Column<bool>(nullable: true),
                    unidad = table.Column<string>(nullable: true),
                    enableFields = table.Column<string>(nullable: true),
                    disableFields = table.Column<string>(nullable: true),
                    disabled = table.Column<bool>(nullable: true),
                    id_campo = table.Column<int>(nullable: false),
                    id_selector = table.Column<int>(nullable: true),
                    id_validacion = table.Column<int>(nullable: true),
                    tipo_teclado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tablas_Campos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tablas_Campos_Campos_id_campo",
                        column: x => x.id_campo,
                        principalTable: "Campos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tablas_Campos_Selectores_id_selector",
                        column: x => x.id_selector,
                        principalTable: "Selectores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tablas_Campos_Validacion_id_validacion",
                        column: x => x.id_validacion,
                        principalTable: "Validacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfesionalesXCampana",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_entidad = table.Column<int>(nullable: false),
                    id_usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesionalesXCampana", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProfesionalesXCampana_EntidadesXCampana_id_entidad",
                        column: x => x.id_entidad,
                        principalTable: "EntidadesXCampana",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesionalesXCampana_AspNetUsers_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Log_Auditoria",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_ficha = table.Column<string>(nullable: true),
                    estadoInicial = table.Column<string>(nullable: true),
                    estadoFinal = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: true),
                    id_usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_Auditoria", x => x.id);
                    table.ForeignKey(
                        name: "FK_Log_Auditoria_Ficha_id_ficha",
                        column: x => x.id_ficha,
                        principalTable: "Ficha",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Log_Auditoria_AspNetUsers_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rastro",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_ficha = table.Column<string>(nullable: true),
                    estadoInicial = table.Column<string>(nullable: true),
                    estadoFinal = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: true),
                    id_usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rastro", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rastro_Ficha_id_ficha",
                        column: x => x.id_ficha,
                        principalTable: "Ficha",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rastro_AspNetUsers_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    valor_string = table.Column<string>(nullable: true),
                    valor_float = table.Column<float>(nullable: true),
                    valor_integer = table.Column<int>(nullable: true),
                    valor_date = table.Column<DateTime>(nullable: true),
                    fecha = table.Column<DateTime>(nullable: true),
                    id_campo = table.Column<int>(nullable: false),
                    id_ficha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.id);
                    table.ForeignKey(
                        name: "FK_Registros_Campos_id_campo",
                        column: x => x.id_campo,
                        principalTable: "Campos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_Ficha_id_ficha",
                        column: x => x.id_ficha,
                        principalTable: "Ficha",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registros_Tablas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    valor_string = table.Column<string>(nullable: true),
                    valor_float = table.Column<float>(nullable: true),
                    valor_integer = table.Column<int>(nullable: true),
                    valor_date = table.Column<DateTime>(nullable: true),
                    fecha = table.Column<DateTime>(nullable: true),
                    id_column = table.Column<string>(nullable: true),
                    row = table.Column<string>(nullable: true),
                    id_campo = table.Column<int>(nullable: false),
                    id_ficha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros_Tablas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Registros_Tablas_Campos_id_campo",
                        column: x => x.id_campo,
                        principalTable: "Campos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_Tablas_Ficha_id_ficha",
                        column: x => x.id_ficha,
                        principalTable: "Ficha",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Revision_Ajuste",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_ficha = table.Column<string>(nullable: true),
                    estadoInicial = table.Column<string>(nullable: true),
                    estadoFinal = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: true),
                    id_usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revision_Ajuste", x => x.id);
                    table.ForeignKey(
                        name: "FK_Revision_Ajuste_Ficha_id_ficha",
                        column: x => x.id_ficha,
                        principalTable: "Ficha",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Revision_Ajuste_AspNetUsers_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Campos_id_categoria",
                table: "Campos",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Campos_id_plantilla",
                table: "Campos",
                column: "id_plantilla");

            migrationBuilder.CreateIndex(
                name: "IX_Campos_id_selector",
                table: "Campos",
                column: "id_selector");

            migrationBuilder.CreateIndex(
                name: "IX_Campos_id_validacion",
                table: "Campos",
                column: "id_validacion");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_id_plantilla",
                table: "Categorias",
                column: "id_plantilla");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadesXCampana_id_entidad",
                table: "EntidadesXCampana",
                column: "id_entidad");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadesXCampana_id_formulario",
                table: "EntidadesXCampana",
                column: "id_formulario");

            migrationBuilder.CreateIndex(
                name: "IX_Ficha_id_formulario",
                table: "Ficha",
                column: "id_formulario");

            migrationBuilder.CreateIndex(
                name: "IX_Ficha_id_plantilla",
                table: "Ficha",
                column: "id_plantilla");

            migrationBuilder.CreateIndex(
                name: "IX_Ficha_id_usuario",
                table: "Ficha",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Formularios_id_plantilla",
                table: "Formularios",
                column: "id_plantilla");

            migrationBuilder.CreateIndex(
                name: "IX_Formularios_id_usuario",
                table: "Formularios",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Log_Auditoria_id_ficha",
                table: "Log_Auditoria",
                column: "id_ficha");

            migrationBuilder.CreateIndex(
                name: "IX_Log_Auditoria_id_usuario",
                table: "Log_Auditoria",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalesXCampana_id_entidad",
                table: "ProfesionalesXCampana",
                column: "id_entidad");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalesXCampana_id_usuario",
                table: "ProfesionalesXCampana",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Rastro_id_ficha",
                table: "Rastro",
                column: "id_ficha");

            migrationBuilder.CreateIndex(
                name: "IX_Rastro_id_usuario",
                table: "Rastro",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_id_campo",
                table: "Registros",
                column: "id_campo");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_id_ficha",
                table: "Registros",
                column: "id_ficha");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_Tablas_id_campo",
                table: "Registros_Tablas",
                column: "id_campo");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_Tablas_id_ficha",
                table: "Registros_Tablas",
                column: "id_ficha");

            migrationBuilder.CreateIndex(
                name: "IX_Revision_Ajuste_id_ficha",
                table: "Revision_Ajuste",
                column: "id_ficha");

            migrationBuilder.CreateIndex(
                name: "IX_Revision_Ajuste_id_usuario",
                table: "Revision_Ajuste",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Selector_Detail_id_selector",
                table: "Selector_Detail",
                column: "id_selector");

            migrationBuilder.CreateIndex(
                name: "IX_Tablas_Campos_id_campo",
                table: "Tablas_Campos",
                column: "id_campo");

            migrationBuilder.CreateIndex(
                name: "IX_Tablas_Campos_id_selector",
                table: "Tablas_Campos",
                column: "id_selector");

            migrationBuilder.CreateIndex(
                name: "IX_Tablas_Campos_id_validacion",
                table: "Tablas_Campos",
                column: "id_validacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anla");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Log_Auditoria");

            migrationBuilder.DropTable(
                name: "ProfesionalesXCampana");

            migrationBuilder.DropTable(
                name: "Rastro");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Registros_Tablas");

            migrationBuilder.DropTable(
                name: "Revision_Ajuste");

            migrationBuilder.DropTable(
                name: "Selector_Detail");

            migrationBuilder.DropTable(
                name: "Tablas_Campos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EntidadesXCampana");

            migrationBuilder.DropTable(
                name: "Ficha");

            migrationBuilder.DropTable(
                name: "Campos");

            migrationBuilder.DropTable(
                name: "Entidad");

            migrationBuilder.DropTable(
                name: "Formularios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Selectores");

            migrationBuilder.DropTable(
                name: "Validacion");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Plantillas");
        }
    }
}
