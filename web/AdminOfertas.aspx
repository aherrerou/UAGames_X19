<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminOfertas.aspx.cs" Inherits="web.AdminOfertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
        <div class="container bg-light overflow-auto" style="min-height:599px;">
            <div class="row">
                <div class="col">
                    <h2 class="text-primary">Ofertas</h2>
                </div>
                <div class="col">
                     <asp:Label ID="msgSalida" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="table-responsive">
            <asp:GridView ID="ofertasTable" runat="server" CssClass="grid" AutoGenerateColumns="False"
                DataKeyNames="id" PageSize="5" AllowPaging="True" AllowSorting="true" OnSorting="OfertasTable_Sorting"
                EmptyDataText="Ups, no se han encontrado ofertas."
                OnPageIndexChanging="changePageOfertasTable"
                OnRowEditing="clickRowEditOferta"
                OnRowCancelingEdit="clickRowCancelOferta"
                OnRowUpdating="clickRowUpdateOferta"
                OnRowDeleting="clickRowDeleteOferta">

                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                    <asp:BoundField DataField="videojuego" HeaderText="Videojuego" SortExpression="videojuego" />
                    <asp:BoundField DataField="productora" HeaderText="Productora" SortExpression="productora" />
                    <asp:BoundField DataField="descuento" HeaderText="Descuento" SortExpression="descuento" />
                    <asp:BoundField DataField="fecha_inicio" HeaderText="Fecha Inicio" SortExpression="fecha_inicio" />
                    <asp:BoundField DataField="fecha_fin" HeaderText="Fecha Fin" SortExpression="fecha_fin" />
                    <asp:CommandField HeaderText="Acciones" ButtonType="Image" CancelImageUrl="~/assets/imagenes/iconos/cancel.png" EditImageUrl="~/assets/imagenes/iconos/edit.png"
                        ShowEditButton="True" ShowDeleteButton="True" ShowCancelButton="True" UpdateImageUrl="~/assets/imagenes/iconos/check.png"
                        DeleteImageUrl="~/assets/imagenes/iconos/trash.png">
                        <ControlStyle Height="20px" Width="20px"/>
                    </asp:CommandField>

                </Columns>
                <HeaderStyle CssClass="text-white bg-primary h4" Font-Bold="True" />
                <PagerSettings Mode="Numeric" Position="Bottom" PreviousPageText="True" />
                <PagerStyle HorizontalAlign="Center" CssClass="text-primary h5" />
                <EditRowStyle CssClass="text-primary" />
                <SelectedRowStyle CssClass="h1" Font-Bold="True" />
                <SortedAscendingHeaderStyle />
                <SortedDescendingHeaderStyle  />
            </asp:GridView>
            </div>
            <br />
            <br />

            <div>
                <h2>Crear oferta</h2>
                <asp:Label ID="msgSalidaCrear" runat="server" Text=""></asp:Label>
            </div>
            <div class="crearFlex">
                <div class="flexIzq">
                    Nombre:
            <asp:TextBox ID="nuevoNombre" runat="server"></asp:TextBox>
                    Fecha Inicio:
            <asp:TextBox ID="nuevaFechaInicio" runat="server" type="date"></asp:TextBox>
                    Fecha Fin:
            <asp:TextBox ID="nuevaFechaFin" runat="server" type="date"></asp:TextBox>
                    Productora:
            <asp:DropDownList ID="productorasList" AutoPostBack="True" OnSelectedIndexChanged="ProductoraSelectionChange" runat="server" />
                </div>
                <div class="flexDer">
                    Videojuego:
                    <asp:DropDownList ID="videojuegosList" AutoPostBack="True" runat="server" />
                    Descuento:
                    <asp:TextBox ID="nuevoDescuento" runat="server"></asp:TextBox>
                <br />
                <asp:Button id="crearOferta" Text="Crear" runat="server" OnClick="crearOfertaClick"/>
                </div>

            </div>
        </div>

</asp:Content>
