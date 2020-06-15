using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCaracterizacion.Models;
using caracterizacion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApiCaracterizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        // GET: api/Campos/5 filtrar por identificador de plantilla
        [HttpGet("byPlantilla/{id_plantilla}")]
        public IActionResult GetCamposByPlantilla([FromRoute] int id_plantilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var campo = _context.Campos.Where(x => x.id_plantilla == id_plantilla).ToList();
            if (campo == null)
            {
                return NotFound();
            }

            return Ok(campo);
        }

        // GET: api/Campos/5 filtrar por id de la categoria
        [HttpGet("byCategoria/{id_categoria}")]
        public IActionResult GetCamposByCategoria([FromRoute] int id_categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var campo = _context.Campos.Where(x => x.id_categoria == id_categoria).ToList();
            if (campo == null)
            {
                return NotFound();
            }

            return Ok(campo);
        }

        // GET: api/Campos/5 filtrar por id de la categoria
        [HttpGet("byCategoriaFicha/{id_categoria}/{id_plantilla}")]
        public IActionResult GetCamposByCategoriaFicha([FromRoute] int id_categoria, int id_plantilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var campo = _context.Campos.Where(x => x.id_categoria == id_categoria && x.id_plantilla==id_plantilla).ToList();
            if (campo == null)
            {
                return NotFound();
            }

            return Ok(campo);
        }


        // PUT: api/Campos/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Campo campo, int id)
        {
            if (campo.id != id)
            {
                return BadRequest("Ocurrio un error al modificar");
            }
            _context.Entry(campo).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
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

            return CreatedAtAction("GetCampo", new { id = campo.id }, campo);
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
            return _context.Campos.Any(e => e.id == id);
        }
    }
}