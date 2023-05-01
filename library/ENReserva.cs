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
        public ENVideoJuego videoJuego { get; set; }
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fechaEntrega { get; set; }
        public double pagado;
        private CADReserva Reserva { get; set; }

        public ENReserva()
        {
            this.usuario = new ENUsuario();
            this.videoJuego = new ENVideoJuego();
            this.fecha = DateTime.Now;
            this.puntuacion = 0;
            this.comentario = "";
            this.Reserva = new CADReserva();
        }

        public bool createReserva()
        {
            return this.Reserva.createReserva(this, usuario, videoJuego);
        }
        public bool deleteReserva()
        {
            //Para prueba
            //this.id = 4;
            //
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
