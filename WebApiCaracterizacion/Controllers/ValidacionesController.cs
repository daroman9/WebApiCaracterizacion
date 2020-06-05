using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ValidacionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValidacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Validaciones
        [HttpGet]
        public IEnumerable<Validacion> GetValidacion()
        {
            return _context.Validacion;
        }

        // GET: api/Validaciones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValidacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validacion = await _context.Validacion.FindAsync(id);

            if (validacion == null)
            {
                return NotFound();
            }

            return Ok(validacion);
        }

        // PUT: api/Validaciones/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Validacion validacion, int id)
        {
            if (validacion.id != id)
            {
                return BadRequest("Ocurrio un error al modificar");
            }
            _context.Entry(validacion).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        // POST: api/Validaciones
        [HttpPost]
        public async Task<IActionResult> PostValidacion([FromBody] Validacion validacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Validacion.Add(validacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValidacion", new { id = validacion.id }, validacion);
        }

        // DELETE: api/Validaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValidacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validacion = await _context.Validacion.FindAsync(id);
            if (validacion == null)
            {
                return NotFound();
            }

            _context.Validacion.Remove(validacion);
            await _context.SaveChangesAsync();

            return Ok(validacion);
        }

        private bool ValidacionExists(int id)
        {
            return _context.Validacion.Any(e => e.id == id);
        }
    }
}