﻿using System; 
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
                        Editar.Visible = true;
                        Eliminar.Visible = true;
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
            notaReview.Visible = true;
            comentarioReview.Visible = true;
            cancelar.Visible = true;
            confirmar.Visible = true;
        }

        public void Eliminar_click(object sender, EventArgs e)
        {
            //Cargamos los datos de la review para volver al videojuego en el que nos encontrabamos
            int idVideojuego;
            ENReview en = new ENReview();
            int idReseña = Convert.ToInt32(Request.QueryString["id"]);
            //Cargamos datos de la review
            en.id = idReseña;
            en.readReview();
            //Guardamos id del videojuego
            idVideojuego = en.videojuego.Id;
            //Borramos y volvemos con el id guardado anteriormente
            en.deleteReview();
            string url = "Videojuego.aspx?id=" + idVideojuego;
            Response.Redirect(url);
        }

        public void Confirmar_click(object sender, EventArgs e)
        {
            //Cargamos los datos de la review para volver al videojuego en el que nos encontrabamos
            ENReview en = new ENReview();
            en.id = Convert.ToInt32(Request.QueryString["id"]);
            en.readReview();
            en.puntuacion = Convert.ToInt32(notaReview.Text) > 5 ? 5 : Convert.ToInt32(notaReview.Text);
            //Updateamos lo necesarios
            en.comentario = comentarioReview.Text;
            en.updateReview();
            string url = "Reseña.aspx?id=" + en.id;
            Response.Redirect(url);
        }

        public void Cancelar_click(object sender, EventArgs e)
        {
            //Cargamos los datos de la review para volver al videojuego en el que nos encontrabamos
            ENReview en = new ENReview();
            en.id = Convert.ToInt32(Request.QueryString["id"]);
            string url = "Reseña.aspx?id=" + en.id;
            Response.Redirect(url);
        }
    }
}