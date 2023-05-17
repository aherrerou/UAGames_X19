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
                    decimal precioTotal = 0;

                    // Recorre los elementos del GridView y suma el precio de cada uno
                    foreach (GridViewRow row in cestaTable.Rows)
                    {
                        precioTotal += Convert.ToDecimal(row.Cells[2].Text);
                    }

                    // Muestra el precio total en un Label
                    precioTotalLabel.Text = precioTotal.ToString("C");
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
                /*ENCesta en = new ENCesta(cateTable.Rows[e.RowIndex].Cells[1].Text, categoriasTable.Rows[e.RowIndex].Cells[1].Text, categoriasTable.Rows[e.RowIndex].Cells[2].Text);
                bool result = en.deleteCesta();
                if (result == false)
                    Resultado.Text = "Error en el borrado de la categoria";
                else
                    FillCategoriasTable();
                Resultado.Text = "Proceso de borrado realizado con éxito";*/
            }

            protected void ComprarClick(object sender, EventArgs e)
            {
            if (Session["login_nick"] == null)
            {
                Response.Redirect("Inicia_Sesion.aspx");
            }
            else
            {
                ENUsuario usuario = new ENUsuario();
                usuario.nick = Session["login_nick"].ToString();
                usuario.readUsuario();
                DateTime fecha = DateTime.Now;
                double precioTotal = 0.00;
                foreach (GridViewRow row in cestaTable.Rows)
                {
                    precioTotal += Convert.ToDouble(row.Cells[2].Text);
                };
                //0
                ENCabecera_Compra compra = new ENCabecera_Compra(usuario, fecha, precioTotal);
                compra.createCabecera_Compra();
                // Falta insertar lineas, si no puedo coger id_videojuego sacarlo por mi cuenta con el usuario buscando su cesta
                int cantidad = 1;
                foreach (GridViewRow row in cestaTable.Rows)
                {
                    double importe = Convert.ToDouble(row.Cells[2].Text);
                    ENVideojuego videojuego = new ENVideojuego();
                    videojuego.Id = 1;
                    ENLinea_Compra linea = new ENLinea_Compra(cantidad, importe, videojuego);
                    int idcabecera = 1; //crear variable global y después de los insert ajustar esto y no tocar más la BBDD
                    linea.createLinea_Compra(idcabecera);
                    idcabecera++;

                };
                Response.Redirect("ThankYouPage.aspx");
                //
                //ENLinea_Compra lineas = new ENLinea_Compra();

            }
            }
        }
}

