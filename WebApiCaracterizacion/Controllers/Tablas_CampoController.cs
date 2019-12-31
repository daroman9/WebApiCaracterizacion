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
    public class Tablas_CampoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Tablas_CampoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tablas_Campo
        [HttpGet]
        public IEnumerable<Tablas_Campo> GetTablas_Campos()
        {
            return _context.Tablas_Campos;
        }

        // GET: api/Tablas_Campo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTablas_Campo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tablas_Campo = await _context.Tablas_Campos.FindAsync(id);

            if (tablas_Campo == null)
            {
                return NotFound();
            }

            return Ok(tablas_Campo);
        }

        // PUT: api/Tablas_Campo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTablas_Campo([FromRoute] int id, [FromBody] Tablas_Campo tablas_Campo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tablas_Campo.id)
            {
                return BadRequest();
            }

            _context.Entry(tablas_Campo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tablas_CampoExists(id))
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

        // POST: api/Tablas_Campo
        [HttpPost]
        public async Task<IActionResult> PostTablas_Campo([FromBody] Tablas_Campo tablas_Campo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tablas_Campos.Add(tablas_Campo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTablas_Campo", new { id = tablas_Campo.id }, tablas_Campo);
        }

        // DELETE: api/Tablas_Campo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTablas_Campo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tablas_Campo = await _context.Tablas_Campos.FindAsync(id);
            if (tablas_Campo == null)
            {
                return NotFound();
            }

            _context.Tablas_Campos.Remove(tablas_Campo);
            await _context.SaveChangesAsync();

            return Ok(tablas_Campo);
        }

        private bool Tablas_CampoExists(int id)
        {
            return _context.Tablas_Campos.Any(e => e.id == id);
        }
    }
}