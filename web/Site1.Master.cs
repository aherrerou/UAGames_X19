using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login_nick"] == null)
            {
                MenuNoSesion.Visible = true;
                MenuSesion.Visible = false;
            }
            else
            {
                MenuNoSesion.Visible = false;
                MenuSesion.Visible = true;
            }
        }

        protected void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicia_Sesion.aspx");
        }

        protected void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrar.aspx");
        }

        protected void clickCart(object sender, EventArgs e)
        {
            Response.Redirect("Registrar.aspx");
        }
        protected void clickLista(object sender, EventArgs e)
        {
            Response.Redirect("Lista_Deseos.aspx");
        }

        protected void clickLogOut(object sender, EventArgs e)
        {
            Session["login_nick"] = null;
            Response.Redirect("Inicio.aspx");
        }
    }
}