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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ENLista_Deseos en = new ENLista_Deseos();
                DataSet d = new DataSet();
                d = en.listarClientesD();
                GridView1.DataSource = d;
                GridView1.DataBind();
            }
        }
        protected void Leer(object sender, EventArgs e)
        {
            ENUsuario usu = new ENUsuario();
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
            ENUsuario usu = new ENUsuario();
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
            ENUsuario usu = new ENUsuario();
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
            ENUsuario usu = new ENUsuario();
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
            ENUsuario usu = new ENUsuario(int.Parse(TUsuario.Text), "blank", "blank", "blank", "blank", "blank", System.DateTime.Now, "blank", "blank");
            ENLista_Deseos en = new ENLista_Deseos(0, TNombre.Text, TDescripcion.Text, usu);
            bool result = en.createLista();
            if (result == false)
                LResultado.Text = "Error en la creación de la lista";
            else
                LResultado.Text = "Proceso de creación realizado con éxito";
        }
        protected void Actualizar(object sender, EventArgs e)
        {
            ENUsuario usu = new ENUsuario(int.Parse(TUsuario.Text), "blank", "blank", "blank", "blank", "blank", System.DateTime.Now, "blank", "blank");
            ENLista_Deseos en = new ENLista_Deseos(int.Parse(TId.Text), TNombre.Text, TDescripcion.Text, usu);
            bool result = en.updateLista();
            if (result == false)
                LResultado.Text = "Error en la actualización de la lista";
            else
                LResultado.Text = "Proceso de actualización realizado con éxito";
        }
        protected void Borrar(object sender, EventArgs e)
        {
            ENUsuario usu = new ENUsuario(int.Parse(TUsuario.Text), "blank", "blank", "blank", "blank", "blank", System.DateTime.Now, "blank", "blank");
            ENLista_Deseos en = new ENLista_Deseos();
            bool result = en.deleteLista();
            if (result == false)
                LResultado.Text = "Error en el borrado de la lista";
            else
                LResultado.Text = "Proceso de borrado realizado con éxito";
        }
    }
}