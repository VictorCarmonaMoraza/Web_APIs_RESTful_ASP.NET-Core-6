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
        [HttpGet]   //api/autores
        [HttpGet("listado")]    //api/autores/listado
        [HttpGet("/listado")] // desaparaece api/autores por --->listado
        public async Task<ActionResult<List<Autor>>> Get()
        {
            //Obtenemos el listado de autores de la base de datos
            return await context.Autores.Include(x => x.Libros).ToListAsync();
        }

        /// <summary>
        /// Metodo para devolver el primer autor de la tabla
        /// </summary>
        /// <returns></returns>
        [HttpGet("primero")] // api/autores/primero
        public async Task<ActionResult<Autor>> PrimerAutor()
        {
            return await context.Autores.FirstOrDefaultAsync();
        }

        //Asignarle un valor por defecto 
        //[HttpGet("{id:int}/{params2=persona}")]
        [HttpGet("{id:int}/{params2?}")]
        public async Task<ActionResult<Autor>> Get(int id, string params2)
        {
            var autor =  await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            //Comprobamos que autor no es nulo
            if(autor == null)
            {
                //Retornamos no encontrado
                return NotFound();
            }
            return autor;
        }

        /// <summary>
        /// Buscar un autor por su nombre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{nombre}")]
        public async Task<ActionResult<Autor>> Get(string nombre)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));

            //Comprobamos que autor no es nulo
            if (autor == null)
            {
                //Retornamos no encontrado
                return NotFound();
            }
            return autor;
        }

        /// <summary>
        /// Creacion de un autor
        /// </summary>
        /// <param name="autor">modelo de autor</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            //Creamos un autor en la base de datos
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Actualiza un autor por su id
        /// </summary>
        /// <param name="autor">modelo autor</param>
        /// <param name="id">id del autor a actualizar</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con el id de la URL");
            };

            //verificamos la existencia del autor en la base de datos
            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Borra un autor por  su id
        /// </summary>
        /// <param name="id">id del autor a borrar</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            //verificamos la existencia del autor en la base de datos
            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
