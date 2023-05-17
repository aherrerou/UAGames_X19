using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    //Codigo Omar

    public class ENReserva
    {
        public ENUsuario usuario { get; set; }
        public ENVideojuego videoJuego { get; set; }
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fechaEntrega { get; set; }
        public double pagado;
        private CADReserva Reserva { get; set; }

        public ENReserva()
        {
            this.id = 0;
            this.usuario = new ENUsuario();
            this.videoJuego = new ENVideojuego();
            this.fecha = DateTime.Now;
            this.fechaEntrega = DateTime.Now;
            this.pagado = 0;
            this.Reserva = new CADReserva();
        }

        public bool createReserva()
        {
            return this.Reserva.createReserva(this, usuario, videoJuego);
        }
        public bool deleteReserva()
        {
            return this.Reserva.deleteReserva(this);
        }
        public bool updateReserva()
        {
            return this.Reserva.updateReserva(this);
        }
        public bool readReserva()
        {
            return this.Reserva.readReserva(this);
        }
    }

}
