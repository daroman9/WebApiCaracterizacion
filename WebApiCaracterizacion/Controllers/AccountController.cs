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


namespace WebApiCaracterizacion.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._configuration = configuration;
        }

        //Obtener todos los usuarios
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<ApplicationUser> ListUsers()
        {

            return _userManager.Users;
        }

        //Obtener un usuario por su documento
        [HttpGet("byDocumento/{documento}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        //Obtener un usuario por su id
        [HttpGet("byId/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateUser([FromBody] ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Nombre = model.Nombre, Apellido = model.Apellido, Documento = model.Documento, id_profesional= model.id_profesional };
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

                    return BuildToken(userInfo, datos.Nombre, datos.Apellido, datos.Id);
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
        private IActionResult BuildToken(ApplicationUser userInfo, string Nombre, string Apellido, string Id)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(10);

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
                id_user = Id

            });

        }
        //Funcion para modificar los datos del usuario.

        [HttpPut("updateUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
      
        //Funcion para el cambio de password
        [HttpPut("changePassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> changePassword([FromBody] ApplicationUser model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var code = model.Password;
                var newPass = HashPassword(code);
                user.PasswordHash = newPass;
                var result = await _userManager.UpdateAsync(user);


                return Ok("La contraseña se ha cambiado correctamente");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                var newPass = HashPassword(code);
                user.PasswordHash = newPass;
                SendEmail(emailRec, code);
                var result = await _userManager.UpdateAsync(user);


                return Ok("La contraseña se ha cambiado correctamente");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        //Funcion para enviar el correo, para recuperar contraseña
        private void SendEmail(string EmailDestino, string newPass)
        {
            string EmailOrigen = "desarrolloprosecto@gmail.com";
            string Pass = "cangr3j0pr0s3ctus";

            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Recuperación de contraseña",
               "<p>Hola,</p><br>" +
               "<p>Hemos procesado tu solicitud de cambio de clave.</p><br>" +
               "<p>La nueva contrase&ntilde;</p>" + newPass);

            oMailMessage.IsBodyHtml = true;

            SmtpClient osmtpClient = new SmtpClient("smtp.gmail.com");
            osmtpClient.EnableSsl = true;
            osmtpClient.UseDefaultCredentials = false;

            osmtpClient.Port = 587;
            osmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Pass);

            osmtpClient.Send(oMailMessage);

            osmtpClient.Dispose();

        }
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