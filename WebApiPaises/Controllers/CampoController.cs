using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caracterizacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPaises.Models;

namespace caracterizacion.Controllers
{
    [Route("api/Categoria/{CategoriaId}/Campo")]
    [ApiController]
    public class CampoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CampoController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IEnumerable<Campo> GetAll(int CategoriaId)
        {
            return context.Campos.Where(x => x.CategoriaId == CategoriaId).ToList();
        }

        [HttpGet("{id}", Name = "CampoCreado")]
        public IActionResult GetById(int id)
        {
            var campo = context.Campos.FirstOrDefault(x => x.Id == id);

            if (campo == null)
            {
                return NotFound();
            }
            return Ok(campo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Campo campo)
        {
            if (ModelState.IsValid)
            {
                context.Campos.Add(campo);
                context.SaveChanges();
                return new CreatedAtRouteResult("CampoCreado", new { id = campo.Id }, campo);

            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Campo campo, int id)
        {
            if (campo.Id != id)
            {
                return BadRequest();
            }
            context.Entry(campo).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var campo = context.Campos.FirstOrDefault(x => x.Id == id);
            if (campo == null)
            {
                return NotFound();
            }
            context.Campos.Remove(campo);
            context.SaveChanges();
            return Ok();
        }
    }
}