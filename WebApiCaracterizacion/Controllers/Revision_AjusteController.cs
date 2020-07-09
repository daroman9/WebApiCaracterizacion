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
    public class Revision_AjusteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Revision_AjusteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Revision_Ajuste
        [HttpGet]
        public IEnumerable<Revision_Ajuste> GetRevision_Ajuste()
        {
            return _context.Revision_Ajuste;
        }

        // GET: api/Revision_Ajuste/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRevision_Ajuste([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var revision_Ajuste = await _context.Revision_Ajuste.FindAsync(id);

            if (revision_Ajuste == null)
            {
                return NotFound();
            }

            return Ok(revision_Ajuste);
        }

        // PUT: api/Revision_Ajuste/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRevision_Ajuste([FromRoute] int id, [FromBody] Revision_Ajuste revision_Ajuste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != revision_Ajuste.id)
            {
                return BadRequest();
            }

            _context.Entry(revision_Ajuste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Revision_AjusteExists(id))
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

        // POST: api/Revision_Ajuste
        [HttpPost]
        public async Task<IActionResult> PostRevision_Ajuste([FromBody] Revision_Ajuste revision_Ajuste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Revision_Ajuste.Add(revision_Ajuste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRevision_Ajuste", new { id = revision_Ajuste.id }, revision_Ajuste);
        }

        // DELETE: api/Revision_Ajuste/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRevision_Ajuste([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var revision_Ajuste = await _context.Revision_Ajuste.FindAsync(id);
            if (revision_Ajuste == null)
            {
                return NotFound();
            }

            _context.Revision_Ajuste.Remove(revision_Ajuste);
            await _context.SaveChangesAsync();

            return Ok(revision_Ajuste);
        }

        private bool Revision_AjusteExists(int id)
        {
            return _context.Revision_Ajuste.Any(e => e.id == id);
        }
    }
}