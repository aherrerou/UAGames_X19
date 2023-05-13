<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminVideojuegos.aspx.cs" Inherits="web.AdminVideojuegos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
        <div class="container bg-light overflow-auto" style="min-height:599px;">
           <div class="row">
            <div class="col-md-2">
                <h2 class="text-primary">Videojuegos</h2>
            </div>
            <div class="col-md-7 m-md-3">
                <!--Filtros-->
                <div class="row">


                    <div class="col">
                        <!--Barar busqueda por nombre-->
                        <asp:TextBox ID="filtroTitulo" runat="server" placeholder="Videojuego..." value="" CssClass="mb-2" />
                        <!--Precio-->
                        Precio:
                    <asp:TextBox ID="filtroPrecio" runat="server" type="number" min="0" value="0" CssClass="mb-2"></asp:TextBox>

                    </div>
                    <div class="col">
                        <!--DropDown productora-->
                        <asp:DropDownList ID="filtroProductora" AutoPostBack="false" runat="server" CssClass="mb-2">
                            <Items>
                                <asp:ListItem Text="Productora" Value="0" />
                            </Items>
                        </asp:DropDownList>
                        <!--DropDown categoria-->
                        <asp:DropDownList ID="filtroCategoria" AutoPostBack="false" runat="server" CssClass="mb-2">
                            <Items>
                                <asp:ListItem Text="Categoria" Value="0" />
                            </Items>
                        </asp:DropDownList>
                    </div>
                    <div class="col">
                        <!--Fecha lanzamiento-->
                        <asp:TextBox ID="filtroFecha" runat="server" type="date" CssClass="mb-2" value=""></asp:TextBox>
                        <!--Plataforma-->
                    <asp:TextBox ID="filtroPlataforma" runat="server" PlaceHolder="Plataforma..." value="" CssClass="mb-2"></asp:TextBox>
                    </div>
                    <div class="col">

                        <!--Boton busqueda-->
                        <asp:Button CssClass="btn btn-primary" ID="filtros" Text="Filtrar" runat="server" OnClick="filtrarOnClick" />
                        <asp:Button CssClass="btn btn-danger mt-3" ID="resetFiltros" Text="Eliminar filtros" runat="server" OnClick="resetFiltrosOnClick" />

                    </div>

                </div>





                <div class="col-md-3">
                    <asp:Label ID="msgSalida" runat="server" CssClass="text-white" Text=""></asp:Label>
                </div>
            </div>
        </div>
            <div class="table-responsive">
                <asp:GridView ID="videojuegoTable" runat="server" CssClass="text-primary" AutoGenerateColumns="False" BorderStyle="None" BackColor="White" BorderWidth="2px"
                DataKeyNames="id" PageSize="5" AllowPaging="True" AllowSorting="true" OnSorting="VideojuegosTable_Sorting" CellPadding="5"
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
                <FooterStyle BackColor="White" ForeColor="#0d6efd" />
            <HeaderStyle BackColor="#0d6efd" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Font-Underline="false" />
                <PagerStyle BackColor="White" ForeColor="#0d6efd" HorizontalAlign="Center" />
                <RowStyle ForeColor="#0d6efd" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            </div>
            
            <br />
            <div>
                <h2>Crear videojuego</h2>
                <asp:Label ID="msgSalidaCrear" CssClass="text-white" runat="server" Text=""></asp:Label>
            </div>
            <div class="crearFlex">
                <div class="flexIzq">
                    Titulo:
            <asp:TextBox ID="nuevoTitulo" runat="server"></asp:TextBox>
                    Fecha lanzamiento:
            <asp:TextBox ID="nuevaFechaLanzamiento" runat="server" type="date"></asp:TextBox>
                    Productora:
            <asp:DropDownList ID="productorasList" AutoPostBack="false" runat="server" />
                    Categoria:
                    <asp:DropDownList ID="categoriasList" AutoPostBack="false" runat="server" />
                </div>
                <div class="flexDer">
                    Precio:
                    <asp:TextBox ID="nuevoPrecio" runat="server"></asp:TextBox>
                    Plataforma:
                    <asp:TextBox ID="nuevaPlataforma" runat="server"></asp:TextBox>
                    Descripcion:
                    <asp:TextBox ID="nuevaDescripcion" runat="server"></asp:TextBox>

                    <br />
                    <asp:Button ID="crearVideojuego" CssClass="btn btn-primary" Text="Crear" runat="server" OnClick="crearVideojuegoClick" />
                </div>

            </div>
        </div>
</asp:Content>
