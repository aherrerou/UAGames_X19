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
                //ENVideojuego v= new ENVideojuego();
                //ENUsuario u = new ENUsuario();
                //v.Id = 1;
                //u.id = 1;
                //ENReview en = new ENReview(Convert.ToDateTime("2002-10-02"), Convert.ToInt32("8"), "paco", v, u);
                //bool result = en.createReview();
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

            v.Titulo = nombreVideojuego.ToString();

            if (v.readVideojuego())
            {
                //Falta comprobar que haya iniciado sesion
                ENReview review = new ENReview(DateTime.Now, Convert.ToInt32(puntuacion), comentario.ToString(), v, u);
            }
        }

        protected void deleteReview_Click(object sender, EventArgs e)
        {
            ENVideojuego v = new ENVideojuego();
            ENUsuario u = new ENUsuario();

            v.Titulo = nombreVideojuego.ToString();

            if (v.readVideojuego())
            {
                //Falta comprobar que haya iniciado sesion
                ENReview review = new ENReview(DateTime.Now, Convert.ToInt32(puntuacion), comentario.ToString(), v, u);
            }
        }
    }
}