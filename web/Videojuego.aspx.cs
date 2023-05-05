using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace web
{
    public partial class Videojuego : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                // Query string value is there so now use it
                int id = Convert.ToInt32(Request.QueryString["id"]);
                ENVideojuego videojuego = new ENVideojuego();
                videojuego.Id = id;
                if (videojuego.readVideojuego())
                {
                    //Display data
                    videojuegoImagen.ImageUrl = videojuego.Imagen;
                    tituloLabel.Text = videojuego.Titulo;
                    productoraLink.Text = videojuego.Productora.Nombre;
                    categoriaLink.Text = videojuego.Categoria.nombre;
                    fechaLabel.Text = videojuego.FechaLanzamiento.ToString();
                    plataformaLabel.Text = videojuego.Plataforma;
                    descripcionLabel.Text = videojuego.Descripcion;
                    precioLabel.Text = videojuego.Precio.ToString();

                }
            }
        }
    }
}