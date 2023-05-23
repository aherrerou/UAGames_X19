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
    public partial class Reseña : System.Web.UI.Page
    {
        DataTable data = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {



                ENReview en = new ENReview();
                en.id = Convert.ToInt32(Request.QueryString["id"]);
                if (en.readReview())
                {
                    //Si el usuario es igual que el del inicio de sesión , entonces muestra los botones de edicion y eliminar
                    //if (Session["login_nick"].ToString() == en.usuario.nick.ToString())
                    //{
                    //    userText.Visible = true;
                    //    Filtrar.Visible = true;
                    //    Eliminar.Visible = true;
                    //}
                    videojuegoImagen.ImageUrl = en.videojuego.Imagen;
                    tituloLabel.Text = en.videojuego.Titulo + " - ";
                    fechaLabel.Text = en.fecha.ToString("dd/MM/yyyy");
                    Puntuacion.CurrentRating = Convert.ToInt32(en.puntuacion);
                    UsuarioLabel.Text = en.usuario.nombre.ToString();
                    comentarioLabel.Text = en.comentario.ToString();
                }

            }
        }

        public void Volver_click(object sender, EventArgs e)
        {
            //Cargamos los datos de la review para volver al videojuego en el que nos encontrabamos
            ENReview en = new ENReview();
            en.id = Convert.ToInt32(Request.QueryString["id"]);
            en.readReview();
            string url = "Videojuego.aspx?id=" + en.videojuego.Id;
            Response.Redirect(url);
        }

        public void Editar_click(object sender, EventArgs e)
        {
            //Cargamos los datos de la review para volver al videojuego en el que nos encontrabamos
            ENReview en = new ENReview();
            notaReview.Visible = true;
            comentarioReview.Visible = true;


        }

        public void Eliminar_click(object sender, EventArgs e)
        {
            //Cargamos los datos de la review para volver al videojuego en el que nos encontrabamos
            ENReview en = new ENReview();
            en.id = Convert.ToInt32(Request.QueryString["id"]);
            en.deleteReview();
            string url = "Videojuego.aspx?id=" + en.videojuego.Id;
            Response.Redirect(url);
        }

        public void Confirmar_click(object sender, EventArgs e)
        {
            //Cargamos los datos de la review para volver al videojuego en el que nos encontrabamos
            ENReview en = new ENReview();
            en.id = Convert.ToInt32(Request.QueryString["id"]);
            en.comentario = comentarioReview.Text;
            en.puntuacion = Convert.ToInt32(notaReview.Text);
            en.updateReview();
            string url = "Videojuego.aspx?id=" + en.videojuego.Id;
            Response.Redirect(url);
        }

        public void Cancelar_click(object sender, EventArgs e)
        {
            //Cargamos los datos de la review para volver al videojuego en el que nos encontrabamos
            ENReview en = new ENReview();
            en.id = Convert.ToInt32(Request.QueryString["id"]);
            en.deleteReview();
            string url = "Videojuego.aspx?id=" + en.videojuego.Id;
            Response.Redirect(url);
        }
    }
}