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
    [Route("api/[controller]")]
    [ApiController]
    public class FormatoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public FormatoController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IEnumerable<Formato> GetAll(int Id)
        {
            return context.Formatos.Where(x => x.Id == Id).ToList();
        }

        [HttpGet("{id}", Name = "FormatoCreado")]
        public IActionResult GetById(int Id)
        {
            var formato = context.Formatos.FirstOrDefault(x => x.Id == Id);

            if (formato == null)
            {
                return NotFound();
            }
            return Ok(formato);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Formato formato)
        {
            if (ModelState.IsValid)
            {
                context.Formatos.Add(formato);
                context.SaveChanges();
                return new CreatedAtRouteResult("FormatoCreado", new { id = formato.Id }, formato);

            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Formato formato, int Id)
        {
            if (formato.Id != Id)
            {
                return BadRequest();
            }
            context.Entry(formato).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var formato = context.Formatos.FirstOrDefault(x => x.Id == Id);
            if (formato == null)
            {
                return NotFound();
            }
            context.Formatos.Remove(formato);
            context.SaveChanges();
            return Ok();
        }
    }
}
