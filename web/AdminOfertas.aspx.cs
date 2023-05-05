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
    public partial class AdminOfertas : System.Web.UI.Page
    {
        DataTable data = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillOfertasTable();
                //FillProductorasDropdown();
                //FillVideojuegosDropdown();
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
            data = oferta.readOfertas();
            ofertasTable.DataSource = data;
            ofertasTable.DataBind();
        }

        protected void FillProductorasDropdown()
        {
            ENProductora productora = new ENProductora();
            DataTable dt = productora.readProductorasNombre();
            ListItem i;
            foreach (DataRow r in dt.Rows)
            {
                i = new ListItem(r["nombre"].ToString(), r["id"].ToString());
                productorasList.Items.Add(i);
            }
        }

        protected void FillVideojuegosDropdown()
        {
            ENVideojuego videojuego = new ENVideojuego();
            DataTable dt = videojuego.readVideojuegos();
            ListItem i;
            foreach (DataRow r in dt.Rows)
            {
                i = new ListItem(r["titulo"].ToString(), r["id"].ToString());
                videojuegosList.Items.Add(i);
            }
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

        protected void ProductoraSelectionChange(object sender, EventArgs e)
        {
            //Hacer aparecer videojuego cuando se seleccione productora
        }

        protected void VideojuegoSelectionChange(object sender, EventArgs e)
        {

        }

        protected void crearOfertaClick(object sender, EventArgs e)
        {
            
        }
    }
}