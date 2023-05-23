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
    public partial class CategoriaWebForm : System.Web.UI.Page
    {
        DataTable data = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable data = new DataTable();
            if (!Page.IsPostBack)
            {
                FillCategoriasTable();
            }
        }

        protected void changePageCategoriasTable(object sender, GridViewPageEventArgs e)
        {
            categoriasTable.PageIndex = e.NewPageIndex;
            FillCategoriasTable();
        }

        protected void FillCategoriasTable()
        {
            ENCategoria categoria = new ENCategoria();
            data = categoria.readCategorias();
            categoriasTable.DataSource = data;
            categoriasTable.DataBind();
        }

        protected void clickRowEditCategorias(object sender, GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            categoriasTable.EditIndex = e.NewEditIndex;
            FillCategoriasTable();
        }

        protected void clickRowCancelCategorias(object sender, GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            categoriasTable.EditIndex = -1;
            FillCategoriasTable();
        }

        protected void clickRowUpdateCategorias(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void clickRowDeleteCategorias(object sender, GridViewDeleteEventArgs e)
        {
            ENCategoria en = new ENCategoria(Int32.Parse(categoriasTable.Rows[e.RowIndex].Cells[0].Text), categoriasTable.Rows[e.RowIndex].Cells[1].Text, categoriasTable.Rows[e.RowIndex].Cells[2].Text);
            bool result = en.deleteCategoria();
            if (result == false)
                Resultado.Text = "Error en el borrado de la categoria";
            else
                FillCategoriasTable();
                Resultado.Text = "Proceso de borrado realizado con éxito";

        }
        protected void crearCategoriaClick(object sender, EventArgs e)
        {
            ENCategoria en = new ENCategoria(0,Nombre.Text, Descripcion.Text);
            bool result = en.createCategoria();
            if (result == false)
                Resultado.Text = "Error en la creación de la categoria";
            else
                Resultado.Text = "Proceso de creación realizado con éxito";
        }
    }
}