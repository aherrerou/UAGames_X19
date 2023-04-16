using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENUsuario
    {
        public int id;
        public String nombre;
        public ENUsuario()
        {
            this.id = 1;
            this.nombre = "Adrian Herrero";
        }
    }
    public class ENCabecera_Compra 
    {
        public ENUsuario usuario { get; set; }
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public double totalCompra { get; set; }
        private CADCabecera_Compra cabecera { get; set; }

        public ENCabecera_Compra()
        {
            this.usuario = new ENUsuario();
            this.fecha = DateTime.Now;
            this.cabecera = new CADCabecera_Compra();
        }
        public bool createCabecera_Compra()
        {
            return this.cabecera.createCabecera(this, usuario);
        }
        public bool deleteCabecera_Compra()
        {
            //Para prueba
            //this.id = 4;
            //
            return this.cabecera.deleteCabecera(this);
        }
        public bool updateCabecera_Compra()
        {
            //Para prueba
            this.id = 4;
            this.totalCompra = 10;
            //
            return this.cabecera.updateCabecera(this);
        }
        public bool readCabecera_Compra()
        {
            //Para prueba
            this.id = 4;
            //
            return this.cabecera.readCabecera(this);
        }
    }

}
