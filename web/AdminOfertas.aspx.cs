using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace web
{
    public partial class AdminOfertas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillOfertasTable();
            }
        }

        protected void changePageOfertasTable(object sender, GridViewPageEventArgs e)
        {
            ofertasTable.PageIndex = e.NewPageIndex;
            FillOfertasTable();
        }

        protected void FillOfertasTable()
        {
            ENOferta oferta = new ENOferta();
            ofertasTable.DataSource = oferta.readOfertas();
            ofertasTable.DataBind();
        }

        protected void clickRowEditOferta(object sender, GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            ofertasTable.EditIndex = e.NewEditIndex;
            FillOfertasTable();
        }

        protected void clickRowCancelOferta(object sender, GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            ofertasTable.EditIndex = -1;
            FillOfertasTable();
        }

        protected void clickRowUpdateOferta(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void clickRowDeleteOferta(object sender, GridViewDeleteEventArgs e)
        {
      
        }
    }
}