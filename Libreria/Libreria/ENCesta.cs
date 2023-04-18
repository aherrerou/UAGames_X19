using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class ENCesta
    {
        public int UsuarioID { get; set; } 
        public int VideojuegoID { get; set; }
        public DateTime Fecha { get; set; }

        // Constructor
        public ENCesta(int usuarioID, int videojuegoID, DateTime fecha)
        {
            DateTime fechaActual = DateTime.Now;

            UsuarioID = -1;
            VideojuegoID = -1;
            Fecha = fechaActual;
        }

        // Métodos
        public void AgregarVideojuego(int videojuegoID)
        {
            // Lógica para agregar un videojuego a la cesta
        }

        public void RemoverVideojuego(int videojuegoID)
        {
            // Lógica para remover un videojuego de la cesta
        }

        public void VaciarCesta()
        {
            // Lógica para vaciar la cesta
        }
    }
}
