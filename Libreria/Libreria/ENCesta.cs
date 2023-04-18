using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class ENCesta
    {
        public ENUsuario usuario { get; set; }
        public ENVideojuego videojuego { get; set; }
        public DateTime Fecha { get; set; }
        private CADCesta ces { get; set; }

        // Constructor
        public ENCesta()
        {
            DateTime fechaActual = DateTime.Now;

            this.videojuego = new ENVideojuego();
            this.usuario= new ENUsuario();
            Fecha = fechaActual;
            this.ces = new CADCesta(); 
        }

        // Métodos
        public bool createCesta()
        {
            bool res = true;
            res = ces.createCesta(this);
            return res;
        }

        public bool readCesta()
        {
            bool res = true;
            res = ces.readCesta(this);
            return res;
        }

        public bool readFirstCesta()
        {
            bool res = true;
            res = ces.readFirstCesta(this);
            return res;
        }

        public bool readNextCesta()
        {
            bool res = true;
            res = ces.readNextCesta(this);
            return res;
        }

        public bool readPrevCesta()
        {
            bool res = true;
            res = ces.readPrevCesta(this);
            return res;
        }

        public bool updateCesta()
        {
            bool res = true;
            res = ces.updateCesta(this);
            return res;
        }

        public bool deleteCesta()
        {
            bool res = true;
            res = ces.deleteCesta(this);
            return res;
        }
    }
}
