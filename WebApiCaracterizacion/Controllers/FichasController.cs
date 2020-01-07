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
    public class FichasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FichasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Fichas
        [HttpGet]
        public IEnumerable<Ficha> GetFicha()
        {
            return _context.Ficha;
        }

        // GET: api/Fichas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFicha([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ficha = await _context.Ficha.FindAsync(id);

            if (ficha == null)
            {
                return NotFound();
            }

            return Ok(ficha);
        }

        // PUT: api/Fichas/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Ficha ficha, string id)
        {
            if (ficha.id != id)
            {
                return BadRequest("Ocurrio un error al modificar");
            }
            _context.Entry(ficha).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
        // POST: api/Fichas
        [HttpPost]
        public async Task<IActionResult> PostFicha([FromBody] Ficha ficha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ficha.Add(ficha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFicha", new { id = ficha.id }, ficha);
        }

        // DELETE: api/Fichas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFicha([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ficha = await _context.Ficha.FindAsync(id);
            if (ficha == null)
            {
                return NotFound();
            }

            _context.Ficha.Remove(ficha);
            await _context.SaveChangesAsync();

            return Ok(ficha);
        }

        private bool FichaExists(string id)
        {
            return _context.Ficha.Any(e => e.id == id);
        }
    }
}