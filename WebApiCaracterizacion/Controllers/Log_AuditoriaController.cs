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
    public class Log_AuditoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Log_AuditoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Log_Auditoria
        [HttpGet]
        public IEnumerable<Log_Auditoria> GetLog_Auditoria()
        {
            return _context.Log_Auditoria;
        }

        // GET: api/Log_Auditoria/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLog_Auditoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var log_Auditoria = await _context.Log_Auditoria.FindAsync(id);

            if (log_Auditoria == null)
            {
                return NotFound();
            }

            return Ok(log_Auditoria);
        }

        // PUT: api/Log_Auditoria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLog_Auditoria([FromRoute] int id, [FromBody] Log_Auditoria log_Auditoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != log_Auditoria.id)
            {
                return BadRequest();
            }

            _context.Entry(log_Auditoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Log_AuditoriaExists(id))
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

        // POST: api/Log_Auditoria
        [HttpPost]
        public async Task<IActionResult> PostLog_Auditoria([FromBody] Log_Auditoria log_Auditoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Log_Auditoria.Add(log_Auditoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLog_Auditoria", new { id = log_Auditoria.id }, log_Auditoria);
        }

        // DELETE: api/Log_Auditoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLog_Auditoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var log_Auditoria = await _context.Log_Auditoria.FindAsync(id);
            if (log_Auditoria == null)
            {
                return NotFound();
            }

            _context.Log_Auditoria.Remove(log_Auditoria);
            await _context.SaveChangesAsync();

            return Ok(log_Auditoria);
        }

        private bool Log_AuditoriaExists(int id)
        {
            return _context.Log_Auditoria.Any(e => e.id == id);
        }
    }
}