using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCaracterizacion.DataMineria;
using WebApiCaracterizacion.ModelsMineria;

namespace WebApiCaracterizacion.ControllersMineria
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromedioTenenciaORController : ControllerBase
    {
        private readonly PromedioTenenciaORRepository _repository;

        public PromedioTenenciaORController(PromedioTenenciaORRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PromediosTenenciaOR>>> GetData([FromQuery]string plantilla, [FromQuery]string tipoConsulta, [FromQuery]string fechaInicio, [FromQuery]string fechaFin)
        {

            return await _repository.GetPromedio(plantilla, tipoConsulta, fechaInicio, fechaFin);

        }
    }
}