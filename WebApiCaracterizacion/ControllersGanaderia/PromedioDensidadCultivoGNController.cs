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
    public class PromedioDensidadCultivoGNController : ControllerBase
    {
        private readonly PromedioDensidadCultivoGNRepository _repository;

        public PromedioDensidadCultivoGNController(PromedioDensidadCultivoGNRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PromediosDensidadCultivoGN>>> GetData([FromQuery]string plantilla, [FromQuery]string tipoConsulta, [FromQuery]string incluyeCultivo, [FromQuery]string fechaInicio, [FromQuery]string fechaFin)
        {
            return await _repository.GetPromedio(plantilla, tipoConsulta, incluyeCultivo, fechaInicio, fechaFin);
        }
    }
}