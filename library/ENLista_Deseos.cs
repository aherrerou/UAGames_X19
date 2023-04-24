﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENLista_Deseos
    {
        private int id_interno;
        private string nombre_interno, descripcion_interno;
        private ENUsuario usuario_interno;
        public int id
        {
            get { return id_interno; }
            set { id_interno = value; }
        }
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
        public ENUsuario usuario
        {
            get { return usuario_interno; }
            set { usuario_interno = value; }
        }
        public ENLista_Deseos()
        {
            this.id = 0;
            this.nombre = "blank";
            this.descripcion = "blank";
            this.usuario = new ENUsuario();
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
