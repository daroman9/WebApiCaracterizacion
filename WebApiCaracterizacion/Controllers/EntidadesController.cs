using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Entidads
        [HttpGet]
        public IEnumerable<Entidad> GetEntidad()
        {
            return _context.Entidad;
        }

        // GET: api/Entidads/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntidad([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entidad = await _context.Entidad.FindAsync(id);

            if (entidad == null)
            {
                return NotFound();
            }

            return Ok(entidad);
        }

        // PUT: api/Entidads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntidad([FromRoute] int id, [FromBody] Entidad entidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entidad.id)
            {
                return BadRequest();
            }

            _context.Entry(entidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntidadExists(id))
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

        // POST: api/Entidads
        [HttpPost]
        public async Task<IActionResult> PostEntidad([FromBody] Entidad entidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entidad.Add(entidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntidad", new { id = entidad.id }, entidad);
        }

        // DELETE: api/Entidads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntidad([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entidad = await _context.Entidad.FindAsync(id);
            if (entidad == null)
            {
                return NotFound();
            }

            _context.Entidad.Remove(entidad);
            await _context.SaveChangesAsync();

            return Ok(entidad);
        }

        private bool EntidadExists(int id)
        {
            return _context.Entidad.Any(e => e.id == id);
        }
    }
}