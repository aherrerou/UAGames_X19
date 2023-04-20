using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENLista_Deseos
    {
        private string nombre_interno, descripcion_interno;
        private int usuarioID_interno;
        public string nombre
        {
            get { return nombre_interno; }
            set { nombre_interno = value; }
        }
        public string descripcion
        {
            get { return descripcion_interno; }
            set { descripcion_interno = value; }
        }
        public int usuarioID
        {
            get { return usuarioID_interno; }
            set { usuarioID_interno = value; }
        }
        public ENLista_Deseos()
        {
            this.nombre = "blank";
            this.descripcion = "blnak";
            this.usuarioID = 0;
        }
        public bool createLista()
        {
            bool result = true;
            CADLista_Deseos c = new CADLista_Deseos();
            result = c.createLista(this);
            return result;
        }
        public bool readLista()
        {
            bool result = true;
            CADLista_Deseos c = new CADLista_Deseos();
            result = c.readLista(this);
            return result;
        }
        public bool readFirstLista()
        {
            bool result = true;
            CADLista_Deseos c = new CADLista_Deseos();
            result = c.readFirstLista(this);
            return result;
        }
        public bool readNextLista()
        {
            bool result = true;
            CADLista_Deseos c = new CADLista_Deseos();
            result = c.readNextLista(this);
            return result;
        }
        public bool readPrevLista()
        {
            bool result = true;
            CADLista_Deseos c = new CADLista_Deseos();
            result = c.readNextLista(this);
            return result;
        }
        public bool updateLista()
        {
            bool result = true;
            CADLista_Deseos c = new CADLista_Deseos();
            result = c.updateLista(this);
            return result;
        }
        public bool deleteLista()
        {
            bool result = true;
            CADLista_Deseos c = new CADLista_Deseos();
            result = c.deleteLista(this);
            return result;
        }
    }
}
