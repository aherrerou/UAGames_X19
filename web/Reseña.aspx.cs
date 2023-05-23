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
                en.usuario.id = 1;
                data = en.misReviews();
                ReviewListView.DataSource = data;
                ReviewListView.DataBind();
            }
        }
        protected void crearReviewClick(object sender, EventArgs e)
        {
            ENVideojuego v = new ENVideojuego();
            ENUsuario u = new ENUsuario();
            u.id = 1;

            v.Titulo = nombreVideojuego.Text.ToString();

            if (v.readVideojuego())
            {
                ENReview review = new ENReview(DateTime.Now, Convert.ToInt32(puntuacion), comentario.ToString(), v, u);
                if (review.comprobarUsuarioReview())
                {
                    review.createReview();
                }

            }
        }

        protected void deleteReview_Click(object sender, EventArgs e)
        {
            ENReview review = new ENReview();
            review.id = Convert.ToInt32(((Button)sender).CommandArgument);
            if (review.comprobarUsuarioReview())
            {
                review.deleteReview();
            }
        }

        protected void editarReview_Click(object sender, EventArgs e)
        {
            ENReview review = new ENReview();
            review.id = Convert.ToInt32(((Button)sender).CommandArgument);
            if (review.comprobarUsuarioReview())
            {
                review.updateReview();
            }
        }

        protected void filtrarReview_Click(object sender, EventArgs e)
        {
            ENReview review = new ENReview();

            review.filtrarReview();
        }

        protected void misReviews_Click(object sender, EventArgs e)
        {
            ENUsuario u = new ENUsuario();
            if (Session["login_nick"] != null)
            {

                u.nick = Session["login_nick"].ToString();
                u.readUsuario();
            }

            ENReview review = new ENReview();
            review.usuario = u;
            review.filtrarReview();
        }
    }
}