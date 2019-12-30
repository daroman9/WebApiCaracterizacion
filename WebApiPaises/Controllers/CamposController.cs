using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCaracterizacion.Models;
using caracterizacion.Models;

namespace WebApiCaracterizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamposController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CamposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Campos
        [HttpGet]
        public IEnumerable<Campo> GetCampos()
        {
            return _context.Campos;
        }

        // GET: api/Campos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var campo = await _context.Campos.FindAsync(id);

            if (campo == null)
            {
                return NotFound();
            }

            return Ok(campo);
        }

        // PUT: api/Campos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampo([FromRoute] int id, [FromBody] Campo campo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campo.ID)
            {
                return BadRequest();
            }

            _context.Entry(campo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampoExists(id))
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

        // POST: api/Campos
        [HttpPost]
        public async Task<IActionResult> PostCampo([FromBody] Campo campo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Campos.Add(campo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampo", new { id = campo.ID }, campo);
        }

        // DELETE: api/Campos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var campo = await _context.Campos.FindAsync(id);
            if (campo == null)
            {
                return NotFound();
            }

            _context.Campos.Remove(campo);
            await _context.SaveChangesAsync();

            return Ok(campo);
        }

        private bool CampoExists(int id)
        {
            return _context.Campos.Any(e => e.ID == id);
        }
    }
}