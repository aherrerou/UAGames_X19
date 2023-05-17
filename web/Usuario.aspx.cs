using library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ENUsuario en = new ENUsuario();
                DataSet d = new DataSet();
                d = en.listarClientesD();
                GridView1.DataSource = d;
                GridView1.DataBind();
            }
        }
        protected void Leer(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ENUsuario en = new ENUsuario(0, TNick.Text, "blank", "blank", "blank", "blank", System.DateTime.Now, "blank", "blank");
                bool result = en.readUsuario();
                if (result == false)
                    LResultado.Text = "Error en la lectura del usuario";
                else
                {
                    TId.Text = en.id.ToString();
                    TNombre.Text = en.nombre;
                    TApellidos.Text = en.apellidos;
                    TEmail.Text = en.email;
                    TTelefono.Text = en.telef;
                    TFecha.Text = en.fecha_nac.ToString();
                    TRol.Text = en.rol;
                    TPassword.Text = en.password;
                    LResultado.Text = "Proceso de lectura realizado con éxito";
                }
            }
        }
        protected void LeerPrimero(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario();
            bool result = en.readFirstUsuario();
            if (result == false)
                LResultado.Text = "Error en la lectura del primera usuario";
            else
            {
                TId.Text = en.id.ToString();
                TNick.Text = en.nick;
                TNombre.Text = en.nombre;
                TApellidos.Text = en.apellidos;
                TEmail.Text = en.email;
                TTelefono.Text = en.telef;
                TFecha.Text = en.fecha_nac.ToString();
                TRol.Text = en.rol;
                TPassword.Text = en.password;
                LResultado.Text = "Proceso de lectura de primer usuario realizado con éxito";
            }
        }
        protected void LeerAnterior(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ENUsuario en = new ENUsuario(int.Parse(TId.Text), TNick.Text, "blank", "blank", "blank", "blank", System.DateTime.Now, "blank", "blank");
                bool result = en.readPrevUsuario();
                if (result == false)
                    LResultado.Text = "Error en la lectura del anterior usuario";
                else
                {
                    TId.Text = en.id.ToString();
                    TNick.Text = en.nick;
                    TNombre.Text = en.nombre;
                    TApellidos.Text = en.apellidos;
                    TEmail.Text = en.email;
                    TTelefono.Text = en.telef;
                    TFecha.Text = en.fecha_nac.ToString();
                    TRol.Text = en.rol;
                    TPassword.Text = en.password;
                    LResultado.Text = "Proceso de lectura de anterior usuario realizado con éxito";
                }
            }
        }
        protected void LeerSiguiente(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ENUsuario en = new ENUsuario(int.Parse(TId.Text), TNick.Text, "blank", "blank", "blank", "blank", System.DateTime.Now, "blank", "blank");
                bool result = en.readNextUsuario();
                if (result == false)
                    LResultado.Text = "Error en la lectura del siguiente usuario";
                else
                {
                    TId.Text = en.id.ToString();
                    TNick.Text = en.nick;
                    TNombre.Text = en.nombre;
                    TApellidos.Text = en.apellidos;
                    TEmail.Text = en.email;
                    TTelefono.Text = en.telef;
                    TFecha.Text = en.fecha_nac.ToString();
                    TRol.Text = en.rol;
                    TPassword.Text = en.password;
                    LResultado.Text = "Proceso de lectura de siguiente usuario realizado con éxito";
                }
            }
        }
        protected void Crear(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ENUsuario en = new ENUsuario(int.Parse(TId.Text), TNick.Text, TNombre.Text, TApellidos.Text, TEmail.Text, TPassword.Text, Convert.ToDateTime(TFecha.Text), TTelefono.Text, TRol.Text);
                bool result = en.createUsuario();
                if (result == false)
                    LResultado.Text = "Error en la creación del usuario";
                else
                    LResultado.Text = "Proceso de creación realizado con éxito";
            }
        }
        protected void Actualizar(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ENUsuario en = new ENUsuario(int.Parse(TId.Text), TNick.Text, TNombre.Text, TApellidos.Text, TEmail.Text, TPassword.Text, Convert.ToDateTime(TFecha.Text), TTelefono.Text, TRol.Text);
                bool result = en.updateUsuario();
                if (result == false)
                    LResultado.Text = "Error en la actualización del usuario";
                else
                    LResultado.Text = "Proceso de actualización realizado con éxito";
            }
        }
        protected void Borrar(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ENUsuario en = new ENUsuario(int.Parse(TId.Text), TNick.Text, "blank", "blank", "blank", "blank", System.DateTime.Now, "blank", "blank");
                bool result = en.deleteUsuario();
                if (result == false)
                    LResultado.Text = "Error en el borrado del usuario";
                else
                    LResultado.Text = "Proceso de borrado realizado con éxito";
            }
        }
    }
}