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
    public class Registro_TablaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Registro_TablaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Registro_Tabla
        [HttpGet]
        public IEnumerable<Registro_Tabla> GetRegistros_Tablas()
        {
            return _context.Registros_Tablas;
        }

        // GET: api/Registro_Tabla/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistro_Tabla([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro_Tabla = await _context.Registros_Tablas.FindAsync(id);

            if (registro_Tabla == null)
            {
                return NotFound();
            }

            return Ok(registro_Tabla);
        }

        // PUT: api/Registro_Tabla/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Registro_Tabla registro_Tabla, int id)
        {
            if (registro_Tabla.id != id)
            {
                return BadRequest("Ocurrio un error al modificar");
            }
            _context.Entry(registro_Tabla).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("byFicha/{id_ficha}")]
        public IActionResult GetRegistrosByPlantilla([FromRoute] string id_ficha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var registro = _context.Registros_Tablas.Where(x => x.id_ficha == id_ficha).ToList();
            if (registro == null)
            {
                return NotFound();
            }

            return Ok(registro);
        }
        // POST: api/Registro_Tabla
        [HttpPost]
        public async Task<IActionResult> PostRegistro_Tabla([FromBody] Registro_Tabla registro_Tabla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var verificar = _context.Registros_Tablas.AsNoTracking()
                .Where(x => x.id_campo == registro_Tabla.id_campo 
                && x.id_column==registro_Tabla.id_column 
                && x.row == registro_Tabla.row && x.id_ficha== registro_Tabla.id_ficha).FirstOrDefault();
            
            if (verificar == null)
            {
                _context.Registros_Tablas.Add(registro_Tabla);
                await _context.SaveChangesAsync();
            }
            else
            {
                var _id = verificar.id;
                registro_Tabla.id = _id;
                _context.Update(registro_Tabla);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetRegistro_Tabla", new { id = registro_Tabla.id }, registro_Tabla);
        }

        // DELETE: api/Registro_Tabla/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistro_Tabla([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro_Tabla = await _context.Registros_Tablas.FindAsync(id);
            if (registro_Tabla == null)
            {
                return NotFound();
            }

            _context.Registros_Tablas.Remove(registro_Tabla);
            await _context.SaveChangesAsync();

            return Ok(registro_Tabla);
        }

        private bool Registro_TablaExists(int id)
        {
            return _context.Registros_Tablas.Any(e => e.id == id);
        }
    }
}