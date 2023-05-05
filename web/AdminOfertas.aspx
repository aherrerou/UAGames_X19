<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminOfertas.aspx.cs" Inherits="web.AdminOfertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="showGrid">
            <h2>Ofertas</h2>
            <asp:GridView ID="ofertasTable" runat="server" CssClass="grid" AutoGenerateColumns="False"
                DataKeyNames="id" PageSize="5" AllowPaging="True"
                EmptyDataText="Ups, no se han encontrado ofertas."
                OnPageIndexChanging="changePageOfertasTable"
                OnRowEditing="clickRowEditOferta"
                OnRowCancelingEdit="clickRowCancelOferta"
                OnRowUpdating="clickRowUpdateOferta"
                OnRowDeleting="clickRowDeleteOferta">

                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="videojuego" HeaderText="Videojuego" SortExpression="Videojuego" />
                    <asp:BoundField DataField="productora" HeaderText="Productora" SortExpression="Productora" />
                    <asp:BoundField DataField="descuento" HeaderText="Descuento" SortExpression="Descuento" />
                    <asp:BoundField DataField="fecha_inicio" HeaderText="Fecha Inicio" SortExpression="FechaInicio" />
                    <asp:BoundField DataField="fecha_fin" HeaderText="Fecha Fin" SortExpression="FechaFin" />
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

            <h2>Crear oferta</h2>
            <div class="crearFlex">
                <div class="flexIzq">
                    Nombre:
            <asp:TextBox ID="nuevoNombre" runat="server"></asp:TextBox>
                    Fecha Inicio:
            <asp:TextBox ID="nuevaFechaInicio" runat="server"></asp:TextBox>
                    Fecha Fin:
            <asp:TextBox ID="nuevaFechaFin" runat="server"></asp:TextBox>
                    Productora:
                    <asp:TextBox ID="nuevaProductora" runat="server"></asp:TextBox>
            <!--<asp:DropDownList ID="productorasList" AutoPostBack="True" OnSelectedIndexChanged="ProductoraSelectionChange" runat="server" />-->
                </div>
                <div class="flexDer">
                    Videojuego:
                    <asp:TextBox ID="nuevoVideojuego" runat="server"></asp:TextBox>
                    Descuento:
                    <asp:TextBox ID="nuevoDescuento" runat="server"></asp:TextBox>
            <!--<asp:DropDownList ID="videojuegosList" AutoPostBack="True" OnSelectedIndexChanged="VideojuegoSelectionChange" runat="server" />-->
                <br />
                <asp:Button id="crearOferta" Text="Crear" runat="server" OnClick="crearOfertaClick"/>
                </div>

            </div>
        </div>


    </main>

</asp:Content>
