using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace web
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Crear(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario(0, TNick.Text, TNombre.Text, TApellidos.Text, TEmail.Text, TPassword.Text, System.DateTime.Now, TTelefono.Text, "blank");
            bool result = en.createUsuario();
            if (result == false)
                LResultado.Text = "Error en la creación del usuario";
            else
                LResultado.Text = "Proceso de creación realizado con éxito";
        }
    }
}