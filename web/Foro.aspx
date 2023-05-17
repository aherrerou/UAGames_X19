<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Foro.aspx.cs" Inherits="web.Foro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="showGrid">
            <h1>Página de foros</h1>
            <h2>Leer o modificar lista de foros</h2>
            Id&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TId_F" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            Nombre&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TNombre" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BLeer_F" runat="server" Text="Leer" OnClick="Leer" />
            <asp:Button ID="BLeerP_F" runat="server" Text="Leer Primero" OnClick="LeerPrimero" />
            <asp:Button ID="BLeerA_F" runat="server" Text="Leer Anterior" OnClick="LeerAnterior" />
            <asp:Button ID="BLeerS_F" runat="server" Text="Leer Siguiente" OnClick="LeerSiguiente" />
            <asp:Button ID="BCrear_F" runat="server" Text="Crear" OnClick="Crear" />
            <asp:Button ID="BActualizar_F" runat="server" Text="Actualizar" OnClick="Actualizar" />
            <asp:Button ID="BBorrar_F" runat="server" Text="Borrar" OnClick="Borrar" />
            <br />
            <asp:Label ID="LResultado_F" runat="server" Text=" " />&nbsp;
            <asp:RequiredFieldValidator ID="RequiredForoId" FieldToValidate="TId_F" runat="server" ErrorMessage="Id obligatoria"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredForoNombre" FieldToValidate="TNombre" runat="server" ErrorMessage="Nombre obligatorio"></asp:RequiredFieldValidator>
            <h2>Leer o modificar lista de temas</h2>
            Id&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TId_T" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            Título&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TTitulo" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BLeer_T" runat="server" Text="Leer" OnClick="LeerT" />
            <asp:Button ID="BLeerP_T" runat="server" Text="Leer Primero" OnClick="LeerPrimeroT" />
            <asp:Button ID="BLeerA_T" runat="server" Text="Leer Anterior" OnClick="LeerAnteriorT" />
            <asp:Button ID="BLeerS_T" runat="server" Text="Leer Siguiente" OnClick="LeerSiguienteT" />
            <asp:Button ID="BCrear_T" runat="server" Text="Crear" OnClick="CrearT" />
            <asp:Button ID="BActualizar_T" runat="server" Text="Actualizar" OnClick="ActualizarT" />
            <asp:Button ID="BBorrar_T" runat="server" Text="Borrar" OnClick="BorrarT" />
            <br />
            <asp:Label ID="LResultado_T" runat="server" Text=" " />&nbsp;
            <asp:RequiredFieldValidator ID="RequiredTemaId" FieldToValidate="TId_T" runat="server" ErrorMessage="Id obligatoria"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredTemaTitulo" FieldToValidate="TTitulo" runat="server" ErrorMessage="Título obligatoria"></asp:RequiredFieldValidator>
            <h2>Leer o modificar lista de publicaciones</h2>
            Id&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TId_P" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            Texto&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TTexto" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            Id de usuario&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TUsuario" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BLeer_P" runat="server" Text="Leer" OnClick="LeerP" />
            <asp:Button ID="BLeerP_P" runat="server" Text="Leer Primero" OnClick="LeerPrimeroP" />
            <asp:Button ID="BLeerA_P" runat="server" Text="Leer Anterior" OnClick="LeerAnteriorP" />
            <asp:Button ID="BLeerS_P" runat="server" Text="Leer Siguiente" OnClick="LeerSiguienteP" />
            <asp:Button ID="BCrear_P" runat="server" Text="Crear" OnClick="CrearP" />
            <asp:Button ID="BActualizar_P" runat="server" Text="Actualizar" OnClick="ActualizarP" />
            <asp:Button ID="BBorrar_P" runat="server" Text="Borrar" OnClick="BorrarP" />
            <br />
            <asp:Label ID="LResultado_P" runat="server" Text=" " />&nbsp;
            <asp:RequiredFieldValidator ID="RequiredPubliId" FieldToValidate="TId_P" runat="server" ErrorMessage="Id obligatoria"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredPubliText" FieldToValidate="TText" runat="server" ErrorMessage="Texto obligatorio"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredUsuario" FieldToValidate="TUsuario" runat="server" ErrorMessage="Id de usuario"></asp:RequiredFieldValidator>
            <h2>Listado de publicaciones</h2>
            <asp:GridView ID="GridView1" runat="server" CssClass="grid">
                <asp:ImageButton ID="BGridBorrar" runat="server" ImageAlign="Middle" ImageUrl="|DataDirectory|\web\assets\imagenes\iconos\trash.png" OnClick="GridBorrar" CommandArgument='<%# Eval("ID_Publicación") %>''></asp:ImageButton>
            </asp:GridView>
        </div>
    </main>
</asp:Content>
