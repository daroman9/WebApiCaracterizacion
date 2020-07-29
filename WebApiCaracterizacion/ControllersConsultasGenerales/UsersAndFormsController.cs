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
    public class UsersAndFormsController : ControllerBase
    {
        private readonly UsersAndFormsRepostitory _repository;

        public UsersAndFormsController(UsersAndFormsRepostitory repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersAndForms>>> GetData([FromQuery]string documento)
        {
            return await _repository.GetData(documento);
        }
    }
}