﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiCaracterizacion.DataTransporte;
using WebApiCaracterizacion.ModelsTransporte;

namespace WebApiCaracterizacion.ControllerTransporte
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PromedioEscolaridadUsuariosTFController : ControllerBase
    {
        private readonly PromedioEscoloridadUsuariosTFRepository _repository;

        public PromedioEscolaridadUsuariosTFController(PromedioEscoloridadUsuariosTFRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PromediosEscolaridadUsuariosTF>>> GetData([FromQuery]string tipoConsulta, [FromQuery]string fechaInicio, [FromQuery]string fechaFin)
        {
            return await _repository.GetPromedio(tipoConsulta, fechaInicio, fechaFin);
        }
    }
}