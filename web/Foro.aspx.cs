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
    public partial class Foro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ENPublicacion en = new ENPublicacion();
                DataSet d = new DataSet();
                d = en.listarClientesD();
                GridView1.DataSource = d;
                GridView1.DataBind();
            }

        }
    }
}