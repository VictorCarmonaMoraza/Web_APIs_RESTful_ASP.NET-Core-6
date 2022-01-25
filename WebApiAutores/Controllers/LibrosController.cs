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
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtenemos un libro por su id
        /// </summary>
        /// <param name="id">id del libro a obtener</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            return await context.Libros.Include(x=>x.Autor).FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult>Post(Libro libro)
        {
            //Verificamos que el autor exista
            var existeAutor = await context.Autores.AnyAsync(x => x.Id == libro.AutorId);

            //Si no existe el autor
            if (!existeAutor)
            {
                return BadRequest($"No existe el autor de Id: {libro.AutorId}");
            }
            //Añadimos el libro
            context.Add(libro);
            //Guardamos los cambios
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
