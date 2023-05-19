﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCesta
    {
        private ENUsuario usuario;
        private ENVideojuego videojuego;
        private DateTime fecha_interna;

        public ENUsuario usuarioID
        {

            get { return usuario; }
            set { usuario= value; }
        }

        public ENVideojuego videojuegoID
        {

            get { return videojuego; }
            set { videojuego = value; }
        }

        public DateTime fecha
        {

            get { return fecha_interna; }
            set { fecha_interna = value; }
        }

        // Constructor
        public ENCesta()
        {
            videojuegoID = new ENVideojuego();
            usuarioID = new ENUsuario();
            fecha = DateTime.UtcNow;
        }

        public ENCesta(ENUsuario usu, ENVideojuego videojuego, DateTime Fecha)
        {
            usuarioID = usu;
            videojuegoID = videojuego;
            fecha = Fecha;
        }

        // Métodos
        public bool createCesta()
        {
            bool res = true;
            CADCesta ces = new CADCesta();
            res = ces.createCesta(this,videojuego,usuario);
            return res;
        }

        public bool readCesta()
        {
            bool res = true;
            CADCesta ces = new CADCesta();
            res = ces.readCesta(this);
            return res;
        }

        public DataTable readCestas()
        {
            CADCesta cesta = new CADCesta();
            return cesta.readCestas();
        }

        public bool updateCesta()
        {
            bool res = true;
            CADCesta ces = new CADCesta();
            res = ces.updateCesta(this,usuario,videojuego);
            return res;
        }

        public bool deleteCesta()
        {
            /*bool res = true;
            CADCesta ces = new CADCesta();
            res = ces.deleteCesta(this,usuario);
            return res;*/
            return true;
        }
        public int articulosCesta(ENUsuario usuario)
        {
            CADCesta cesta = new CADCesta();
            return cesta.articulosCesta(usuario);
        }
    }
}
