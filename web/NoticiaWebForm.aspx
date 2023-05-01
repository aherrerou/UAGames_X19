<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NoticiaWebForm.aspx.cs" Inherits="web.ProductoraWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div>
       <div>
        <p>
            Id: &nbsp;<asp:TextBox ID="text_id" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>
        <p>
            Titulo: &nbsp;<asp:TextBox ID="text_titulo" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>
           <p>
            Fecha de publicación : &nbsp;<asp:TextBox ID="Text_fecha_public" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>
        <p>
            Contenido: &nbsp;<asp:TextBox ID="text_contenido" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>
           
           <p>
            ProductoraId: &nbsp;<asp:TextBox ID="text_productora_id" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>
           <asp:Label ID="outputMsg" runat="server"></asp:Label><br />
            <asp:Button text="Crear"  ID="buttom_Crear" runat="server" />
           <asp:Button text="Mostrar todas las productoras"  ID="bt_Mostrar" runat="server" />
    </div>
    </div>
</asp:Content>



