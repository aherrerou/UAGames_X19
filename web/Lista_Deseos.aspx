<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Lista_Deseos.aspx.cs" Inherits="web.Lista_Deseos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="showGrid">
            <h1><asp:Label ID="LTitulo" runat="server" Text ="Administrar Listas de Deseos" /></h1>
            <asp:Label ID="LId" runat="server" Text ="Id" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TId" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LNombre" runat="server" Text ="Nombre" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LDescripcion" runat="server" Text ="Descripción" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TDescripcion" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LUsuario" runat="server" Text ="Id de usuario" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TUsuario" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BLeer_F" runat="server" Text="Leer" OnClick="Leer"/>
            <asp:Button ID="BLeerP_F" runat="server" Text="Leer Primero" OnClick="LeerPrimero"/>
            <asp:Button ID="BLeerA_F" runat="server" Text="Leer Anterior" OnClick="LeerAnterior"/>
            <asp:Button ID="BLeerS_F" runat="server" Text="Leer Siguiente" OnClick="LeerSiguiente"/>
            <asp:Button ID="BCrear_F" runat="server" Text="Crear" OnClick="Crear"/>
            <asp:Button ID="BActualizar_F" runat="server" Text="Actualizar" OnClick="Actualizar"/>
            <asp:Button ID="BBorrar_F" runat="server" Text="Borrar" OnClick="Borrar"/>
            <br />
            <asp:Label ID="LResultado" runat="server" Text =" " />&nbsp;
            <asp:RequiredFieldValidator ID="RequiredUsuario" FieldToValidate="TUsuario" runat="server" ErrorMessage="* Usuario obligatorio"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredId" FieldToValidate="TId" runat="server" ErrorMessage="* Id de lista obligatoria"></asp:RequiredFieldValidator>
            <h2><asp:Label ID="LListado" runat="server" Text ="Listado de listas de deseos" /></h2>
            <asp:GridView ID="GridView1" runat="server" CssClass="grid"></asp:GridView>
        </div>
    </main>
</asp:Content>