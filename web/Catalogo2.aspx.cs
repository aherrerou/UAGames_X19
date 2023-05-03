using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace web
{
    public partial class Catalogo2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ENVideojuego videojuego = new ENVideojuego();
                VideojuegosListView.DataSource = videojuego.readVideojuegos();
                VideojuegosListView.DataBind();
            }
        }

    }
}