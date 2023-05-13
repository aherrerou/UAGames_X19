using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace library
{
    public class ENNoticia
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
        public ENNoticia()
        {
            id = -1;
            titulo = "";
            fecha_public = DateTime.Now;
            contenido = "";
            productoraID = -1;

        }

        public ENNoticia(int id, string titulo, DateTime fecha_public, string contenido, int productora)
        {
            this.id = id;
            this.titulo = titulo;
            this.fecha_public = fecha_public;
            this.contenido = contenido;
            this.productoraID = productora;
        }
        public bool createNoticia()
        {

            CADNoticia nuevaNoticia = new CADNoticia();
            bool creada = nuevaNoticia.readNoticia(this);
            return creada;
        }
        public bool readFirstNoticia()
        {
            CADNoticia user = new CADNoticia();
            bool read = user.readFirstNoticia(this);
            return read;
        }
        public bool readNextNoticia()
        {
            CADNoticia user = new CADNoticia();
            bool read = false;
            if (user.readNoticia(this))
                read = user.readNextNoticia(this);
            return read;
        }

        public bool readPrevNoticia()
        {
            CADNoticia user = new CADNoticia();
            bool read = user.readPrevNoticia(this);
            return read;
        }
        public bool updateNoticia()
        {
            CADNoticia prod = new CADNoticia();
            bool updated = prod.updateNoticia(this);
            return updated;
        }
        public bool deleteNoticia()
        {
            CADNoticia prod = new CADNoticia();
            bool deleted = prod.deleteNoticia(this);
            return deleted;
        }
        public DataSet readNoticia()
        {
            DataSet result = new DataSet();
            CADNoticia c = new CADNoticia();
            result = c.readNoticia();
            return result;
        }
    }
}


    


