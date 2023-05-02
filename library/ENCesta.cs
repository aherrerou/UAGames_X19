﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCesta
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
            res = ces.createCesta(this,videojuego,usuario);
            return res;
        }

        public bool readCesta()
        {
            bool res = true;
            res = ces.readCesta(this,usuario);
            return res;
        }

        public bool updateCesta()
        {
            bool res = true;
            res = ces.updateCesta(this,usuario,videojuego);
            return res;
        }

        public bool deleteCesta()
        {
            bool res = true;
            res = ces.deleteCesta(this,usuario);
            return res;
        }
    }
}