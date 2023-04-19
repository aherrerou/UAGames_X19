using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENOferta
    {
        //Identificador del oferta
        private int _Id;

        //Nombre del oferta
        private string _Nombre;

        //Descuento del oferta
        private double _Descuento;

        //Fecha de inicio del oferta
        private DateTime _FechaInicio;
        //Fecha de fin del oferta
        private DateTime _FechaFin;

        //Productora responsable de la oferta
        private ENProductora _Productora;
        //Videojuego de la oferta
        private ENVideojuego _Videojuego;

        //Propiedades
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }
        
        public double Descuento
        {
            get { return _Descuento; }
            set { _Descuento = value; }
        }
        public ENProductora Productora
        {
            get { return _Productora; }
            set { _Productora = value; }
        }
        public ENVideojuego Videojuego
        {
            get { return _Videojuego; }
            set { _Videojuego = value; }
        }

        //Constructor por defecto
        public ENOferta()
        {
            Id = 0;
            FechaInicio = DateTime.UtcNow;
            FechaFin = DateTime.UtcNow;
            Descuento = 0.0;
            Productora = new ENProductora();
            Videojuego = new ENVideojuego();
        }

        //Constructor con parametros
        public ENOferta(int id, DateTime fechaInicio, DateTime fechaFin, double descuento, ENProductora productora, ENVideojuego videojuego)
        {
            Id = id;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Descuento = descuento;
            Productora = productora;
            Videojuego = videojuego;
        }

        public bool addoferta()
        {
            CADOferta cad = new CADOferta();
            return cad.addOferta(this);

        }

        public bool readoferta()
        {
            CADOferta cad = new CADOferta();
            return cad.readOferta(this);
        }

        public bool readofertas(List<ENOferta> listaofertas)
        {
            CADOferta cad = new CADOferta();
            return cad.readOfertas(listaofertas);
        }

        public bool readofertasProductora(List<ENOferta> listaofertas, string productora)
        {
            CADOferta cad = new CADOferta();
            return cad.readOfertasProductora(listaofertas, productora);
        }

        public bool actualizaroferta()
        {
            bool actualizado = false;
            CADOferta cad = new CADOferta();
            ENOferta aux = new ENOferta();

            aux.Id = this.Id;
            aux.FechaInicio = this.FechaInicio;
            aux.FechaFin = this.FechaFin;
            aux.Descuento = this.Descuento;
            aux.Productora = this.Productora;
            aux.Videojuego = this.Videojuego;

            if (cad.readOferta(this))
            {
                actualizado = cad.updateOferta(aux);
                this.FechaInicio = aux.FechaInicio;
                this.FechaFin = aux.FechaFin;
                this.Descuento = aux.Descuento;
                this.Productora = aux.Productora;
                this.Videojuego = aux.Videojuego;
            }

            return actualizado;
        }

        public bool eliminarOferta()
        {
            bool eliminado = false;
            CADOferta cad = new CADOferta();

            if (cad.readOferta(this))
            {
                eliminado = cad.deleteOferta(this);
            }

            return eliminado;
        }
    }
}
