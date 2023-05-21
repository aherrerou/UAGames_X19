<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicia_Sesion.aspx.cs" Inherits="web.Inicia_Sesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="registro_inicio">
            <h1>Iniciar sesión</h1>
            Nick&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TNick" runat="server"></asp:TextBox> 
            <br />
            Password&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="BBuscar" runat="server" Text="Entrar" OnClick="Leer"/>
            <br />
            <asp:Label ID="LResultado" runat="server" Text =" " />&nbsp;
            <asp:RequiredFieldValidator ID="RequiredNick" runat="server" ErrorMessage=" * Usuario obligatorio" ControlToValidate="TNick">
            </asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" ErrorMessage=" * Contraseña obligatoria" ControlToValidate="TPassword">
            </asp:RequiredFieldValidator>
        </div>
    </main>
</asp:Content>
