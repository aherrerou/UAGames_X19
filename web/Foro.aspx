<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Foro.aspx.cs" Inherits="web.Foro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <h1>Página de foros</h1>
        <h2>Leer o modificar lista de foros</h2>
        Id&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TId_F" runat="server"></asp:TextBox>
        <br />
        Nombre&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TNombre" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BLeer_F" runat="server" Text="Leer"/>
        <asp:Button ID="BLeerP_F" runat="server" Text="Leer Primero"/>
        <asp:Button ID="BLeerA_F" runat="server" Text="Leer Anterior"/>
        <asp:Button ID="BLeerS_F" runat="server" Text="Leer Siguiente"/>
        <asp:Button ID="BCrear_F" runat="server" Text="Crear"/>
        <asp:Button ID="BActualizar_F" runat="server" Text="Actualizar"/>
        <asp:Button ID="BBorrar_F" runat="server" Text="Borrar"/>
        <br />
        <br />
        <asp:Label ID="LResultado_F" runat="server" Text =" " />&nbsp;

        <h2>Leer o modificar lista de temas</h2>
        Id&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TId_T" runat="server"></asp:TextBox>
        <br />
        Título&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TTitulo" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BLeer_T" runat="server" Text="Leer"/>
        <asp:Button ID="BLeerP_T" runat="server" Text="Leer Primero"/>
        <asp:Button ID="BLeerA_T" runat="server" Text="Leer Anterior"/>
        <asp:Button ID="BLeerS_T" runat="server" Text="Leer Siguiente"/>
        <asp:Button ID="BCrear_T" runat="server" Text="Crear"/>
        <asp:Button ID="BActualizar_T" runat="server" Text="Actualizar"/>
        <asp:Button ID="BBorrar_T" runat="server" Text="Borrar"/>
        <br />
        <br />
        <asp:Label ID="LResultado_T" runat="server" Text =" " />&nbsp;

        <h2>Leer o modificar lista de publicaciones</h2>
        Id&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TId_P" runat="server"></asp:TextBox>
        <br />
        Texto&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TTexto" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BLeer_P" runat="server" Text="Leer"/>
        <asp:Button ID="BLeerP_P" runat="server" Text="Leer Primero"/>
        <asp:Button ID="BLeerA_P" runat="server" Text="Leer Anterior"/>
        <asp:Button ID="BLeerS_P" runat="server" Text="Leer Siguiente"/>
        <asp:Button ID="BCrear_P" runat="server" Text="Crear"/>
        <asp:Button ID="BActualizar_P" runat="server" Text="Actualizar"/>
        <asp:Button ID="BBorrar_P" runat="server" Text="Borrar"/>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text =" " />&nbsp;
    
        <br />
        <br />
        <h2>Listado de publicaciones</h2>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>