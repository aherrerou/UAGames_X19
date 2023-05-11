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
    public partial class AdminVideojuegos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillVideojuegosTable();
                FillProductorasDropdown();
                FillCategoriasDropdown();
                cleanMsg();
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

        protected void FillCategoriasDropdown()
        {
            ENCategoria categoria = new ENCategoria();
            DataTable dt = categoria.readCategoriasNombre();
            ListItem i;
            foreach (DataRow r in dt.Rows)
            {
                i = new ListItem(r["nombre"].ToString(), r["id"].ToString());
                categoriasList.Items.Add(i);
            }
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
            videojuego.Titulo = ((TextBox)videojuegoTable.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            //ToDo resolver actualizar productora  y categoria en videojuego
            videojuego.Productora.Nombre = ((TextBox)videojuegoTable.Rows[e.RowIndex].Cells[2].Controls[0]).Text;

            videojuego.Categoria.nombre = ((TextBox)videojuegoTable.Rows[e.RowIndex].Cells[3].Controls[0]).Text;

            videojuego.FechaLanzamiento = DateTime.Parse(((TextBox)videojuegoTable.Rows[e.RowIndex].Cells[4].Controls[0]).Text);
            videojuego.Precio = Double.Parse(((TextBox)videojuegoTable.Rows[e.RowIndex].Cells[5].Controls[0]).Text);
            videojuego.Plataforma = ((TextBox)videojuegoTable.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
            videojuego.Imagen = ((TextBox)videojuegoTable.Rows[e.RowIndex].Cells[7].Controls[0]).Text;
            videojuego.Descripcion = ((TextBox)videojuegoTable.Rows[e.RowIndex].Cells[8].Controls[0]).Text;

            //videojuegoTable.DataSource = videojuego.updateVideojuego(videojuegoTable.SelectedIndex);
            //videojuegoTable.DataBind();

            if (videojuego.updateVideojuego())
            {
                videojuegoTable.EditIndex = -1;
                FillVideojuegosTable();
                //Mensaje mostrando exito
                mostrarResultado("Videojuego actualizado correctamente.");
            }
            else
            {
                //Mensaje mostrando error
                mostrarError("Error al actualizar el videojuego.");
            }

        }

        protected void clickRowDeleteVideojuego(object sender, GridViewDeleteEventArgs e)
        {
            ENVideojuego videojuego = new ENVideojuego();
            videojuego.Id = Int32.Parse(videojuegoTable.Rows[e.RowIndex].Cells[0].Text);
            videojuego.Titulo = videojuegoTable.Rows[e.RowIndex].Cells[1].Text;

            if (videojuego.deleteVideojuego())
            {
                FillVideojuegosTable();
                //Mensaje mostrando exito
                mostrarResultado("Videojuego eliminado correctamente.");
            }
            else
            {
                //Mensaje mostrando error
                mostrarError("Error al eliminar el videojuego.");
            }
        }

        protected void ProductoraSelectionChange(object sender, EventArgs e)
        {

        }

        protected void CategoriaSelectionChange(object sender, EventArgs e)
        {

        }

        protected void crearVideojuegoClick(object sender, EventArgs e)
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
        }

        private void mostrarResultado(string resultado)
        {
            msgSalida.Text = resultado;
            msgSalida.BackColor = System.Drawing.Color.Green;
        }



    }
}