using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCaracterizacion.DataGanaderia;
using WebApiCaracterizacion.ModelsGanaderia;

namespace WebApiCaracterizacion.DataGanaderia
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromedioNivelPoblacionVulnerableGNController : ControllerBase
    {
        private readonly PromedioNivelPoblacionVulnerableGNRepository _repository;

        public PromedioNivelPoblacionVulnerableGNController(PromedioNivelPoblacionVulnerableGNRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PromediosNivelPoblacionVulnerableGN>>> GetData([FromQuery]string plantilla, [FromQuery]string tipoConsulta, [FromQuery]string fechaInicio, [FromQuery]string fechaFin)
        {
            return await _repository.GetPromedio(plantilla, tipoConsulta, fechaInicio, fechaFin);
        }
    }
}