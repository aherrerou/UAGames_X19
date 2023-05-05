using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace web
{
    public partial class AdminVideojuegos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillVideojuegosTable();
            }
        }

        protected void changePageVideojuegosTable(object sender, GridViewPageEventArgs e)
        {
            videojuegoTable.PageIndex = e.NewPageIndex;
            FillVideojuegosTable();
        }

        protected void FillVideojuegosTable()
        {
            ENVideojuego videojuego = new ENVideojuego();
            videojuegoTable.DataSource = videojuego.readVideojuegos();
            videojuegoTable.DataBind();
        }

        protected void clickRowEditVideojuego(object sender, GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            videojuegoTable.EditIndex = e.NewEditIndex;
            FillVideojuegosTable();
        }

        protected void clickRowCancelVideojuego(object sender, GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            videojuegoTable.EditIndex = -1;
            FillVideojuegosTable();
        }


        protected void clickRowUpdateVideojuego(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void clickRowDeleteVideojuego(object sender, GridViewDeleteEventArgs e)
        {
            ENVideojuego videojuego = new ENVideojuego();
            videojuego.Id = Int32.Parse(videojuegoTable.Rows[e.RowIndex].Cells[0].Text);

            if (videojuego.deleteVideojuego())
            {
                FillVideojuegosTable();
                //ToDo mensaje mostrando exito
            }
            else
            {
                //ToDo mensaje mostrando error
            }
        }

        protected void clickOnInsertVideojuego(object sender, EventArgs e)
        {

        }

        protected string Crop(string text, int maxLength)
        {
            if (text == null)
            {
                return string.Empty;
            }

            if (text.Length < maxLength)
            {
                return text;
            }

            return text.Substring(0, maxLength);
        }
    }
}