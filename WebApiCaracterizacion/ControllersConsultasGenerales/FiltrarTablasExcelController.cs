﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCaracterizacion.DataConsultasGenerales;
using WebApiCaracterizacion.ModelsConsultasGenerales;

namespace WebApiCaracterizacion.ControllersConsultasGenerales
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltrarTablasExcelController : ControllerBase
    {
        private readonly FiltrarTablasExcelRepository _repository;

        public FiltrarTablasExcelController(FiltrarTablasExcelRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FiltrarTablasExcel>>> GetData([FromQuery]string tipoFiltro, string aspecto,
            string codigo, string fechaInicio, string fechaFin, string email)
        {
            return await _repository.GetPromedio(tipoFiltro, aspecto,
            codigo, fechaInicio, fechaFin, email);
        }
    }
}