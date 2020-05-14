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
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            return _context.Plantilla;
        }

        // GET: api/Plantillas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlantilla([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plantilla = await _context.Plantilla.FindAsync(id);

            if (plantilla == null)
            {
                return NotFound();
            }

            return Ok(plantilla);
        }

        // PUT: api/Plantillas/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Plantilla plantilla, int id)
        {
            if (plantilla.id != id)
            {
                return BadRequest("Ocurrio un error al modificar");
            }
            _context.Entry(plantilla).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        // POST: api/Plantillas
        [HttpPost]
        public async Task<IActionResult> PostPlantilla([FromBody] Plantilla plantilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Plantilla.Add(plantilla);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantilla", new { id = plantilla.id }, plantilla);
        }

        // DELETE: api/Plantillas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantilla([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plantilla = await _context.Plantilla.FindAsync(id);
            if (plantilla == null)
            {
                return NotFound();
            }

            _context.Plantilla.Remove(plantilla);
            await _context.SaveChangesAsync();

            return Ok(plantilla);
        }

        private bool PlantillaExists(int id)
        {
            return _context.Plantilla.Any(e => e.id == id);
        }
    }
}