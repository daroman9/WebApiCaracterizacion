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
    public class SelectorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SelectorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Selectors
        [HttpGet]
        public IEnumerable<Selector> GetSelectores()
        {
            return _context.Selectores;
        }

        // GET: api/Selectors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSelector([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var selector = await _context.Selectores.FindAsync(id);

            if (selector == null)
            {
                return NotFound();
            }

            return Ok(selector);
        }

        // PUT: api/Selectors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelector([FromRoute] int id, [FromBody] Selector selector)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != selector.id)
            {
                return BadRequest();
            }

            _context.Entry(selector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectorExists(id))
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

        // POST: api/Selectors
        [HttpPost]
        public async Task<IActionResult> PostSelector([FromBody] Selector selector)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Selectores.Add(selector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSelector", new { id = selector.id }, selector);
        }

        // DELETE: api/Selectors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelector([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var selector = await _context.Selectores.FindAsync(id);
            if (selector == null)
            {
                return NotFound();
            }

            _context.Selectores.Remove(selector);
            await _context.SaveChangesAsync();

            return Ok(selector);
        }

        private bool SelectorExists(int id)
        {
            return _context.Selectores.Any(e => e.id == id);
        }
    }
}