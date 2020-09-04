    using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCaracterizacion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace WebApiCaracterizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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


        // GET: api/Fichas/3 filtrar por identificador de plantilla
        [HttpGet("byIdPlantilla/{id_plantilla}")]
        public IActionResult GetFichaByPlantilla([FromRoute] int id_plantilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ficha = _context.Ficha.Where(x => x.id_plantilla == id_plantilla).ToList();
            if (ficha == null)
            {
                return NotFound();
            }

            return Ok(ficha);
        }


        // PUT: api/Fichas/5
        [HttpPut("{id}/{estado}")]
        public IActionResult Put([FromRoute] string id, int estado)
        {
            var ficha = _context.Ficha.Where(x => x.id == id).FirstOrDefault();
            if (ficha == null)
            {
                return BadRequest(false);
            }
            ficha.estado = estado;
            _context.Entry(ficha).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(true);
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