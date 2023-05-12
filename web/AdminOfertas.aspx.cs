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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillOfertasTable();
                FillProductorasDropdown();
                FillVideojuegosDropdown();
                cleanMsg();
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

        protected void OfertasTable_Sorting(object sender, GridViewSortEventArgs e)
        {

            //Retrieve the table from the session object.
            DataTable dt = Session["OfertasGrid"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                ofertasTable.DataSource = Session["OfertasGrid"];
                ofertasTable.DataBind();
            }

        }

        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
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
            ENOferta oferta = new ENOferta();
            oferta.Id = Int32.Parse(ofertasTable.Rows[e.RowIndex].Cells[0].Text);
            oferta.Nombre = ((TextBox)ofertasTable.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            oferta.Videojuego.Titulo = ((TextBox)ofertasTable.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            oferta.Productora.Nombre = ((TextBox)ofertasTable.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            oferta.Descuento = int.Parse(((TextBox)ofertasTable.Rows[e.RowIndex].Cells[4].Controls[0]).Text);
            oferta.FechaInicio = DateTime.Parse(((TextBox)ofertasTable.Rows[e.RowIndex].Cells[5].Controls[0]).Text);
            oferta.FechaFin = DateTime.Parse(((TextBox)ofertasTable.Rows[e.RowIndex].Cells[6].Controls[0]).Text);


            if (oferta.updateOferta())
            {
                ofertasTable.EditIndex = -1;
                FillOfertasTable();
                //Mensaje mostrando exito
                mostrarResultado("Oferta actualizada correctamente.");
            }
            else
            {
                //Mensaje mostrando error
                mostrarError("Error al actualizar la oferta.");
            }
        }

        protected void clickRowDeleteOferta(object sender, GridViewDeleteEventArgs e)
        {
            ENOferta oferta = new ENOferta();
            oferta.Id = Int32.Parse(ofertasTable.Rows[e.RowIndex].Cells[0].Text);
            oferta.Nombre = ofertasTable.Rows[e.RowIndex].Cells[1].Text;

            if (oferta.deleteOferta())
            {
                FillOfertasTable();
                //Mensaje mostrando exito
                mostrarResultado("Oferta eliminada correctamente.");
            }
            else
            {
                //Mensaje mostrando error
                mostrarError("Error al eliminar la oferta.");
            }
        }

        protected void ProductoraSelectionChange(object sender, EventArgs e)
        {
            //Hacer aparecer videojuego cuando se seleccione productora

        }

        protected void crearOfertaClick(object sender, EventArgs e)
        {
            
        }


        private void mostrarError(string error)
        {
            msgSalida.Text = error;
            msgSalida.BackColor = System.Drawing.Color.Red;
        }

        private void cleanMsg()
        {
            msgSalida.Text = "";
            msgSalida.BackColor = System.Drawing.Color.White;
            msgSalidaCrear.Text = "";
            msgSalidaCrear.BackColor = System.Drawing.Color.White;
        }

        private void mostrarResultado(string resultado)
        {
            msgSalida.Text = resultado;
            msgSalida.BackColor = System.Drawing.Color.Green;
        }
    }
}