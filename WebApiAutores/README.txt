## 29 - Tipos de Datos de Retorno de una accion

NOTA: CUANDO TRABAJEMOS CON BASE DE DATOS TENEMOS QUE TRABAJAR CON PROGRAMACION ASINCRONA
1-Tipo especifico

        [HttpGet]   //api/autores
        [HttpGet("listado")]    //api/autores/listado
        [HttpGet("/listado")] // desaparaece api/autores por --->listado
        public List<Autor> Get()
        {
            //Obtenemos el listado de autores de la base de datos
            return context.Autores.Include(x => x.Libros).ToList();
        }


2-Para este caso debemos deolver un ActionResult

        [HttpGet("{id:int}/{params2?}")]
        public Autor Get(int id, string params2)
        {
            var autor =  context.Autores.FirstOrDefault(x => x.Id == id);

            //Comprobamos que autor no es nulo
            if(autor == null)
            {
                //Retornamos no encontrado
                return NotFound();   ---->ESTO DARIA ERROR PORQUE NotFount HEREDA DE ActionResult
            }
            return autor;
        }

        -Cambiamos lo anterior por esto y no daria error

        [HttpGet("{id:int}/{params2?}")]
        public ActionResult<Autor> Get(int id, string params2)
        {
            var autor =  context.Autores.FirstOrDefaul(x => x.Id == id);

            //Comprobamos que autor no es nulo
            if(autor == null)
            {
                //Retornamos no encontrado
                return NotFound();
            }
            return autor;
        }


        IActionResult

        [HttpGet("{id:int}/{params2?}")]
        public IActionResult Get(int id, string params2)
        {
            var autor =  context.Autores.FirstOrDefaul(x => x.Id == id);

            //Comprobamos que autor no es nulo
            if(autor == null)
            {
                //Retornamos no encontrado
                return NotFound();
            }
            return Ok(autor);
        }