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
                    comprobarCamposReview();
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
                videojuego.Id = Int32.Parse(((ImageButton)sender).CommandArgument);
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
            review.videojuego.Id = videojuego;
            review.usuario.nick = nombreUsuario.Text.ToString();
            review.usuario.readUsuario();
            listViewReviews.DataSource = review.filtrarReview();

            listViewReviews.DataBind();
        }

        protected void fillOferta(int videojuego)
        {
            ENOferta oferta = new ENOferta();
            ofertaDisplay.DataSource = oferta.readOferta(videojuego);
            ofertaDisplay.DataBind();
            //Comprobar si contenido en oferta
            if (ofertaDisplay.Items.Count > 0)
            {
                precioLabel.Style.Add("text-decoration", "line-through");
                //Actualizar precio
            }

        }

        protected void crearReview_click(object sender, EventArgs e)
        {
            //if (Session["login_nick"] == null)
            //{
            //    Response.Redirect("Inicia_Sesion.aspx");
            //}
            //else
            //{
            ENUsuario u = new ENUsuario();
            u.id = 1;
            ENReview review = new ENReview();
            u.readUsuario();
            review.usuario = u;
            review.videojuego.Id = Convert.ToInt32(Request.QueryString["id"]);
            review.comentario = comentarioReview.Text.ToString();
            review.puntuacion = Convert.ToInt32(notaReview.Text.ToString());
            review.createReview();

            fillReviews(review.videojuego.Id);
            //Mostramos campos necesarios
            añadirReview.Visible = true;
            filtrarReview.Visible = true;

            //}
        }

        protected void añadirReview_click(object sender, EventArgs e)
        {
            //if (Session["login_nick"] != null)
            //{
            ocultarCampos();
            comentarioReview.Visible = true;
            notaReview.Visible = true;
            crearReview.Visible = true;
            cancelar.Visible = true;
            //}
        }

        protected void comprobarCamposReview()
        {
            //if (Session["login_nick"] != null)
            //{
            añadirReview.Visible = true;
            //}
            //else
            //{
            //    añadirReview.Visible = false;
            //}
        }

        protected void cancelarReview_click(object sender, EventArgs e)
        {
            //Ocultamos campos
            ocultarCampos();

            //if (Session["login_nick"] != null)
            //{
            añadirReview.Visible = true;
            filtrarReview.Visible = true;
            nombreUsuario.Visible = true;
            //}
            //else
            //{
            //    añadirReview.Visible = false;
            //}

            //Dejamos los Textbox por defecto
            notaReview.Text = null;
            comentarioReview.Text = null;
        }

        protected void EliminarComentario(Object sender, EventArgs e)
        {
            /*//Button btn = (Button)sender;
            string reviewEmail = ((LinkButton)sender).CommandArgument.ToString();
            ENReview review = new ENReview();
            review.deleteReview(reviewEmail);
            Response.Redirect(Request.Url.AbsoluteUri);*/
        }

        protected void filtrarReview_click(Object sender, EventArgs e)
        {
        }

        private void ocultarCampos()
        {
            comentarioReview.Visible = false;
            notaReview.Visible = false;
            cancelar.Visible = false;
            crearReview.Visible = false;
            añadirReview.Visible = false;
            filtrarReview.Visible = false;
            nombreUsuario.Visible = false;
        }
    }
}