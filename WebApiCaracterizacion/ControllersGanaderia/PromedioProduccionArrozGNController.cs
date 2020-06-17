using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCaracterizacion.DataGanaderia;
using WebApiCaracterizacion.ModelsGanaderia;


namespace WebApiCaracterizacion.ControllersGanaderia
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromedioProduccionArrozGNController : ControllerBase
    {
        private readonly PromedioProduccionArrozGNRepository _repository;

        public PromedioProduccionArrozGNController(PromedioProduccionArrozGNRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PromediosProduccionArrozGN>>> GetData([FromQuery]string plantilla, [FromQuery]string tipoConsulta, [FromQuery]string fechaInicio, [FromQuery]string fechaFin)
        {
            return await _repository.GetPromedio(plantilla, tipoConsulta, fechaInicio, fechaFin);
        }
    }
}