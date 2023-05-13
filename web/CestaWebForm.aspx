<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CestaWebForm.aspx.cs" Inherits="web.CestaWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
  
<main>
        <div class="showGrid">
            <h2>Cesta</h2>
            <asp:GridView ID="cestaTable" runat="server" CssClass="grid" AutoGenerateColumns="False"
                DataKeyNames="videojuegoID" PageSize="5" AllowPaging="True"
                EmptyDataText="Ups, no se ha encontrado nada en la cesta."
                OnPageIndexChanging="changePageCestaTable"
                OnRowEditing="clickRowEditCesta"
                OnRowCancelingEdit="clickRowCancelCesta"
                OnRowUpdating="clickRowUpdateCesta"
                OnRowDeleting="clickRowDeleteCesta">

                <Columns>
                    <asp:BoundField DataField="videojuegoID" HeaderText="VideojuegoID" ReadOnly="True" SortExpression="VideojuegoID" />
                    <asp:BoundField DataField="usuarioID" HeaderText="usuarioID" SortExpression="usuarioID" />
                    <asp:BoundField DataField="titulo" HeaderText="Titulo" SortExpression="Titulo" />
                    <asp:CommandField HeaderText="Acciones" ButtonType="Image" CancelImageUrl="~/assets/imagenes/iconos/cancel.png" EditImageUrl="~/assets/imagenes/iconos/edit.png"
                        ShowEditButton="True" ShowDeleteButton="True" ShowCancelButton="True" UpdateImageUrl="~/assets/imagenes/iconos/check.png"
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

        </div>
 </main>           


</asp:Content>
