<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="web.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="showGrid">
            <h1>Página de Usuarios</h1>
            Id&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TId" runat="server"></asp:TextBox>
            <br />
            Nick&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TNick" runat="server"></asp:TextBox>
            <br />
            Nombre&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TNombre" runat="server"></asp:TextBox>
            <br />
            Apellidos&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TApellidos" runat="server"></asp:TextBox>
            <br />
            Email&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TEmail" runat="server"></asp:TextBox>
            <br />
            Teléfono&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TTelefono" runat="server"></asp:TextBox>
            <br />
            Fecha de nacimiento (yyyy-MM-dd)&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TFecha" runat="server"></asp:TextBox>
            <br />
            Rol&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TRol" runat="server"></asp:TextBox>
            <br />
            Password&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BLeer_F" runat="server" Text="Leer" OnClick="Leer"/>
            <asp:Button ID="BLeerP_F" runat="server" Text="Leer Primero" OnClick="LeerPrimero"/>
            <asp:Button ID="BLeerA_F" runat="server" Text="Leer Anterior" OnClick="LeerAnterior"/>
            <asp:Button ID="BLeerS_F" runat="server" Text="Leer Siguiente" OnClick="LeerSiguiente"/>
            <asp:Button ID="BCrear_F" runat="server" Text="Crear" OnClick="Crear"/>
            <asp:Button ID="BActualizar_F" runat="server" Text="Actualizar" OnClick="Actualizar"/>
            <asp:Button ID="BBorrar_F" runat="server" Text="Borrar" OnClick="Borrar"/>
            <asp:RequiredFieldValidator ID="RequiredNick" FieldToValidate="TNick" runat="server" ErrorMessage="* Nick obligatorio"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredNombre" FieldToValidate="TNombre" runat="server" ErrorMessage="* Nombre sin rellenar"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredApellidos" FieldToValidate="TApellidos" runat="server" ErrorMessage="* Apellidos sin rellenar"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredEmail" FieldToValidate="TEmail" runat="server" ErrorMessage="* Email sin rellenar"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredTelefono" FieldToValidate="TTelefono" runat="server" ErrorMessage="* Teléfono sin rellenar"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFecha" FieldToValidate="TFecha" runat="server" ErrorMessage="* Fecha sin rellenar"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredRol" FieldToValidate="TRol" runat="server" ErrorMessage="* Rol sin rellenar"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredPassword" FieldToValidate="TPassword" runat="server" ErrorMessage="* Password sin rellenar"></asp:RequiredFieldValidator>
            <asp:Label ID="LResultado" runat="server" Text =" " />&nbsp;
            <h2>Listado de usuarios</h2>
            <asp:GridView ID="GridView1" runat="server" CssClass="grid"></asp:GridView>
        </div>
    </main>
</asp:Content>

