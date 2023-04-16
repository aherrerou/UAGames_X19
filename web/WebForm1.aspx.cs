using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ENCabecera_Compra cabecera = new ENCabecera_Compra();
            cabecera.createCabecera_Compra();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ENCabecera_Compra cabecera = new ENCabecera_Compra();
            cabecera.deleteCabecera_Compra();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ENCabecera_Compra cabecera = new ENCabecera_Compra();
            cabecera.updateCabecera_Compra();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ENCabecera_Compra cabecera = new ENCabecera_Compra();
            cabecera.id = Int32.Parse(TextBox1.Text);
            if (cabecera.readCabecera_Compra())
            {
                Resultado.Text = cabecera.totalCompra.ToString();
            }
            else
            {
                Resultado.Text = "No se ha encontrado el pedido";
            }

        }
    }
}