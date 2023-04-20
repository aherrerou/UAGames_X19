using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENTema
    {
        private string titulo_interno;
        private int foroID_interno;
        public string titulo
        {
            get { return titulo_interno; }
            set { titulo_interno = value; }
        }
        public int foroID
        {
            get { return foroID_interno; }
            set { foroID_interno = value; }
        }
        public ENTema()
        {
            this.titulo = "blank";
            this.foroID = 0;
        }
        public bool createTema()
        {
            bool result = true;
            CADTema c = new CADTema();
            result = c.createTema(this);
            return result;
        }
        public bool readTema()
        {
            bool result = true;
            CADTema c = new CADTema();
            result = c.createTema(this);
            return result;
        }
        public bool readFirstTema()
        {
            bool result = true;
            CADTema c = new CADTema();
            result = c.readFirstTema(this);
            return result;
        }
        public bool readNextTema()
        {
            bool result = true;
            CADTema c = new CADTema();
            result = c.readFirstTema(this);
            return result;
        }
        public bool readPrevTema()
        {
            bool result = true;
            CADTema c = new CADTema();
            result = c.readFirstTema(this);
            return result;
        }
        public bool updateTema()
        {
            bool result = true;
            CADTema c = new CADTema();
            result = c.readFirstTema(this);
            return result;
        }
        public bool deleteTema()
        {
            bool result = true;
            CADTema c = new CADTema();
            result = c.readFirstTema(this);
            return result;
        }
    }
}
