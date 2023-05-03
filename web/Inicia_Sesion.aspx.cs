using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace web
{
    public partial class Inicia_Sesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Leer(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario(0, TNick.Text, "blank", "blank", "blank", TPassword.Text, System.DateTime.Now, "blank", "blank");
            bool result = en.readUsuario();
            if (result == false)
                LResultado.Text = "Error en la lectura del usuario";
            else
            {
                LResultado.Text = "Proceso de lectura realizado con éxito";
            }
        }
    }
}