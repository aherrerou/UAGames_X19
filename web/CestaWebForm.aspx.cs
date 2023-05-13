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
        public partial class CestaWebForm : System.Web.UI.Page
        {

        DataTable data = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable data = new DataTable();
            if (!Page.IsPostBack)
            {
                FillCestasTable();
            }
        }

        protected void changePageCestaTable(object sender, GridViewPageEventArgs e)
        {
            cestaTable.PageIndex = e.NewPageIndex;
            FillCestasTable();
        }

        protected void FillCestasTable()
        {
            ENCesta cesta = new ENCesta();
            data = cesta.readCestas();
            cestaTable.DataSource = data;
            cestaTable.DataBind();               
        }
        protected void clickRowEditCesta(object sender, GridViewEditEventArgs e)
        {
            cestaTable.EditIndex = e.NewEditIndex;
            FillCestasTable();
        }

        protected void clickRowCancelCesta(object sender, GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            cestaTable.EditIndex = -1;
            FillCestasTable();
        }

        protected void clickRowUpdateCesta(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void clickRowDeleteCesta(object sender, GridViewDeleteEventArgs e)
        {
            /*ENCesta en = new ENCesta(Int32.Parse(categoriasTable.Rows[e.RowIndex].Cells[0].Text), categoriasTable.Rows[e.RowIndex].Cells[1].Text, categoriasTable.Rows[e.RowIndex].Cells[2].Text);
            bool result = en.deleteCategoria();
            if (result == false)
                Resultado.Text = "Error en el borrado de la categoria";
            else
                FillCategoriasTable();
            Resultado.Text = "Proceso de borrado realizado con éxito";*/
        }
    }

   

}

