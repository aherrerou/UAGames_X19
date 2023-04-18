using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class ENProductora
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Web { get; set; }
        public ENProductora()
        {
            Id = -1;
            Nombre = "";
            Descripcion = "";
            Imagen = "";
            Web = "";
        }
        public ENProductora(int id,string nombre , string descripcion,string imagen ,string web)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Imagen = imagen;
            Web = web;
        }
        public bool createProductora()
        {
            bool creada = false;
            CADProductora nuevaProductora = new CADProductora();

            return creada;
        }
    }
}
