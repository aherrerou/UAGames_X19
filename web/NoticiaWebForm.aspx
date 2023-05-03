<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NoticiaWebForm.aspx.cs" Inherits="web.ProductoraWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
   
<meta charset="utf-8">
  
     <style>
      /* Estilos para el encabezado */
      header {
        background-color: #2e2e2e;
        color: white;
        padding: 10px;
        text-align: center;
        font-size: 36px;
        font-weight: bold;
        border-bottom: 5px solid #4a4a4a;
      }

      /* Estilos para el botón */
      button {
        background-color: #4a4a4a;
        color: white;
        padding: 10px;
        font-size: 24px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        transition: background-color 0.3s;
      }

      button:hover {
        background-color: #2e2e2e;
      }
    </style>
 
 
    <header>Mis Noticias</header>

    <div style="text-align:center;margin-top:20px;">
      <button onclick="mostrarNoticias()">Mostrar Noticias</button>
    </div>

    <script src="scripts.js"></script>


           
  
</asp:Content>



