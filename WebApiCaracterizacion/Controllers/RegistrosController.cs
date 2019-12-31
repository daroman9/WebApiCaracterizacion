using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RegistrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Registros
        [HttpGet]
        public IEnumerable<Registro> GetRegistros()
        {
            return _context.Registros;
        }

        // GET: api/Registros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro = await _context.Registros.FindAsync(id);

            if (registro == null)
            {
                return NotFound();
            }

            return Ok(registro);
        }

        // PUT: api/Registros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistro([FromRoute] int id, [FromBody] Registro registro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registro.id)
            {
                return BadRequest();
            }

            _context.Entry(registro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Registros
        [HttpPost]
        public async Task<IActionResult> PostRegistro([FromBody] Registro registro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Registros.Add(registro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistro", new { id = registro.id }, registro);
        }

        // DELETE: api/Registros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro = await _context.Registros.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }

            _context.Registros.Remove(registro);
            await _context.SaveChangesAsync();

            return Ok(registro);
        }

        private bool RegistroExists(int id)
        {
            return _context.Registros.Any(e => e.id == id);
        }
    }
}