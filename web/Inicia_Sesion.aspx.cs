﻿using System;
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
                LResultado.Text = "Usuario o contraseña incorrectos";
            else
            {
                if(TPassword.Text != en.password)
                    LResultado.Text = "Usuario o contraseña incorrectos";
                else
                    LResultado.Text = "Se ha leído correctamente el usuario";
            }
        }
    }
}