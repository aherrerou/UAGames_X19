using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class ENNoticia
    {
        private int id;
        private string titulo;
        private DateTime fecha_public;
        private string contenido;
        private int productoraID;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public DateTime FechaPublicacion
        {
            get { return fecha_public; }
            set { fecha_public = value; }
        }

        public string Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }
        public int ProductoraID
        {
            get { return productoraID; }
            set { productoraID = value; }
        }
        public ENNoticia(int id, string titulo, DateTime fecha_public, string contenido, int productora)
        {
            this.id = id;
            this.titulo = titulo;
            this.fecha_public = fecha_public;
            this.contenido = contenido;
            this.productoraID = productora;
        }
        public override string ToString()
        {
            return string.Format("Noticia {0}: {1}\nFecha de publicación: {2}\nContenido: {3}\nProductora: {4}",
                id, titulo, fecha_public.ToString("dd/MM/yyyy"), contenido, productoraID);
        }

    }
}

