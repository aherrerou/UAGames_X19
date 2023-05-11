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
    public partial class Lista_Deseos : System.Web.UI.Page
    {
        private ENUsuario usu = new ENUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login_nick"] != null)
            {
                usu.nick = Session["login_nick"].ToString();
                usu.readUsuario();
                if(usu.rol != "admin")
                {
                    LTitulo.Text = "Lista de Deseos de " + Session["login_nick"].ToString();
                    LListado.Text = "(Ahora mismo se muestra la lista en sí, no los contenidos)";
                    TId.Visible = false;
                    LId.Visible = false;
                    TNombre.Visible = false;
                    LNombre.Visible = false;
                    TUsuario.Visible = false;
                    LUsuario.Visible = false;
                    TDescripcion.Visible = false;
                    LDescripcion.Visible = false;
                    BLeer_F.Visible = false;
                    BLeerA_F.Visible = false;
                    BLeerS_F.Visible = false;
                    BLeerP_F.Visible = false;
                    BCrear_F.Visible = false;
                    BActualizar_F.Visible = false;
                    BBorrar_F.Visible = false;
                }
            }
            if (!Page.IsPostBack)
            {
                ENLista_Deseos en = new ENLista_Deseos();
                DataSet d = new DataSet();
                if (usu.rol != "admin")
                    d = en.listarClientesDAdmin();
                else
                    d = en.listarClientesDUsu();
                GridView1.DataSource = d;
                GridView1.DataBind();
            }
        }
        protected void Leer(object sender, EventArgs e)
        {
            ENLista_Deseos en = new ENLista_Deseos(int.Parse(TId.Text), "blank", "blank", usu);
            bool result = en.readLista();
            if (result == false)
                LResultado.Text = "Error en la lectura de la lista";
            else
            {
                TId.Text = en.id.ToString();
                TNombre.Text = en.nombre;
                TDescripcion.Text = en.descripcion;
                TUsuario.Text = en.usuario.id.ToString();
                LResultado.Text = "Proceso de lectura realizado con éxito";
            }
        }
        protected void LeerPrimero(object sender, EventArgs e)
        {
            ENLista_Deseos en = new ENLista_Deseos(0, "blank", "blank", usu);
            bool result = en.readFirstLista();
            if (result == false)
                LResultado.Text = "Error en la lectura de la primera lista";
            else
            {
                TId.Text = en.id.ToString();
                TNombre.Text = en.nombre;
                TDescripcion.Text = en.descripcion;
                TUsuario.Text = en.usuario.id.ToString();
                LResultado.Text = "Proceso de lectura de primera lista realizado con éxito";
            }
        }
        protected void LeerAnterior(object sender, EventArgs e)
        {
            ENLista_Deseos en = new ENLista_Deseos(int.Parse(TId.Text), "blank", "blank", usu);
            bool result = en.readPrevLista();
            if (result == false)
                LResultado.Text = "Error en la lectura de la anterior lista";
            else
            {
                TId.Text = en.id.ToString();
                TNombre.Text = en.nombre;
                TDescripcion.Text = en.descripcion;
                TUsuario.Text = en.usuario.id.ToString();
                LResultado.Text = "Proceso de lectura de anterior lista realizado con éxito";
            }
        }
        protected void LeerSiguiente(object sender, EventArgs e)
        {
            ENLista_Deseos en = new ENLista_Deseos(int.Parse(TId.Text), "blank", "blank", usu);
            bool result = en.readNextLista();
            if (result == false)
                LResultado.Text = "Error en la lectura de la siguiente lista";
            else
            {
                TId.Text = en.id.ToString();
                TNombre.Text = en.nombre;
                TDescripcion.Text = en.descripcion;
                TUsuario.Text = en.usuario.id.ToString();
                LResultado.Text = "Proceso de lectura de siguiente lista realizado con éxito";
            }
        }
        protected void Crear(object sender, EventArgs e)
        {
            usu.id = int.Parse(TUsuario.Text);
            ENLista_Deseos en = new ENLista_Deseos(0, TNombre.Text, TDescripcion.Text, usu);
            bool result = en.createLista();
            if (result == false)
                LResultado.Text = "Error en la creación de la lista";
            else
                LResultado.Text = "Proceso de creación realizado con éxito";
        }
        protected void Actualizar(object sender, EventArgs e)
        {
            usu.id = int.Parse(TUsuario.Text);
            ENLista_Deseos en = new ENLista_Deseos(int.Parse(TId.Text), TNombre.Text, TDescripcion.Text, usu);
            bool result = en.updateLista();
            if (result == false)
                LResultado.Text = "Error en la actualización de la lista";
            else
                LResultado.Text = "Proceso de actualización realizado con éxito";
        }
        protected void Borrar(object sender, EventArgs e)
        {
            usu.id = int.Parse(TUsuario.Text);
            ENLista_Deseos en = new ENLista_Deseos();
            bool result = en.deleteLista();
            if (result == false)
                LResultado.Text = "Error en el borrado de la lista";
            else
                LResultado.Text = "Proceso de borrado realizado con éxito";
        }
    }
}