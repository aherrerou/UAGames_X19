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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ENUsuario user = new ENUsuario();
                ENVideojuego juego = new ENVideojuego();
                DataSet d = new DataSet();
                ENReview en = new ENReview(Convert.ToDateTime("2022-06-26"), 8, "Callate Tonto", juego, user);
                bool result = en.createReview();
                //GridView1.DataSource = d;
                //GridView1.DataBind();
            }
        }

        protected void CrearReseña_Click(object sender, EventArgs e)
        {


            //ENReview en = new ENReview(Convert.ToDateTime(this.Fecha.Text), Convert.ToInt32(this.Puntuacion.Text), this.Comentario.Text , Convert.ToInt32(this.VideojuegoID.Text),Convert.ToInt32(this.UsuarioID.Text));
            //bool result = en.createReview();
        }

        protected void Puntuacion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void VideojuegoID_TextChanged(object sender, EventArgs e)
        {

        }

        protected void UsuarioID_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Comentario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Fecha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}