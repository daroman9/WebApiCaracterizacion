﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiCaracterizacion.DataMineria;
using WebApiCaracterizacion.ModelsMineria;

namespace WebApiCaracterizacion.ControllersMineria
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PromedioArraigoORController : ControllerBase
    {
        private readonly PromedioArraigoORRepository _repository;

        public PromedioArraigoORController(PromedioArraigoORRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PromediosArraigoOR>>> GetData([FromQuery]string plantilla, [FromQuery]string tipoConsulta, [FromQuery]string fechaInicio, [FromQuery]string fechaFin)
        {
           
                return await _repository.GetPromedio(plantilla, tipoConsulta, fechaInicio, fechaFin);
           
        }
    }
}
