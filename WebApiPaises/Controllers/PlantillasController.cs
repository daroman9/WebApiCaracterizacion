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
    public class PlantillasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlantillasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Plantillas
        [HttpGet]
        public IEnumerable<Plantilla> GetPlantillas()
        {
            return _context.Plantillas;
        }

        // GET: api/Plantillas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlantilla([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plantilla = await _context.Plantillas.FindAsync(id);

            if (plantilla == null)
            {
                return NotFound();
            }

            return Ok(plantilla);
        }

        // PUT: api/Plantillas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantilla([FromRoute] int id, [FromBody] Plantilla plantilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plantilla.ID)
            {
                return BadRequest();
            }

            _context.Entry(plantilla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantillaExists(id))
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

        // POST: api/Plantillas
        [HttpPost]
        public async Task<IActionResult> PostPlantilla([FromBody] Plantilla plantilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Plantillas.Add(plantilla);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantilla", new { id = plantilla.ID }, plantilla);
        }

        // DELETE: api/Plantillas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantilla([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plantilla = await _context.Plantillas.FindAsync(id);
            if (plantilla == null)
            {
                return NotFound();
            }

            _context.Plantillas.Remove(plantilla);
            await _context.SaveChangesAsync();

            return Ok(plantilla);
        }

        private bool PlantillaExists(int id)
        {
            return _context.Plantillas.Any(e => e.ID == id);
        }
    }
}