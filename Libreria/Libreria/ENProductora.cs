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
           
            CADProductora nuevaProductora = new CADProductora();
            bool creada = nuevaProductora.readProductora(this);
            return creada;
        }
        public bool readFirstUsuario()
        {
            CADProductora user = new CADProductora();
            bool read = user.readFirstProductora(this);
            return read;
        }

        public bool readNextUsuario()
        {
            CADProductora user = new CADProductora();
            bool read = false;
            if (user.readProductora(this))
                read = user.readNextProductora(this);
            return read;
        }

        public bool readPrevUsuario()
        {
            CADProductora user = new CADProductora();
            bool read = user.readPrevProductora(this);
            return read;
        }

    }
}
