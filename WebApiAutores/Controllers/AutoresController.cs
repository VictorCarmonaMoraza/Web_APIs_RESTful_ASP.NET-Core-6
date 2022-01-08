using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext context;

        //Constructor
        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }


        /// <summary>
        /// Devolvemos un listado de Autores que estan creados en memoria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            //Obtenemos el listado de autores de la base de datos
            return await context.Autores.ToListAsync();
        }

        /// <summary>
        /// Creacion de un autor
        /// </summary>
        /// <param name="autor">modelo de autor</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult>Post(Autor autor)
        {
            //Creamos un autor en la base de datos
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
