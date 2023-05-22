<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicia_Sesion.aspx.cs" Inherits="web.Inicia_Sesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="container bg-light overflow-auto" style="min-height:625px;">
        <div class="registro_inicio">
            <h1>Iniciar sesión</h1>
            Nick:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TNick" runat="server"></asp:TextBox> 
            <asp:RequiredFieldValidator ID="RequiredNick" Enabled="false" runat="server" ErrorMessage=" * Usuario obligatorio" ControlToValidate="TNick">
            </asp:RequiredFieldValidator>
            <br />
            Password:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TPassword" runat="server" type="password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredPassword" Enabled="false" runat="server" ErrorMessage=" * Contraseña obligatoria" ControlToValidate="TPassword">
            </asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="BBuscar" CssClass="btn btn-primary" runat="server" Text="Entrar" OnClick="Leer"/>
            <br />
            <asp:Label ID="LResultado" runat="server" Text =" " />
        </div>
    </div>
</asp:Content>
