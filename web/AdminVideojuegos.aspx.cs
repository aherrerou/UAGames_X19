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
            ENVideojuego videojuego = new ENVideojuego();
            videojuego.Id = Int32.Parse(videojuegoTable.Rows[e.RowIndex].Cells[0].Text);
            videojuego.Titulo = videojuegoTable.Rows[e.RowIndex].Cells[1].Text;
            //ToDo resolver actualizar productora  y categoria en videojuego
            ENProductora productora = new ENProductora();
            productora.Nombre = videojuegoTable.Rows[e.RowIndex].Cells[2].Text;
            videojuego.Productora = productora;

            ENCategoria categoria = new ENCategoria();
            categoria.nombre = videojuegoTable.Rows[e.RowIndex].Cells[3].Text;
            videojuego.Categoria = categoria;

            videojuego.FechaLanzamiento = DateTime.Parse(videojuegoTable.Rows[e.RowIndex].Cells[4].Text);
            videojuego.Precio = Double.Parse(videojuegoTable.Rows[e.RowIndex].Cells[5].Text);
            videojuego.Plataforma = videojuegoTable.Rows[e.RowIndex].Cells[6].Text;
            videojuego.Imagen = videojuegoTable.Rows[e.RowIndex].Cells[7].Text;
            videojuego.Descripcion = videojuegoTable.Rows[e.RowIndex].Cells[8].Text;

            videojuegoTable.DataSource = videojuego.updateVideojuego(videojuegoTable.SelectedIndex);
            videojuegoTable.DataBind();
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

    }
}