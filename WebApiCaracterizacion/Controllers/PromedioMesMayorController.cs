﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCaracterizacion.Data;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromedioMesMayorController : ControllerBase
    {
        private readonly PromedioMesesMayorRepository _repository;

        public PromedioMesMayorController(PromedioMesesMayorRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromediosMesesMayor>>> GetData([FromQuery]string tipoConsulta, [FromQuery]string fechaInicio, [FromQuery]string fechaFin)
        {
            return await _repository.GetPromedio(tipoConsulta, fechaInicio, fechaFin);
        }
    }
}
