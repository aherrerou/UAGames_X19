<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminVideojuegos.aspx.cs" Inherits="web.AdminVideojuegos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="videojuegosGrid">
            <h2>Videojuegos</h2>
        <asp:GridView ID="videojuegoTable" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#0A2558"
            BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="1080px" DataKeyNames="id" PageSize="10" AllowPaging="True"
            EmptyDataText="Ups, no se han encontrado videojuegos."
            OnPageIndexChanging="changePageVideojuegosTable"
            OnRowEditing="clickRowEditVideojuego"
            OnRowCancelingEdit="clickRowCancelVideojuego"
            OnRowUpdating="clickRowUpdateVideojuego"
            OnRowDeleting="clickRowDeleteVideojuego">

            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="titulo" HeaderText="Titulo" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="productora" HeaderText="Productora" />
                <asp:BoundField DataField="categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="fechaLanzamiento" HeaderText="Fecha Lanzamiento" />
                <asp:BoundField DataField="precio" HeaderText="Precio" />
                <asp:BoundField DataField="plataforma" HeaderText="Plataforma" />
                <asp:BoundField DataField="image" HeaderText="Image URL" />
                <asp:CommandField ButtonType="Image" CancelImageUrl="~/assets/imagenes/iconos/cancel.png" EditImageUrl="~/assets/imagenes/iconos/edit.png"
                    ShowEditButton="True" ShowDeleteButton="True" UpdateImageUrl="~/assets/imagenes/iconos/save.png"
                    DeleteImageUrl="~/assets/imagenes/iconos/erase.png">
                    <ControlStyle Height="20px" Width="20px" />
                </asp:CommandField>

            </Columns>
            <FooterStyle BackColor="#0A2558" ForeColor="#fff" />
            <HeaderStyle BackColor="#0A2558" Font-Bold="True" ForeColor="#fff" />
            <PagerStyle BackColor="#0A2558" ForeColor="#fff" HorizontalAlign="Left" />
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
