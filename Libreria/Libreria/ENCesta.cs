using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class ENCesta
    {
        private int UsuarioID;
        private int VideojuegoID;
        private DateTime Fecha;

        // Constructor
        public ENCesta(int usuarioID, int videojuegoID, DateTime fecha)
        {
            DateTime fechaActual = DateTime.Now;

            UsuarioID = -1;
            VideojuegoID = -1;
            Fecha = fechaActual;
        }

        // Métodos
        public bool createCesta()
        {
            bool res = true;
            CADCesta ces = new CADCesta();
            res = ces.createCesta(this);
            return res;
        }

        public bool readForo()
        {
            bool res = true;
            CADCesta ces = new CADCesta();
            res = ces.readCesta(this);
            return res;
        }

        public bool readFirstCesta()
        {
            bool res = true;
            CADCesta ces = new CADCesta();
            res = ces.readFirstCesta(this);
            return res;
        }

        public bool readNextCesta()
        {
            bool res = true;
            CADCesta ces = new CADCesta();
            res = ces.readNextCesta(this);
            return res;
        }

        public bool readPrevCesta()
        {
            bool res = true;
            CADCesta ces = new CADCesta();
            res = ces.readPrevCesta(this);
            return res;
        }

        public bool updateCesta()
        {
            bool res = true;
            CADCesta ces = new CADCesta();
            res = ces.updateCesta(this);
            return res;
        }

        public bool deleteCesta()
        {
            bool res = true;
            CADCesta ces = new CADCesta();
            res = ces.deleteCesta(this);
            return res;
        }
    }
}
