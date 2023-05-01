<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Lista_Deseos.aspx.cs" Inherits="web.Lista_Deseos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <h1>Página de Lista de Deseos</h1>
    Id&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TId" runat="server"></asp:TextBox>
    <br />
    Nombre&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TNombre" runat="server"></asp:TextBox>
    <br />
    Descripción&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TDescripcion" runat="server"></asp:TextBox>
    <br />
    Id de usuario (WIP - usar usuario de la sesión actual)&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TUsuario" runat="server"></asp:TextBox>
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
    <asp:Label ID="LResultado" runat="server" Text =" " />&nbsp;
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
</asp:Content>