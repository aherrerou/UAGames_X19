<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminVideojuegos.aspx.cs" Inherits="web.AdminVideojuegos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
        <div class="container bg-light overflow-auto" style="min-height:599px;">
            <div class="row">
                <div class="col">
                    <h2 class="text-primary">Videojuegos</h2>
                </div>
                <div class="col">
                    <!--Filtros-->
                </div>
                <div class="col">
                     <asp:Label ID="msgSalida" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="videojuegoTable" runat="server" CssClass="text-primary" AutoGenerateColumns="False"
                DataKeyNames="id" PageSize="5" AllowPaging="True" AllowSorting="true" OnSorting="VideojuegosTable_Sorting"
                EmptyDataText="Ups, no se han encontrado videojuegos."
                OnPageIndexChanging="changePageVideojuegosTable"
                OnRowEditing="clickRowEditVideojuego"
                OnRowCancelingEdit="clickRowCancelVideojuego"
                OnRowUpdating="clickRowUpdateVideojuego"
                OnRowDeleting="clickRowDeleteVideojuego"
                gridlines="Horizontal">

                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="id"/>
                    <asp:BoundField DataField="titulo" HeaderText="Titulo" SortExpression="titulo" />
                    <asp:BoundField DataField="productora" HeaderText="Productora" SortExpression="productora" />
                    <asp:BoundField DataField="categoria" HeaderText="Categoria" SortExpression="categoria" />
                    <asp:BoundField DataField="fecha_lanzamiento" HeaderText="Fecha Lanzamiento" SortExpression="fecha_lanzamiento"  />
                    <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio"/>
                    <asp:BoundField DataField="plataforma" HeaderText="Plataforma" SortExpression="plataforma" />
                    <asp:ImageField DataImageUrlField="imagen" HeaderText="Imagen" NullDisplayText="X" ControlStyle-Width="50px">
                    </asp:ImageField>
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
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
            <div>
                <h2>Crear videojuego</h2>
                <asp:Label ID="msgSalidaCrear" runat="server" Text=""></asp:Label>
            </div>
            <div class="crearFlex">
                <div class="flexIzq">
                    Titulo:
            <asp:TextBox ID="nuevoTitulo" runat="server"></asp:TextBox>
                    Fecha lanzamiento:
            <asp:TextBox ID="nuevaFechaLanzamiento" runat="server" type="date"></asp:TextBox>
                    Productora:
            <asp:DropDownList ID="productorasList" AutoPostBack="True" runat="server" />
                    Categoria:
                    <asp:DropDownList ID="categoriasList" AutoPostBack="True" runat="server" />
                </div>
                <div class="flexDer">
                    Precio:
                    <asp:TextBox ID="nuevoPrecio" runat="server"></asp:TextBox>
                    Plataforma:
                    <asp:TextBox ID="nuevaPlataforma" runat="server"></asp:TextBox>
                    Descripcion:
                    <asp:TextBox ID="nuevaDescripcion" runat="server"></asp:TextBox>

                    <br />
                    <asp:Button ID="crearVideojuego" Text="Crear" runat="server" OnClick="crearVideojuegoClick" />
                </div>

            </div>
        </div>
</asp:Content>
