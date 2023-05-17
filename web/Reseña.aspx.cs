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
                data = en.listarReviews();
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
            review.id =Convert.ToInt32(((Button)sender).CommandArgument);
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
            review.id = Convert.ToInt32(((Button)sender).CommandArgument);
            review.filtrarReviewPorVideojuego();
        }
    }
}