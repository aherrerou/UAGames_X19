using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class ENCategoria
    {

        //Identificador del categoria
        private int _Id;
        //Titulo del categoria
        private string _Nombre;
        //Descripcion del categoria
        private string _Descripcion;

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

    }
}
