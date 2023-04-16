using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class ENProductora
    {

        private int _Id;
        private string _Nombre;
        private string _Descripcion;
        private string _Imagen;
        private string _Web;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        public string Web
        {
            get { return _Web; }
            set { _Web = value; }
        }
    }
}
