﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCaracterizacion.Data;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromedioEscolaridadController : ControllerBase
    {
        private readonly PromedioEscolaridadRepository _repository;

        public PromedioEscolaridadController(PromedioEscolaridadRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // Petición http para traer el promedio de generos de agricultura
        [HttpGet("agricultura")]
        public async Task<ActionResult<IEnumerable<PromediosEscolaridad>>> GetAgro([FromQuery]string fechaInicio, [FromQuery]string fechaFin)
        {
            return await _repository.GetPromedioAgricultura(fechaInicio, fechaFin);
        }
    }
}