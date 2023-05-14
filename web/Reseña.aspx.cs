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
                CargarReseñas();
            }
        }

        protected void CargarReseñas()
        {
            ENReview en = new ENReview();
            data = en.listarReviews();
            reviewTable.DataSource = data;
            reviewTable.DataBind();
        }

        protected void CrearReseña_Click(object sender, EventArgs e)
        {
            //ENReview en = new ENReview(Convert.ToDateTime(this.Fecha.Text), Convert.ToInt32(this.Puntuacion.Text), this.Comentario.Text , Convert.ToInt32(this.VideojuegoID.Text),Convert.ToInt32(this.UsuarioID.Text));
            //bool result = en.createReview();
        }
    }
}