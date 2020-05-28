using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCaracterizacion.DataMineria;
using WebApiCaracterizacion.ModelsMineria;

namespace WebApiCaracterizacion.ControllersMineria
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromedioProduccionOroORController : ControllerBase
    {
        private readonly PromedioProduccionORRepository _repository;

        public PromedioProduccionOroORController(PromedioProduccionORRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PromediosProduccionOroOR>>> GetData()
        {
            return await _repository.GetPromedio();
        }
    }
}