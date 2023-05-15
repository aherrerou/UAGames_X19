using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using library;
namespace web
{
    public partial class ProductoraWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void onCrear(object sender, EventArgs e)
        {
            if (txtImg.Text != "" && txtNombre.Text != "" && txtDescripcion.Text != "" && txtWeb.Text != "")
            {
                ENProductora prod = new ENProductora();
                prod.Imagen = txtImg.Text;
                prod.Nombre = txtNombre.Text;
                prod.Descripcion = txtDescripcion.Text;
                prod.Web = txtWeb.Text;

                if (prod.createProductora())
                {
                    PResultado.Text = "Productora  insertada en la B.D.";
                }
                else PResultado.Text = "No es posible insertar la productora.";
            }

            else PResultado.Text = "Alguno de los campos no estan especificados.";
        }
        protected void onLeer(object sender,EventArgs e)
        {
            if (txtNombre.Text == "")
                PResultado.Text = "Nombre de la productora no introducido.";
            else
            {
                ENProductora prod = new ENProductora();
                prod.Nombre = txtNombre.Text;

                if (prod.readProductora())
                {
                    txtNombre.Text = prod.Nombre;
                    txtImg.Text = prod.Imagen;
                    txtDescripcion.Text = prod.Descripcion;
                    txtWeb.Text = prod.Web;
                    PResultado.Text = "Productora " + prod.Nombre + " mostrada con éxito.";
                }
                else PResultado.Text = "Productora no encontrada en la B.D.";
            }

        }

    }

    
}