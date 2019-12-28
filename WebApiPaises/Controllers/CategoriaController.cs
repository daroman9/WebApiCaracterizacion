using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caracterizacion.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPaises.Models;

namespace caracterizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CategoriaController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Categoria> GetAll()
        {
            return context.Categorias.ToList();
        }

        [HttpGet("{id}", Name = "CategoriaCreada")]
        public IActionResult GetById(int id)
        {
            var categoria = context.Categorias.Include(x => x.Campos).FirstOrDefault(x => x.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
                return new CreatedAtRouteResult("CategoriaCreada", new { id = categoria.Id }, categoria);

            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Categoria categoria, int id)
        {
            if (categoria.Id != id)
            {
                return BadRequest();
            }
            context.Entry(categoria).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoria = context.Categorias.FirstOrDefault(x => x.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return Ok();
        }







    }
}