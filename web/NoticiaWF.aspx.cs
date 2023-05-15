using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;
namespace web
{
    public partial class NoticiaWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["miconexion"].ToString());
            SqlDataAdapter sda = new SqlDataAdapter("select * from Noticia",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ListView1.DataSource = dt;
            ListView1.DataBind();
            
            }
        }


    }

