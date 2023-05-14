<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reseña.aspx.cs" Inherits="web.Reseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="showGrid">
            <h2>Reseñas</h2>
            <asp:GridView ID="reviewTable" runat="server" CssClass="grid" AutoGenerateColumns="False"
               DataKeyNames="id" PageSize="5" AllowPaging="True"
                EmptyDataText="Ups, parece que no tienes ninguna reseña.">
                <Columns>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="videojuego" HeaderText="Videojuego" SortExpression="Videojuego" />
                    <asp:BoundField DataField="usuario" HeaderText="usuario" SortExpression="Usuario" />
                    <asp:BoundField DataField="puntuacion" HeaderText="puntuacion" SortExpression="Puntuacion" />
                    <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="Fecha" />
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
            <br />
            <br />
        </div>
    </main>
</asp:Content>