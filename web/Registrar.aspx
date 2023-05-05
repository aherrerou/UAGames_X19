<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="web.Registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="registro_inicio">
            <h1>Registrar nuevo usuario</h1>
            Nick&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TNick" runat="server"></asp:TextBox>
            Nombre&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TNombre" runat="server"></asp:TextBox>
            Apellidos&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TApellidos" runat="server"></asp:TextBox>
            Email&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TEmail" runat="server"></asp:TextBox>
            Fecha de nacimiento (yyyy-MM-dd)&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TFecha" runat="server"></asp:TextBox>
            Teléfono&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TTelefono" runat="server"></asp:TextBox>
            <br />
            <br />
            Password&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TPassword" runat="server"></asp:TextBox>
            Repite Password&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TRepitePassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="BCrear" runat="server" Text="Crear" OnClick="Crear"/>
            <br />
            <asp:Label ID="LResultado" runat="server" Text =" " />&nbsp;
        </div>
    </main>
</asp:Content>
