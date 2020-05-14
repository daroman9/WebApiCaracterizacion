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
    public class EntidadesXCampanasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntidadesXCampanasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EntidadesXCampanas
        [HttpGet]
        public IEnumerable<EntidadesXCampana> GetEntidadesXCampana()
        {
            return _context.EntidadesXCampana;
        }

        // GET: api/EntidadesXCampanas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntidadesXCampana([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entidadesXCampana = await _context.EntidadesXCampana.FindAsync(id);

            if (entidadesXCampana == null)
            {
                return NotFound();
            }

            return Ok(entidadesXCampana);
        }

        // PUT: api/EntidadesXCampanas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntidadesXCampana([FromRoute] int id, [FromBody] EntidadesXCampana entidadesXCampana)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entidadesXCampana.id)
            {
                return BadRequest();
            }

            _context.Entry(entidadesXCampana).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntidadesXCampanaExists(id))
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

        // POST: api/EntidadesXCampanas
        [HttpPost]
        public async Task<IActionResult> PostEntidadesXCampana([FromBody] EntidadesXCampana entidadesXCampana)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EntidadesXCampana.Add(entidadesXCampana);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntidadesXCampana", new { id = entidadesXCampana.id }, entidadesXCampana);
        }

        // DELETE: api/EntidadesXCampanas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntidadesXCampana([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entidadesXCampana = await _context.EntidadesXCampana.FindAsync(id);
            if (entidadesXCampana == null)
            {
                return NotFound();
            }

            _context.EntidadesXCampana.Remove(entidadesXCampana);
            await _context.SaveChangesAsync();

            return Ok(entidadesXCampana);
        }

        private bool EntidadesXCampanaExists(int id)
        {
            return _context.EntidadesXCampana.Any(e => e.id == id);
        }
    }
}