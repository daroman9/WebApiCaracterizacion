using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Put([FromBody] Tablas_Campo tablas_Campo, int id)
        {
            if (tablas_Campo.id != id)
            {
                return BadRequest("Ocurrio un error al modificar");
            }
            _context.Entry(tablas_Campo).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
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