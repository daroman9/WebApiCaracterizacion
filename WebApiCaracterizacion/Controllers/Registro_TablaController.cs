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
    public class Registro_TablaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Registro_TablaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Registro_Tabla
        [HttpGet]
        public IEnumerable<Registro_Tabla> GetRegistros_Tablas()
        {
            return _context.Registros_Tablas;
        }

        // GET: api/Registro_Tabla/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistro_Tabla([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro_Tabla = await _context.Registros_Tablas.FindAsync(id);

            if (registro_Tabla == null)
            {
                return NotFound();
            }

            return Ok(registro_Tabla);
        }

        // PUT: api/Registro_Tabla/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistro_Tabla([FromRoute] int id, [FromBody] Registro_Tabla registro_Tabla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registro_Tabla.id)
            {
                return BadRequest();
            }

            _context.Entry(registro_Tabla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Registro_TablaExists(id))
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

        // POST: api/Registro_Tabla
        [HttpPost]
        public async Task<IActionResult> PostRegistro_Tabla([FromBody] Registro_Tabla registro_Tabla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Registros_Tablas.Add(registro_Tabla);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistro_Tabla", new { id = registro_Tabla.id }, registro_Tabla);
        }

        // DELETE: api/Registro_Tabla/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistro_Tabla([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro_Tabla = await _context.Registros_Tablas.FindAsync(id);
            if (registro_Tabla == null)
            {
                return NotFound();
            }

            _context.Registros_Tablas.Remove(registro_Tabla);
            await _context.SaveChangesAsync();

            return Ok(registro_Tabla);
        }

        private bool Registro_TablaExists(int id)
        {
            return _context.Registros_Tablas.Any(e => e.id == id);
        }
    }
}