using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class ENPublicacion
    {
        private string text_interno;
        private int temaID_interno, usuarioID_interno;
        public string text
        {
            get { return text_interno; }
            set { text_interno = value; }
        }
        public int temaID
        {
            get { return temaID_interno; }
            set { temaID_interno = value; }
        }
        public int usuarioID
        {
            get { return usuarioID_interno; }
            set { usuarioID_interno = value; }
        }
        public ENPublicacion()
        {
            this.text = "blank";
            this.temaID = 0;
            this.usuarioID = 0;
        }
        public bool createPublicacion()
        {
            bool result = true;
            CADPublicacion c = new CADPublicacion();
            result = c.createPublicacion(this);
            return result;
        }
        public bool readPublicacion()
        {
            bool result = true;
            CADPublicacion c = new CADPublicacion();
            result = c.createPublicacion(this);
            return result;
        }
        public bool readFirstPublicacion()
        {
            bool result = true;
            CADPublicacion c = new CADPublicacion();
            result = c.readFirstPublicacion(this);
            return result;
        }
        public bool readNextPublicacion()
        {
            bool result = true;
            CADPublicacion c = new CADPublicacion();
            result = c.readFirstPublicacion(this);
            return result;
        }
        public bool readPrevPublicacion()
        {
            bool result = true;
            CADPublicacion c = new CADPublicacion();
            result = c.readFirstPublicacion(this);
            return result;
        }
        public bool updatePublicacion()
        {
            bool result = true;
            CADPublicacion c = new CADPublicacion();
            result = c.readFirstPublicacion(this);
            return result;
        }
        public bool deletePublicacion()
        {
            bool result = true;
            CADPublicacion c = new CADPublicacion();
            result = c.readFirstPublicacion(this);
            return result;
        }
    }
}
