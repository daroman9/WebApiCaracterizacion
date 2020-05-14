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
    public class ProfesionalesXCampanasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfesionalesXCampanasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProfesionalesXCampanas
        [HttpGet]
        public IEnumerable<ProfesionalesXCampana> GetProfesionalesXCampana()
        {
            return _context.ProfesionalesXCampana;
        }

        // GET: api/ProfesionalesXCampanas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfesionalesXCampana([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profesionalesXCampana = await _context.ProfesionalesXCampana.FindAsync(id);

            if (profesionalesXCampana == null)
            {
                return NotFound();
            }

            return Ok(profesionalesXCampana);
        }

        // PUT: api/ProfesionalesXCampanas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesionalesXCampana([FromRoute] int id, [FromBody] ProfesionalesXCampana profesionalesXCampana)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesionalesXCampana.id)
            {
                return BadRequest();
            }

            _context.Entry(profesionalesXCampana).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionalesXCampanaExists(id))
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

        // POST: api/ProfesionalesXCampanas
        [HttpPost]
        public async Task<IActionResult> PostProfesionalesXCampana([FromBody] ProfesionalesXCampana profesionalesXCampana)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProfesionalesXCampana.Add(profesionalesXCampana);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesionalesXCampana", new { id = profesionalesXCampana.id }, profesionalesXCampana);
        }

        // DELETE: api/ProfesionalesXCampanas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesionalesXCampana([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profesionalesXCampana = await _context.ProfesionalesXCampana.FindAsync(id);
            if (profesionalesXCampana == null)
            {
                return NotFound();
            }

            _context.ProfesionalesXCampana.Remove(profesionalesXCampana);
            await _context.SaveChangesAsync();

            return Ok(profesionalesXCampana);
        }

        private bool ProfesionalesXCampanaExists(int id)
        {
            return _context.ProfesionalesXCampana.Any(e => e.id == id);
        }
    }
}