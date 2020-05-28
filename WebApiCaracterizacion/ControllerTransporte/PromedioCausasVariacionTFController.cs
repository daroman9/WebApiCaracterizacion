using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCaracterizacion.DataTransporte;
using WebApiCaracterizacion.ModelsTransporte;

namespace WebApiCaracterizacion.ControllerTransporte
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromedioCausasVariacionTFController : ControllerBase
    {
        private readonly PromedioCausasVariacionRepositoryTF _repository;

        public PromedioCausasVariacionTFController(PromedioCausasVariacionRepositoryTF repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PromediosCausasVariacionTF>>> GetData([FromQuery]string tipoConsulta, [FromQuery]string fechaInicio, [FromQuery]string fechaFin)
        {
            return await _repository.GetPromedio(tipoConsulta, fechaInicio, fechaFin);
        }
    }
}