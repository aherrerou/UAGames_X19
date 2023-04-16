using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENVideojuego
    {
        //Identificador del videojuego
        private int _Id;
        //Titulo del videojuego
        private string _Titulo;
        //Descripcion del videojuego
        private string _Descripcion;
        //Fecha de lanzamiento del videojuego
        private DateTime _FechaLanzamiento;
        //Plataforma del videojuego
        private string _Plataforma;
        //Precio del videojuego
        private double _Precio;
        //Imagen del videojuego
        private string _Imagen;
        //Productora responsable del videojuego
        private ENProductora _Productora;
        //Categoria del videojuego
        private ENCategoria _Categoria;

        //Propiedades
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public DateTime FechaLanzamiento
        {
            get { return _FechaLanzamiento; }
            set { _FechaLanzamiento = value; }
        }
        public string Plataforma
        {
            get { return _Plataforma; }
            set { _Plataforma = value; }
        }
        public string Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }
        public double Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        public ENProductora Productora
        {
            get { return _Productora; }
            set { _Productora = value; }
        }
        public ENCategoria Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }

        //Constructor por defecto
        public ENVideojuego()
        {
                Id = 0;
                Titulo = "";
                Descripcion = "";
                FechaLanzamiento = new DateTime();
                Plataforma = "";
                Imagen = "";
                Precio = 0.0;
                Productora = new ENProductora();
                Categoria = new ENCategoria();
        }

        //Constructor con parametros
        public ENVideojuego(int id, String titulo, String descripcion, DateTime fecha, String plataforma, String imagen, double precio, ENProductora productora, ENCategoria categoria)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = descripcion;
            FechaLanzamiento = fecha;
            Plataforma = plataforma;
            Imagen = imagen;
            Precio = precio;
            Productora = productora;
            Categoria = categoria;
        }

        public bool addVideojuego()
        {
            CADVideojuego cad = new CADVideojuego();
            return cad.addVideojuego(this);

        }

        public bool readVideojuego()
        {
            CADVideojuego cad = new CADVideojuego();
            return cad.readVideojuego(this);
        }

        public bool readVideojuegos(List<ENVideojuego> listaVideojuegos)
        {
            CADVideojuego cad = new CADVideojuego();
            return cad.readVideojuegos(listaVideojuegos);
        }

        public bool readVideojuegosProductora(List<ENVideojuego> listaVideojuegos, string productora)
        {
            CADVideojuego cad = new CADVideojuego();
            return cad.readVideojuegosProductora(listaVideojuegos, productora);
        }

        public bool readVideojuegosCategoria(List<ENVideojuego> listaVideojuegos, string categoria)
        {
            CADVideojuego cad = new CADVideojuego();
            return cad.readVideojuegosCategoria(listaVideojuegos, categoria);
        }

        public bool actualizarVideojuego()
        {
            bool actualizado = false;
            CADVideojuego cad = new CADVideojuego();
            ENVideojuego aux = new ENVideojuego();

            aux.Id = this.Id;
            aux.Titulo = this.Titulo;
            aux.Descripcion = this.Descripcion;
            aux.FechaLanzamiento = this.FechaLanzamiento;
            aux.Plataforma = this.Plataforma;
            aux.Imagen = this.Imagen;
            aux.Precio = this.Precio;
            aux.Productora = this.Productora;
            aux.Categoria = this.Categoria;

            if (cad.readVideojuego(this))
            {
                actualizado = cad.updateVideojuego(aux);
                this.Titulo = aux.Titulo;
                this.Descripcion = aux.Descripcion;
                this.FechaLanzamiento = aux.FechaLanzamiento;
                this.Plataforma = aux.Plataforma;
                this.Imagen = aux.Imagen;
                this.Precio = aux.Precio;
                this.Productora = aux.Productora;
                this.Categoria = aux.Categoria;
            }

            return actualizado;
        }

        public bool eliminarVideojuego()
        {
            bool eliminado = false;
            CADVideojuego cad = new CADVideojuego();

            if (cad.readVideojuego(this))
            {
                eliminado = cad.deleteVideojuego(this);
            }

            return eliminado;
        }




    }
}
