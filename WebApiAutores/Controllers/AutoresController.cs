﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        /// <summary>
        /// Devolvemos un listado de Autores que estan creados en memoria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Autor>> Get()
        {
            return new List<Autor>()
            {
                new Autor()
                {
                    Id = 1,
                    Nombre = "Felipe"
                },
                new Autor()
                {
                    Id = 2,
                    Nombre = "Claudia"
                }
            };
        }
    }
}