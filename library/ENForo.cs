using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENForo
    {
        private string nombre_interno;
        private int id_interno;
        public string nombre
        {
            get { return nombre_interno; }
            set { nombre_interno = value; }
        }
        public int id
        {
            get { return id_interno; }
            set { id_interno = value; }
        }
        public ENForo()
        {
            this.nombre = "blank";
        }
        public bool createForo()
        {
            bool result = true;
            CADForo c = new CADForo();
            result = c.createForo(this);
            return result;
        }
        public bool readForo()
        {
            bool result = true;
            CADForo c = new CADForo();
            result = c.readForo(this);
            return result;
        }
        public bool readFirstForo()
        {
            bool result = true;
            CADForo c = new CADForo();
            result = c.readFirstForo(this);
            return result;
        }
        public bool readNextForo()
        {
            bool result = true;
            CADForo c = new CADForo();
            result = c.readNextForo(this);
            return result;
        }
        public bool readPrevForo()
        {
            bool result = true;
            CADForo c = new CADForo();
            result = c.readPrevForo(this);
            return result;
        }
        public bool updateForo()
        {
            bool result = true;
            CADForo c = new CADForo();
            result = c.updateForo(this);
            return result;
        }
        public bool deleteForo()
        {
            bool result = true;
            CADForo c = new CADForo();
            result = c.deleteForo(this);
            return result;
        }
    }
}
