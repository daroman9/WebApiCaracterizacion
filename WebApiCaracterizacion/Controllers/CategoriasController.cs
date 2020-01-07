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
using System.Data.SqlClient;

namespace WebApiCaracterizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public IEnumerable<Categoria> GetCategorias()
        {
            return _context.Categorias;
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // GET: api/Categorias/5 Filtrar por id de plantilla
        [HttpGet("byPlantilla/{id_plantilla}")]
        public IActionResult GetCategoriaByPlantilla([FromRoute] int id_plantilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoria =  _context.Categorias.Where(x => x.id_plantilla == id_plantilla).ToList();
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }
        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Categoria categoria, int id)
        {
            if (categoria.id != id)
            {
                return BadRequest("Ocurrio un error al modificar");
            }
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
        // POST: api/Categorias
        [HttpPost]
        public async Task<IActionResult> PostCategoria([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.id }, categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return Ok(categoria);
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.id == id);
        }
    }
}