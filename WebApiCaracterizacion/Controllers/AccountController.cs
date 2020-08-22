using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using WebApiCaracterizacion.Models;
using System.Security.Cryptography;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebApiCaracterizacion.Services;


namespace WebApiCaracterizacion.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly GooglereCaptchaService _GooglereCaptchaService;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;


        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            GooglereCaptchaService _googlereCaptchaService,
            IMailService mailService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _GooglereCaptchaService = _googlereCaptchaService;
            _mailService = mailService;

            this._configuration = configuration;
        }

        //Obtener todos los usuarios
        [HttpGet]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<ApplicationUser> ListUsers()
        {

            return _userManager.Users;
        }

        //Obtener un usuario por su documento
        [HttpGet("byDocumento/{documento}")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUsuario([FromRoute] int documento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuario = _userManager.Users.Where(x => x.Documento == documento).ToList();
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        //Obtener un usuario por su documento y por rol
        [HttpGet("byDocumentoAndRol/{documento}/{rol}")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUsuariobyDocumentoAndRol([FromRoute] int documento, int rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuario = _userManager.Users.Where(x => x.Documento == documento && x.Rol == rol).ToList();
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        //Obtener un usuario por su documento y por rol
        [HttpGet("byRol/{rol}")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUsuariobyRol([FromRoute] int rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuario = _userManager.Users.Where(x => x.Rol == rol).ToList();
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        //Obtener un usuario por su id
        [HttpGet("byId/{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUsuarioById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuario = _userManager.Users.Where(x => x.Id == id).ToList();
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


        //Crear usuarios nuevos
        [Route("Create")]
        [HttpPost]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateUser([FromBody] ApplicationUser model)
        {

            var searchUser = _userManager.Users.FirstOrDefault(x => x.Documento == model.Documento);

            if (searchUser ==null)
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Nombre = model.Nombre, Apellido = model.Apellido, Documento = model.Documento, Telefono = model.Telefono, Rol = model.Rol };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return Ok("Usuario creado correctamente");
                    }
                    else
                    {
                        return BadRequest("Ocurrio un error, email o password invalidos");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest("El usuario ya se encuentra creado");
            }

        }



        //Login con captcha para el aplicativo web
         [HttpPost]

         [Route("LoginCaptcha")]

        public async Task<IActionResult> LoginCaptcha([FromBody] ApplicationUser userInfo, [FromQuery] string recaptcha)
         {
            //Google Recaptcha para seguridad sanitaria
           //string secretKey = "6LewE7oZAAAAANDxTioB90mzHdh2ozP9rtMqcd5U";

            //Google Recaptcha para sociapp
             string secretKey = "6Lfc17sZAAAAAM2LDvzo7674prtyB0eTc-n4DKoh";
              var _GoogleReCaptcha = _GooglereCaptchaService.VerifyCaptcha(recaptcha, secretKey);

              if (!_GoogleReCaptcha.Result.success)
             {
                 return BadRequest("Captcha incorrecto");
             }else
             {
             if (ModelState.IsValid)
             {
               var datos = await _userManager.FindByEmailAsync(userInfo.Email);

               var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
               if (result.Succeeded)
                {
               if (datos.Rol != 0)
                {
                   string fuente = "web";
                   return BuildToken(datos, datos.Nombre, datos.Apellido, datos.Id, datos.Rol, fuente);
               }
               else
               {
                 return Unauthorized();
               }

          }
          else
          {
           ModelState.AddModelError(string.Empty, "Invalid login attempt.");
           return BadRequest(ModelState);
          }
          }
          else
         {
           return BadRequest(ModelState);
          }
          }



        }

        //Login de los usuarios registrados, esta funcion devuelve el token para la autenticacion
        [HttpPost]

        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] ApplicationUser userInfo)
        {
            if (ModelState.IsValid)
            {

                var datos = await _userManager.FindByEmailAsync(userInfo.Email);

                var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (datos.Rol != 0)
                    {
                        string fuente = "movil";
                        return BuildToken(userInfo, datos.Nombre, datos.Apellido, datos.Id, datos.Rol, fuente);
                    }
                    else
                    {
                        return Unauthorized();
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        //Funcion que crea el token

        private IActionResult BuildToken(ApplicationUser userInfo, string Nombre, string Apellido, string Id, int Rol, string fuente)
        {

            if (Rol == 1)
            {
                var Token = AddAdminClaim(userInfo, Nombre, Apellido, Id, Rol, fuente);
                return (Token);

            }
            else if (Rol == 2)
            {
                var Token = AddUserClaim(userInfo, Nombre, Apellido, Id, Rol, fuente);
                return (Token);
            }
            else if (Rol == 3)
            {
                var Token = AddAnalistaClaim(userInfo, Nombre, Apellido, Id, Rol, fuente);
                return (Token);
            }
            else
            {
                var Token = AddDeshabilitadoClaim(userInfo, Nombre, Apellido, Id, Rol, fuente);
                return (Token);
            }

        }


        //Funcion para añadir el claim de adminisitrador
        private IActionResult AddAdminClaim(ApplicationUser userInfo, string Nombre, string Apellido, string Id, int Rol, string fuente)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("Rol", "Admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(1);
            if (fuente == "movil")
            {
                 expiration = DateTime.UtcNow.AddDays(90);
            }
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration,
                nombre = Nombre,
                apellido = Apellido,
                email = userInfo.Email,
                id_user = Id,
                rol = Rol

            });

        }

        //Funcion para añadir el claim de usuario
        private IActionResult AddUserClaim(ApplicationUser userInfo, string Nombre, string Apellido, string Id, int Rol, string fuente)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("Rol", "Usuario"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);
            if (fuente == "movil")
            {
                expiration = DateTime.UtcNow.AddDays(90);
            }

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration,
                nombre = Nombre,
                apellido = Apellido,
                email = userInfo.Email,
                id_user = Id,
                rol = Rol

            });

        }

        //Funcion para añadir el claim de Analista
        private IActionResult AddAnalistaClaim(ApplicationUser userInfo, string Nombre, string Apellido, string Id, int Rol, string fuente)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("Rol", "Analista"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);
            if (fuente == "movil")
            {
                expiration = DateTime.UtcNow.AddDays(90);
            }

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration,
                nombre = Nombre,
                apellido = Apellido,
                email = userInfo.Email,
                id_user = Id,
                rol = Rol

            });

        }

        //Funcion para añadir el claim de deshabilitado
        private IActionResult AddDeshabilitadoClaim(ApplicationUser userInfo, string Nombre, string Apellido, string Id, int Rol, string fuente)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("Rol", "Deshabilitado"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);
            if (fuente == "movil")
            {
                expiration = DateTime.UtcNow.AddDays(90);
            }

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration,
                nombre = Nombre,
                apellido = Apellido,
                email = userInfo.Email,
                id_user = Id,
                rol = Rol

            });

        }


        //Funcion para modificar los datos del usuario haciendo busqueda por el email

        [HttpPut("updateUser")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> updateUser([FromBody] ApplicationUser model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                user.Nombre = model.Nombre;
                user.Apellido = model.Apellido;
                user.Documento = model.Documento;
                user.Email = model.Email;
                var code = model.Password;
                var newPass = HashPassword(code);
                user.PasswordHash = newPass;
                var result = await _userManager.UpdateAsync(user);

                return Ok("Los datos del usuario se han modificado con exito");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        //Funcion para modificar los datos del usuario haciendo busqueda por el documento
        [HttpPut("updateUserByDocument/{documento}")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> updateUserByDocument([FromBody] ApplicationUser model, [FromRoute] int documento)
        {
            try
            {

                var user = _userManager.Users.FirstOrDefault(x => x.Documento == documento);

                user.Nombre = model.Nombre;
                user.Apellido = model.Apellido;
                user.Documento = model.Documento;
                user.Email = model.Email;
                user.Telefono = model.Telefono;
                user.Rol = model.Rol;
                var result = await _userManager.UpdateAsync(user);

                return Ok("Los datos del usuario se han modificado con exito");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        //Funcion para el cambio de password
        [HttpPut("changePassword")]
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> changePassword([FromBody] ApplicationUser model)
        {
            try
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Email == model.Email && x.codRecovery == model.codRecovery);
               // var user = await _userManager.FindByEmailAsync(model.Email);
                var code = model.Password;
                var newPass = HashPassword(code);
                user.PasswordHash = newPass;
                user.codRecovery = "";
                var result = await _userManager.UpdateAsync(user);


                return Ok("La contraseña se ha cambiado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest("No se pudo cambiar el password");
                throw new Exception(ex.Message);
            }

        }

        //Funcion para la recuperacion de la contraseña
        [HttpPost("recordar")]
        public async Task<IActionResult> recovery([FromBody] ApplicationUser model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var emailRec = model.Email;
                var code = GenerateCode();
                user.codRecovery = code;
                SendEmail(emailRec, code);
                var result = await _userManager.UpdateAsync(user);


                return Ok("Se ha enviado el correo exitosamente ");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }







        // Funcion para eliminar un usuario que no tiene asociado un formulario
        [HttpDelete("deleteUser/{documento}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int documento)
        {
            try
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Documento == documento);
                await _userManager.DeleteAsync(user);
                return Ok("Usuario eliminado correctamente");
            }
            catch (Exception)
            {
                return BadRequest("El usuario no puede ser eliminado: ");
               
            }

        }

        //Funcion para la recuperacion de la contraseña
        [HttpPost("recovery")]
        public async Task<IActionResult> recoveryPassword([FromBody] ApplicationUser model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var emailRec = model.Email;
                var code = GenerateCode();
                user.codRecovery = code;
                // var newPass = HashPassword(code);
                // user.PasswordHash = newPass;
                await SendEmail(emailRec, code);
                var result = await _userManager.UpdateAsync(user);


                return Ok("Se ha enviado el correo exitosamente");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        //Enviar correo con sendgrid
        private async Task<IActionResult> SendEmail(string EmailDestino, string newPass)
        {

          await  _mailService.SendEmail(EmailDestino, "Recuperación de contraseña",
               "<p>Hola,</p><br>" +
               "<p>Hemos procesado tu solicitud de cambio de clave.</p><br>" +
               "<p>Código de validación</p>" + newPass);

            return Ok("Se ha enviado el correo exitosamete");
        }


      

        //Funcion para enviar el correo, para recuperar contraseña
       // private void SendEmail(string EmailDestino, string newPass)
       // {
         //   string EmailOrigen = "daroman9@gmail.com";
           // string Pass = "daroman94621361";
            //  string Pass = "cangr3j0pr0s3ctus";

          //  MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Recuperación de contraseña",
             //  "<p>Hola,</p><br>" +
             //  "<p>Hemos procesado tu solicitud de cambio de clave.</p><br>" +
             //  "<p>Código de validación</p>" + newPass);

           // oMailMessage.IsBodyHtml = true;

           // SmtpClient osmtpClient = new SmtpClient("smtp.gmail.com");
          //  osmtpClient.EnableSsl = true;
           // osmtpClient.UseDefaultCredentials = false;
          //  osmtpClient.Host = "smtp.gmail.com";

           // osmtpClient.Port = 587;
          //  osmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Pass);

          //  osmtpClient.Send(oMailMessage);

          //  osmtpClient.Dispose();

      //  }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        //Funcion que crea un numero aleatorio para usarlo en el nuevo password
        public string GenerateCode()
        {
            string[] array = new string[6];
            for (int i = 0; i <= 5; i++)
            {
                Random rand = new Random();
                var value = rand.Next(0, 9);
                array[i] = value.ToString();
            }
            string codigo = ConvertStringArrayToString(array);
            return codigo;

        }
        static string ConvertStringArrayToString(string[] array)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);

            }
            return builder.ToString();
        }

    }
}