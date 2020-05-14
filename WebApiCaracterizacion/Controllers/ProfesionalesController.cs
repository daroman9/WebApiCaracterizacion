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
    public class ProfesionalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfesionalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Profesionales
        [HttpGet]
        public IEnumerable<Profesionales> GetProfesionales()
        {
            return _context.Profesionales;
        }

        // GET: api/Profesionales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfesionales([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profesionales = await _context.Profesionales.FindAsync(id);

            if (profesionales == null)
            {
                return NotFound();
            }

            return Ok(profesionales);
        }

        // PUT: api/Profesionales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesionales([FromRoute] int id, [FromBody] Profesionales profesionales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesionales.id)
            {
                return BadRequest();
            }

            _context.Entry(profesionales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionalesExists(id))
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

        // POST: api/Profesionales
        [HttpPost]
        public async Task<IActionResult> PostProfesionales([FromBody] Profesionales profesionales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Profesionales.Add(profesionales);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesionales", new { id = profesionales.id }, profesionales);
        }

        // DELETE: api/Profesionales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesionales([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profesionales = await _context.Profesionales.FindAsync(id);
            if (profesionales == null)
            {
                return NotFound();
            }

            _context.Profesionales.Remove(profesionales);
            await _context.SaveChangesAsync();

            return Ok(profesionales);
        }

        private bool ProfesionalesExists(int id)
        {
            return _context.Profesionales.Any(e => e.id == id);
        }
    }
}