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
    public class PromedioEstadosTFController : ControllerBase
    {
        private readonly PromedioEstadoTFRepository _repository;

        public PromedioEstadosTFController(PromedioEstadoTFRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PromediosEstadosTF>>> GetData([FromQuery]string tipoConsulta, [FromQuery]string fechaInicio, [FromQuery]string fechaFin)
        {
            return await _repository.GetPromedio(tipoConsulta, fechaInicio, fechaFin);
        }
    }
}