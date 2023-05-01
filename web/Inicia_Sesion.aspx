<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicia_Sesion.aspx.cs" Inherits="web.Inicia_Sesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <h1>Iniciar sesión</h1>
    Nick&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TNick" runat="server"></asp:TextBox>
    <br />
    Password&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TPassword" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="BBuscar" runat="server" Text="Entrar"/>
    <br />
    <br />
    <asp:Label ID="LResultado" runat="server" Text =" " />&nbsp;
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
</asp:Content>
