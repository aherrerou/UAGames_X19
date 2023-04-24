using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENPublicacion
    {
        private int id_interno;
        private string text_interno;
        private ENTema tema_interno;
        private ENUsuario usuario_interno;
        public int id
        {
            get { return id_interno; }
            set { id_interno = value; }
        }
        public string text
        {
            get { return text_interno; }
            set { text_interno = value; }
        }
        public ENTema tema
        {
            get { return tema_interno; }
            set { tema_interno = value; }
        }
        public ENUsuario usuario
        {
            get { return usuario_interno; }
            set { usuario_interno = value; }
        }
        public ENPublicacion()
        {
            this.id = 0;
            this.text = "blank";
            this.tema = new ENTema();
            this.usuario = new ENUsuario();
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
