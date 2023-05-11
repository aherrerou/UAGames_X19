<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminVideojuegos.aspx.cs" Inherits="web.AdminVideojuegos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="showGrid">
            <div class="row">
                <div class="col">
                    <h2>Videojuegos</h2>
                </div>
                <div class="col">
                     <asp:Label ID="msgSalida" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <asp:GridView ID="videojuegoTable" runat="server" CssClass="grid" AutoGenerateColumns="False"
                DataKeyNames="id" PageSize="5" AllowPaging="True"
                EmptyDataText="Ups, no se han encontrado videojuegos."
                OnPageIndexChanging="changePageVideojuegosTable"
                OnRowEditing="clickRowEditVideojuego"
                OnRowCancelingEdit="clickRowCancelVideojuego"
                OnRowUpdating="clickRowUpdateVideojuego"
                OnRowDeleting="clickRowDeleteVideojuego">

                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="Id"/>
                    <asp:BoundField DataField="titulo" HeaderText="Titulo" SortExpression="Titulo" ControlStyle-Width="50px" />
                    <asp:BoundField DataField="productora" HeaderText="Productora" SortExpression="Productora" ControlStyle-Width="50px" />
                    <asp:BoundField DataField="categoria" HeaderText="Categoria" SortExpression="Categoria" ControlStyle-Width="50px" />
                    <asp:BoundField DataField="fecha_lanzamiento" HeaderText="Fecha Lanzamiento" SortExpression="Fecha" ControlStyle-Width="50px" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="Precio" ControlStyle-Width="50px" />
                    <asp:BoundField DataField="plataforma" HeaderText="Plataforma" SortExpression="Platafoma" ControlStyle-Width="50px" />
                    <asp:ImageField DataImageUrlField="imagen" HeaderText="Imagen" NullDisplayText="X" ControlStyle-Width="50px">
                    </asp:ImageField>
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" SortExpression="Descripcion" ControlStyle-Width="50px" />
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
                <EditRowStyle CssClass="gridViewEditRow" />
            </asp:GridView>
            <br />
            <h2>Crear videojuego</h2>
            <div class="crearFlex">
                <div class="flexIzq">
                    Titulo:
            <asp:TextBox ID="nuevoTitulo" runat="server"></asp:TextBox>
                    Fecha lanzamiento:
            <asp:TextBox ID="nuevaFechaLanzamiento" runat="server"></asp:TextBox>
                    Productora:
            <asp:DropDownList ID="productorasList" AutoPostBack="True" OnSelectedIndexChanged="ProductoraSelectionChange" runat="server" />
                    Categoria:
                    <asp:DropDownList ID="categoriasList" AutoPostBack="True" OnSelectedIndexChanged="CategoriaSelectionChange" runat="server" />
                </div>
                <div class="flexDer">
                    Precio:
                    <asp:TextBox ID="nuevoPrecio" runat="server"></asp:TextBox>
                    Plataforma:
                    <asp:TextBox ID="nuevoPlataforma" runat="server"></asp:TextBox>
                    Descripcion:
                    <asp:TextBox ID="nuevaDescripcion" runat="server"></asp:TextBox>

                    <br />
                    <asp:Button ID="crearVideojuego" Text="Crear" runat="server" OnClick="crearVideojuegoClick" />
                </div>

            </div>




        </div>

    </main>
</asp:Content>
