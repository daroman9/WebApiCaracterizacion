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
    public class PromedioMenosProductividadTFController : ControllerBase
    {
        private readonly PromedioMenosProductividadTFRepository _repository;

        public PromedioMenosProductividadTFController(PromedioMenosProductividadTFRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PromediosMenosProductividadTF>>> GetData([FromQuery]string tipoConsulta, [FromQuery]string fechaInicio, [FromQuery]string fechaFin)
        {
            return await _repository.GetPromedio(tipoConsulta, fechaInicio, fechaFin);
        }
    }
}
