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
            data = en.mostrarReservas();
            reservasTable.DataSource = data;
            reservasTable.DataBind();
        }

        protected DataTable mostrarReservas()
        {
            ENReserva r = new ENReserva();
            return r.mostrarReservas();
        }
    }
}