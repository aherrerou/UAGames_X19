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
        protected String EmailSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                // Query string value is there so now use it
                int id = Convert.ToInt32(Request.QueryString["id"]);
                ENVideojuego videojuego = new ENVideojuego();
                videojuego.Id = id;
                if (videojuego.readVideojuegoId())
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
                    fillReviews(videojuego.Id);
                    fillOferta(videojuego.Id);

                }
            }
        }

        protected void clickAddList(object sender, EventArgs e)
        {
            if (Session["login_nick"] == null)
            {
                Response.Redirect("Inicia_Sesion.aspx");
            }
            else
            {
                ENVideojuego videojuego = new ENVideojuego();
                videojuego.Id = Int32.Parse(((ImageButton)sender).CommandArgument);
                if (videojuego.readVideojuegoId())
                {
                    //Se agrega a lista de deseos
                    ENLista_Deseos lista = new ENLista_Deseos();
                    ENUsuario auxUser = new ENUsuario();
                    auxUser.nick = Session["login_nick"].ToString();
                    auxUser.readUsuario();
                    lista.usuario = auxUser;
                    lista.readListaPorUsu();
                    //Agregar elemento a la lista
                    lista.addVideojuegoLista(videojuego.Id);
                }

            }
        }

        protected void clickAddCart(object sender, EventArgs e)
        {
            if (Session["login_nick"] == null)
            {
                Response.Redirect("Inicia_Sesion.aspx");
            }
            else
            {
                ENVideojuego videojuego = new ENVideojuego();
                videojuego.Id = Int32.Parse(((Button)sender).CommandArgument);
                if (videojuego.readVideojuegoId())
                {
                    //Se agrega a lista de deseos
                    ENCesta cesta = new ENCesta();
                    ENUsuario auxUser = new ENUsuario();
                    auxUser.nick = Session["login_nick"].ToString();
                    //Se lee usuario
                    auxUser.readUsuario();
                    cesta.usuarioID = auxUser;
                    cesta.readCesta();
                    //Agregar elemento a la lista
                    cesta.addVideojuego(videojuego.Id);
                }

            }
        }

        protected void fillReviews(int videojuego)
        {
            ENReview review = new ENReview();
            listViewReviews.DataSource = review.readReviews(videojuego);
            listViewReviews.DataBind();
        }

        protected void fillOferta(int videojuego)
        {
            ENOferta oferta = new ENOferta();
            ofertaDisplay.DataSource = oferta.readOferta(videojuego);
            ofertaDisplay.DataBind();
            //Comprobar si contenido en oferta
            if(ofertaDisplay.Items.Count > 0)
            {
                precioLabel.Style.Add("text-decoration", "line-through");
                //Actualizar precio
            }
           
        }

        protected void EliminarComentario(Object sender, EventArgs e)
        {
            /*//Button btn = (Button)sender;
            string reviewEmail = ((LinkButton)sender).CommandArgument.ToString();
            ENReview review = new ENReview();
            review.deleteReview(reviewEmail);
            Response.Redirect(Request.Url.AbsoluteUri);*/
        }
    }
}