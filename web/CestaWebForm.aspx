<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CestaWebForm.aspx.cs" Inherits="web.CestaWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
  
<main>
        <div class="showGrid">
            <center>
                <h2>Tu cesta</h2>
            </center>
            <asp:GridView ID="cestaTable" runat="server" CssClass="grid" AutoGenerateColumns="False"
                DataKeyNames="titulo" PageSize="5" AllowPaging="True"
                EmptyDataText="Ups, no se ha encontrado nada en la cesta."
                OnPageIndexChanging="changePageCestaTable"
                OnRowEditing="clickRowEditCesta"
                OnRowCancelingEdit="clickRowCancelCesta"
                OnRowUpdating="clickRowUpdateCesta"
                OnRowDeleting="clickRowDeleteCesta">

                <Columns>
                    <asp:BoundField DataField="titulo" HeaderText="Titulo" ReadOnly="True" SortExpression="Titulo" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" ReadOnly="True" SortExpression="Fecha" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" ReadOnly="True" SortExpression="Precio" />


                    <asp:CommandField HeaderText=" " ButtonType="Image" CancelImageUrl="~/assets/imagenes/iconos/cancel.png" EditImageUrl="~/assets/imagenes/iconos/edit.png"
                        ShowEditButton="false" ShowDeleteButton="True" ShowCancelButton="True" UpdateImageUrl="~/assets/imagenes/iconos/check.png"
                        DeleteImageUrl="~/assets/imagenes/iconos/trash.png">
                        <ControlStyle Height="20px" Width="20px" CssClass="botones" />
                    </asp:CommandField>

                </Columns>
                <FooterStyle BackColor="#0A2558" ForeColor="#fff" />
                <HeaderStyle BackColor="#0A2558" Font-Bold="True" ForeColor="#fff" />
                <PagerSettings Mode="Numeric" Position="Bottom" PreviousPageText="True" />
                <PagerStyle HorizontalAlign="Center" ForeColor="#0A2558" />
                <RowStyle ForeColor="#0A2558" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            

            <div class="precioTotalContainer">
                <div class="precioTotalBox">
                    <center>                   
                        Total cesta:<asp:Label ID="precioTotalLabel" runat="server" Style="margin-left: 60px;"></asp:Label>
                    </center>
                </div>
            </div>

            <div>
                <center>
                    <asp:Button id="comprar" Text="Comprar" runat="server" OnClick="ComprarClick"/>
                </center>
            </div>
        </div>
 </main>

<style>
    .precioTotalContainer {
  margin-right: 20px;
    background-color: #dddddd;
    padding: 10px;
    border-radius: 5px;
    max-width: 300px;
    margin: 20px auto;
    }

.precioTotalBox {
  display: inline-block;
  padding: 10px;
  background-color: #f2f2f2;
  border: 1px solid #ddd;
  border-radius: 5px;

}

#precioTotalLabel {
  color: #333;
  font-size: 24px;
  font-weight: bold;
  text-align: center;
}
</style>

    
</asp:Content>
