﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiCaracterizacion.DataGanaderia;
using WebApiCaracterizacion.ModelsGanaderia;

namespace WebApiCaracterizacion.ControllersGanaderia
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PromedioEstadoCivilGNController : ControllerBase
    {
        private readonly PromedioEstadoCivilGNRepository _repository;

        public PromedioEstadoCivilGNController(PromedioEstadoCivilGNRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PromediosEstadoCivilGN>>> GetData([FromQuery]string plantilla, [FromQuery]string tipoConsulta, [FromQuery]string fechaInicio, [FromQuery]string fechaFin)
        {
            return await _repository.GetPromedio(plantilla, tipoConsulta, fechaInicio, fechaFin);
        }
    }
}