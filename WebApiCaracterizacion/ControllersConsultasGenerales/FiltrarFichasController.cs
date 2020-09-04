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
    public class FiltrarFichasController : ControllerBase
    {
        private readonly FiltrarFichasRepository _repository;

        public FiltrarFichasController(FiltrarFichasRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FiltrarFichas>>> GetData([FromQuery]int rol, string idUser, string tipoFiltro,string aspecto,
            string codigo, string fechaInicio, string fechaFin, string email)
        {
            return await _repository.GetPromedio(rol, idUser, tipoFiltro, aspecto,
            codigo, fechaInicio, fechaFin, email);
        }
    }
}