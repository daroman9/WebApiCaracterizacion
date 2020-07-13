using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCaracterizacion.DataConsultasGenerales;
using WebApiCaracterizacion.ModelsConsultasGenerales;

namespace WebApiCaracterizacion.ControllersConsultasGenerales
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltrarRegistrosExcelController : ControllerBase
    {
        private readonly FiltrarRegistrosExcelRepository _repository;

        public FiltrarRegistrosExcelController(FiltrarRegistrosExcelRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FiltrarRegistrosExcel>>> GetData([FromQuery]string tipoFiltro, string aspecto,
            string codigo, string fechaInicio, string fechaFin, string email)
        {
            return await _repository.GetPromedio(tipoFiltro, aspecto,
            codigo, fechaInicio, fechaFin, email);
        }
    }
}