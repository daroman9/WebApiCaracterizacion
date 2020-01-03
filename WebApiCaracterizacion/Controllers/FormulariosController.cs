using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class FormulariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FormulariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Formularios
        [HttpGet]
        public IEnumerable<Formulario> GetFormularios()
        {
            return _context.Formularios;
        }

        // GET: api/Formularios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormulario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formulario = await _context.Formularios.FindAsync(id);

            if (formulario == null)
            {
                return NotFound();
            }

            return Ok(formulario);
        }
        // GET: api/Formularios/byUsuario/5 obtener los formularios por el id usuario
        [HttpGet("byUsuario/{id_usuario}")]
        public IActionResult GetCategoriaByPlantilla([FromRoute] string id_usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var formulario = _context.Formularios.Where(x => x.id_usuario == id_usuario).ToList();
            if (formulario == null)
            {
                return NotFound();
            }

            return Ok(formulario);
        }
        // PUT: api/Formularios/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Formulario formulario, int id)
        {
            if (formulario.id != id)
            {
                return BadRequest();
            }
            _context.Entry(formulario).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        // POST: api/Formularios
        [HttpPost]
        public async Task<IActionResult> PostFormulario([FromBody] Formulario formulario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Formularios.Add(formulario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormulario", new { id = formulario.id }, formulario);
        }

        // DELETE: api/Formularios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormulario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formulario = await _context.Formularios.FindAsync(id);
            if (formulario == null)
            {
                return NotFound();
            }

            _context.Formularios.Remove(formulario);
            await _context.SaveChangesAsync();

            return Ok(formulario);
        }

        private bool FormularioExists(int id)
        {
            return _context.Formularios.Any(e => e.id == id);
        }
    }
}