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
    public class AnlaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnlaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Anla
        [HttpGet]
        public IEnumerable<Anla> GetAnla()
        {
            return _context.Anla;
        }

        // GET: api/Anla/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnla([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var anla = await _context.Anla.FindAsync(id);

            if (anla == null)
            {
                return NotFound();
            }

            return Ok(anla);
        }

        // PUT: api/Anla/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnla([FromRoute] int id, [FromBody] Anla anla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anla.id)
            {
                return BadRequest();
            }

            _context.Entry(anla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnlaExists(id))
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

        // POST: api/Anla
        [HttpPost]
        public async Task<IActionResult> PostAnla([FromBody] Anla anla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Anla.Add(anla);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnla", new { id = anla.id }, anla);
        }

        // DELETE: api/Anla/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnla([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var anla = await _context.Anla.FindAsync(id);
            if (anla == null)
            {
                return NotFound();
            }

            _context.Anla.Remove(anla);
            await _context.SaveChangesAsync();

            return Ok(anla);
        }

        private bool AnlaExists(int id)
        {
            return _context.Anla.Any(e => e.id == id);
        }
    }
}