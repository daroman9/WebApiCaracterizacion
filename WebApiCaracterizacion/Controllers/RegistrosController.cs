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
    public class RegistrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Registros
        [HttpGet]
        public IEnumerable<Registro> GetRegistros()
        {
            return _context.Registro;
        }

        // GET: api/Registros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro = await _context.Registro.FindAsync(id);

            if (registro == null)
            {
                return NotFound();
            }

            return Ok(registro);
        }

        [HttpGet("byFicha/{id_ficha}")]
        public IActionResult GetRegistrosByPlantilla([FromRoute] string id_ficha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var registro = _context.Registro.Where(x => x.id_ficha == id_ficha).ToList();
            if (registro == null)
            {
                return NotFound();
            }

            return Ok(registro);
        }


        // PUT: api/Registros/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Registro registro, int id)
        {
            if (registro.id != id)
            {
                return BadRequest("Ocurrio un error al modificar");
            }
            _context.Entry(registro).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
        // POST: api/Registros
        [HttpPost]
        public async Task<IActionResult> PostRegistro([FromBody] Registro registro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Registro.Add(registro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistro", new { id = registro.id }, registro);
        }

        // DELETE: api/Registros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro = await _context.Registro.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }

            _context.Registro.Remove(registro);
            await _context.SaveChangesAsync();

            return Ok(registro);
        }

        private bool RegistroExists(int id)
        {
            return _context.Registro.Any(e => e.id == id);
        }
    }
}