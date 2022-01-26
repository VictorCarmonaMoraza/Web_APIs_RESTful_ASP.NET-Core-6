## 28 - Variables de Ruta

1-Asignamos valor por defecto al params2 con persona

        [HttpGet("{id:int}/{params2=persona}")]

2-Hacemos opcional el campo params2

        [HttpGet("{id:int}/{params2?}")]

3-Restringir que parametro que nos pasen sea de tipo entero

        [HttpGet("{id:int}")]  --->El valor que entre solo podra ser de tipo entero

        [HttpGet("{id:string}")] --->Esto daria error porque no existe

