using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCategoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion{ get; set; }

        private CADCategoria categoria;

        // Constructor
        public ENCategoria()
        {

            this.id = 1;
            this.nombre = "";
            this.descripcion = "";

            this.categoria = new CADCategoria();
        }

        // Métodos
        public bool createCategoria()
        {
            bool res = true;
            res = categoria.createCategoria(this);
            return res;
        }

        public bool readCategoria()
        {
            bool res = true;
            res = categoria.readCategoria(this);
            return res;
        }

        public bool updateCategoria()
        {
            bool res = true;
            res = categoria.updateCategoria(this);
            return res;
        }

        public bool deleteCategoria()
        {
            bool res = true;
            res = categoria.deleteCategoria(this);
            return res;
        }

        public DataTable readCategoriasNombre()
        {
            CADCategoria categoria = new CADCategoria();
            return categoria.readCategoriasNombre();
        }
    }
}
