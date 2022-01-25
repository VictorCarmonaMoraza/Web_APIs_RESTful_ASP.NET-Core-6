using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAutores.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //Propiedad de navegacion para cargar los libros de un autor
        public List<Libro> Libros { get; set; }
    }
}
