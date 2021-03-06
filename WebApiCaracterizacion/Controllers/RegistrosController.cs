﻿using System.Collections.Generic;
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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            return _context.Registros;
        }

        // GET: api/Registros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro = await _context.Registros.FindAsync(id);

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
            var registro = _context.Registros.Where(x => x.id_ficha == id_ficha).ToList();
            if (registro == null)
            {
                return NotFound();
            }

            return Ok(registro);
        }


        [HttpGet("byCampo/{id_campo}")]
        public IActionResult GetRegistrosByPlantilla([FromRoute] int id_campo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var registro = _context.Registros.Where(x => x.id_campo == id_campo).ToList();
            if (registro == null)
            {
                return NotFound();
            }

            return Ok(registro);
        }

        [HttpGet("byCampoFicha/{id_campo}/{id_ficha}")]
        public IActionResult GetRegistrosByPlantillaFicha([FromRoute] int id_campo, string id_ficha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _context.Registros.Where(x => x.id_campo == id_campo && x.id_ficha == id_ficha).ToList();
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        //Metodo para sixto
        [HttpPut("update")]
        public IActionResult PutRegistroUpdate([FromBody] List<Registro> registro)
        {
            try
            {

                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in registro)
                        {
                            if(item.id != 0)
                            {
                                _context.Entry(item).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                            else
                            {
                                _context.Add(item);
                                _context.SaveChanges();

                            }
                           
                        }
                        transaction.Commit();
                    }
                    catch (System.Exception ex)
                    {
                        transaction.Rollback();
                        return BadRequest("Ocurrio un error al actualizar los registros " + ex.Message);
                    }

                }

                return Ok(registro);

            }
            catch (System.Exception ex)
            {
                return BadRequest("Ocurrio un error al actualizar los registros " + ex.Message);
            }

        }

        // PUT: api/Registros/5
        [HttpPut("{id_campo}/{id_ficha}")]
        public IActionResult PutRegistro([FromBody] Registro registro, int id_campo, string id_ficha)
        {
            if (registro.id_campo != id_campo && registro.id_ficha != id_ficha)
            {
                return BadRequest("Ocurrio un error al modificar");
            }
            _context.Entry(registro).State = EntityState.Modified;
            _context.SaveChanges();
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

            var verificar = _context.Registros.AsNoTracking().Where(x => x.id_campo == registro.id_campo && x.id_ficha == registro.id_ficha).FirstOrDefault();

            if (verificar == null)
            {
                _context.Registros.Add(registro);
                await _context.SaveChangesAsync();
            }
            else
            {
                var _id = verificar.id;
                registro.id = _id;
                _context.Update(registro);
                await _context.SaveChangesAsync();
            }

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

            var registro = await _context.Registros.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }

            _context.Registros.Remove(registro);
            await _context.SaveChangesAsync();

            return Ok(registro);
        }

        private bool RegistroExists(int id)
        {
            return _context.Registros.Any(e => e.id == id);
        }
    }
}