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
    public class Selector_DetailController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Selector_DetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Selector_Detail
        [HttpGet]
        public IEnumerable<Selector_Detail> GetSelector_Detail()
        {
            return _context.Selector_Detail;
        }

        // GET: api/Selector_Detail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSelector_Detail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var selector_Detail = await _context.Selector_Detail.FindAsync(id);

            if (selector_Detail == null)
            {
                return NotFound();
            }

            return Ok(selector_Detail);
        }

        // PUT: api/Fichas/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Selector_Detail selector_Detail, int id)
        {
            if (selector_Detail.id != id)
            {
                return BadRequest("Ocurrio un error al modificar");
            }
            _context.Entry(selector_Detail).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        // POST: api/Selector_Detail
        [HttpPost]
        public async Task<IActionResult> PostSelector_Detail([FromBody] Selector_Detail selector_Detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Selector_Detail.Add(selector_Detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSelector_Detail", new { id = selector_Detail.id }, selector_Detail);
        }

        // DELETE: api/Selector_Detail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelector_Detail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var selector_Detail = await _context.Selector_Detail.FindAsync(id);
            if (selector_Detail == null)
            {
                return NotFound();
            }

            _context.Selector_Detail.Remove(selector_Detail);
            await _context.SaveChangesAsync();

            return Ok(selector_Detail);
        }

        private bool Selector_DetailExists(int id)
        {
            return _context.Selector_Detail.Any(e => e.id == id);
        }
    }
}