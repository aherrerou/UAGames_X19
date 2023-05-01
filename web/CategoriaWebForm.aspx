<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CategoriaWebForm.aspx.cs" Inherits="web.CategoriaWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <div>
        <p>
            id: &nbsp;<asp:TextBox ID="text_id" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>

        <p>
            Nombre: &nbsp;<asp:TextBox ID="text_nombre" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>

        <p>
            Descripción: &nbsp;<asp:TextBox ID="text_descripcion" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>

        <asp:Button text="Crear Categoría" ID="buttom_Crear" runat="server" />
        <asp:Button text="Mostrar Categorías" ID="buttom_cat" runat="server" />

    </div>

</asp:Content>
