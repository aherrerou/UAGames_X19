using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using library;

namespace web
{
    public partial class Reserva : System.Web.UI.Page
    {
        DataTable data = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ENReserva en = new ENReserva();
            //ENUsuario u = new ENUsuario();
            //u.nick = "omar";
            //u.readUsuario();

            //ENVideojuego v = new ENVideojuego();
            //v.Id = 1;
            //v.readVideojuegoId();
            //en.usuario = u;
            //en.videojuego = v;
            //en.pagado = 30.0;
            //en.createReserva();
            data = en.mostrarReservas();
            reservasTable.DataSource = data;
            reservasTable.DataBind();
        }

        protected DataTable mostrarReservas()
        {
            ENReserva r = new ENReserva();
            return r.mostrarReservas();
        }

        protected void Editar_click(object sender, GridViewEditEventArgs e)
        {
            reservasTable.EditIndex = e.NewEditIndex;
        }

        protected void Cancelar_click(object sender, GridViewEditEventArgs e)
        {
            reservasTable.EditIndex = e.NewEditIndex;
        }

        protected void Cambiar_click(object sender, GridViewEditEventArgs e)
        {
            reservasTable.EditIndex = e.NewEditIndex;
        }

        protected void Borrar_click(object sender, GridViewEditEventArgs e)
        {
            reservasTable.EditIndex = e.NewEditIndex;
        }

    }
}
