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
            
        }

        protected void clickRowCancelVideojuego(object sender, GridViewCancelEditEventArgs e)
        {

        }


        protected void clickRowUpdateVideojuego(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void clickRowDeleteVideojuego(object sender, GridViewDeleteEventArgs e)
        {

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