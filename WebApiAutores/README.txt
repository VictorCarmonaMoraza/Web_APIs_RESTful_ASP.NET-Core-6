## 30- Programacion Asincrona

Es recomendable usarla cuando trabajamos con bases de datos.

-Cuando ejecutamos una funcion asincrona, nuestro servidor Web se pone a hacer otras tareas
mientras la funcion se ejecuta.

-No siempre hay que usar programacion asincrona

-Debemos utilizar programacion asincrona cuando realizamos operacion I/O

-Ejemplos: Llamadas a Web APIs, leer archivos en una PC, realizar operaciones con bases de datos.

Para marcar una funcion asincrona se marca con async.
Con await hacemos una espera asincrona de la operacion.
Debemos retornar Task en los metodos asincronos.


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


        Task vs Task<T>

        Task es para no retornar un valor al final de la ejecucion de la funcion asincrona.

        Task<T> es para retornar el tipo de T en el futuro  --> Task<ActionResult<Autor>>