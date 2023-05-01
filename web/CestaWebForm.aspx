<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CestaWebForm.aspx.cs" Inherits="web.CestaWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div>
        <p>
            UsuarioId: &nbsp;<asp:TextBox ID="text_usuario_id" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>

        <p>
            VideojuegoId: &nbsp;<asp:TextBox ID="text_videojuego_id" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>

        <p>
            fecha: &nbsp;<asp:TextBox ID="text_fecha" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>

        <asp:Button text="Crear Cesta" ID="buttom_Crear" runat="server" />
        <asp:Button text="Mostrar Cestas" ID="buttom_cat" runat="server" />

    </div>
</asp:Content>
