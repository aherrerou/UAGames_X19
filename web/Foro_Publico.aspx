<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Foro_Publico.aspx.cs" Inherits="web.Foro_Publico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="showGrid">
            <h1>Página de Foro</h1>
            <br />
            Selecciona el foro&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList runat="server" ID="DForo"></asp:DropDownList>
            <br />
            <asp:Button ID="BForo" runat="server" Text="Buscar Temas" OnClick="BuscarTemas"/>
            <br />
            <asp:Label ID="LTema" runat="server" Text ="Selecciona el tema del foro"  Visible="false"/>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList runat="server" ID="DTema" Visible="false"></asp:DropDownList>
            <br />
            <asp:Button ID="BBuscar" runat="server" Text="Buscar" OnClick="Buscar" Visible="false"/>
            <asp:GridView ID="GridView1" runat="server" CssClass="grid"></asp:GridView>
            <br />
            <h2>Hacer una publicación:</h2>
            <br />
            Texto: &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TTexto" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BPublicar" runat="server" Text="Publicar" OnClick="Publicar"/>
            <asp:Label ID="LResultado" runat="server" Text=" "></asp:Label>
        </div>
    </main>
</asp:Content>
