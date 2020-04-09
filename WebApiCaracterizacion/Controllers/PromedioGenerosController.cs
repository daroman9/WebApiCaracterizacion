﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCaracterizacion.Data;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromedioGenerosController : ControllerBase
    {
        private readonly PromedioGenerosRepository _repository;

        public PromedioGenerosController(PromedioGenerosRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // Petición http para traer el promedio de generos de agricultura
        [HttpGet("agricultura")]
        public async Task<ActionResult<IEnumerable<PromediosGeneros>>> GetAgro()
        {
            return await _repository.GetPromedioAgricultura();
        }

        // Petición http para traer el promedio de generos de agricultura
        [HttpGet("ganaderia")]
        public async Task<ActionResult<IEnumerable<PromediosGeneros>>> GetGanaderia()
        {
            return await _repository.GetPromedioGanaderia();
        }
    }
}
