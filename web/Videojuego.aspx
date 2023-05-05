<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Videojuego.aspx.cs" Inherits="web.Videojuego" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="videojuegoDetalles">
            <div class="imagenVideojuego">
                <asp:Image ID="videojuegoImagen" runat="server" CssClass="imagenVid" />
            </div>
            <div class="infoVideojuego">
                <asp:Label ID="tituloLabel" runat="server"></asp:Label>
                <hr />
                <div>
                    <h5>Productora: </h5>
                    <asp:LinkButton ID="productoraLink" runat="server" />
                </div>
                <div>
                    <h5>Categoria: </h5>
                    <asp:LinkButton ID="categoriaLink" runat="server" />
                </div>
                <div>
                    <h5>Fecha lanzamiento: </h5>
                    <asp:Label ID="fechaLabel" runat="server" />
                </div>
                <div>
                    <h5>Plataforma: </h5>
                    <asp:Label ID="plataformaLabel" runat="server" />
                </div>
                <div>
                    <h5>Descripcion: </h5>
                    <asp:Label ID="descripcionLabel" runat="server" />
                </div>
                <div>
                    <h5>Precio: </h5>
                    <asp:Label ID="precioLabel" runat="server" />
                </div>
                <!--BOTONES-->
            </div>
        </div>
    </main>
</asp:Content>
