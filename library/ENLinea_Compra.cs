using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library { 

    public class ENLinea_Compra
    {
        public ENCabecera_Compra cabecera { get; set; }
        public ENVideojuego videojuego { get; set; }
        public int id { get; set; }
        public int cantidad { get; set; }
        public double importe { get; set; }
        private CADLinea_Compra linea { get; set; }
        public ENLinea_Compra()
        {
            this.id = 1;
            this.cantidad = 1;
            this.importe = 100;
            this.linea = new CADLinea_Compra();
            this.videojuego = new ENVideojuego();
            this.cabecera = new ENCabecera_Compra();
        }
        public bool createLinea_Compra()
        {
            //Pruebas
            //this.videojuego.id = 1;
            //this.cabecera.id = 4;
            //
            return this.linea.createLinea(this);
        }
        public bool deleteLinea_Compra()
        {
            //Pruebas
            //this.id = 2;
            //
            return this.linea.deleteLinea(this);
        }
        public bool updateLinea_Compra()
        {
            //Pruebas
            //this.id = 3;
            //this.videojuego.id = 2;
            //
            return this.linea.updateLinea(this,videojuego);
        }
        public bool readLinea_Compra()
        {
            //Pruebas
            //this.id = 3;
            //this.videojuego.id = 2;
            //
            return this.linea.readLinea(this, videojuego);
        }

    }
}
