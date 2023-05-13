using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProductora
    {

        private int id;
        private string nombre;
        private string descripcion;
        private string imagen;
        private string web;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public string Web
        {
            get { return web; }
            set { web = value; }
        }

        public ENProductora()
        {
            id = -1;
            nombre = "";
            descripcion = "";
            imagen = "";
            web = "";
        }
        public ENProductora(int id, string nombre, string descripcion, string imagen, string web)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Imagen = imagen;
            Web = web;
        }
        public bool createProductora()
        {
            bool creada = true;
            CADProductora nuevaProductora = new CADProductora();
           creada = nuevaProductora.createProductora(this);
            return creada;
        }
        public bool readFirstProductora()
        {
            CADProductora user = new CADProductora();
            bool read = user.readFirstProductora(this);
            return read;
        }

        public bool readNextProductora()
        {
            CADProductora user = new CADProductora();
            bool read = false;
            if (user.readProductora(this))
                read = user.readNextProductora(this);
            return read;
        }

        public bool readPrevProductora()
        {
            CADProductora user = new CADProductora();
            bool read = user.readPrevProductora(this);
            return read;
        }
        public bool updateProductora()
        {
            CADProductora prod = new CADProductora();
            bool updated = prod.updateProductora(this);
            return updated;
        }
        public bool deleteProductora()
        {
            CADProductora prod = new CADProductora();
            bool deleted = prod.deleteProductora(this);
            return deleted;
        }

        public DataTable readProductorasNombre()
        {
            CADProductora productora = new CADProductora();
            return productora.readProductorasNombre();
        }
    }
}

