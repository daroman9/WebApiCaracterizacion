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
    public class RastroesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RastroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Rastroes
        [HttpGet]
        public IEnumerable<Rastro> GetRastro()
        {
            return _context.Rastro;
        }

        // GET: api/Rastroes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRastro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rastro = await _context.Rastro.FindAsync(id);

            if (rastro == null)
            {
                return NotFound();
            }

            return Ok(rastro);
        }

        // PUT: api/Rastroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRastro([FromRoute] int id, [FromBody] Rastro rastro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rastro.id)
            {
                return BadRequest();
            }

            _context.Entry(rastro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RastroExists(id))
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

        // POST: api/Rastroes
        [HttpPost]
        public async Task<IActionResult> PostRastro([FromBody] Rastro rastro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Rastro.Add(rastro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRastro", new { id = rastro.id }, rastro);
        }

        // DELETE: api/Rastroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRastro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rastro = await _context.Rastro.FindAsync(id);
            if (rastro == null)
            {
                return NotFound();
            }

            _context.Rastro.Remove(rastro);
            await _context.SaveChangesAsync();

            return Ok(rastro);
        }

        private bool RastroExists(int id)
        {
            return _context.Rastro.Any(e => e.id == id);
        }
    }
}