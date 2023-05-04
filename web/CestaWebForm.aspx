<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CestaWebForm.aspx.cs" Inherits="web.CestaWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
  
 <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <title>Cesta de compra</title>
    <style>
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            text-align: left;
            padding: 8px;
        }

        tr:nth-child(even) {background-color: #f2f2f2;}

        button {
            background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
        }

        #precio {
            margin-top: 20px;
            font-size: 20px;
            font-weight: bold;
        }
    </style>

<main>
    <form id="form1">
        <div>
            <h1>Cesta de compra</h1>
            <table>
                <tr>
                    <th>Videojuego</th>
                    <th>Fecha</th>
                    <th>Cantidad</th>
                    <th>Precio unitario</th>
                </tr>
                <tr>
                    <td>Videojuego 1</td>
                    <td>01/05/2023</td>
                    <td>2</td>
                    <td>30€</td>
                </tr>
                <tr>
                    <td>Videojuego 2</td>
                    <td>02/05/2023</td>
                    <td>1</td>
                    <td>25€</td>
                </tr>
            </table>
            <div id="precio">Precio total: 85€</div>
            <asp:Button ID="btnComprar" runat="server" Text="Comprar" OnClick="btnCompra_Click" />
            
        </div>
    </form>
</main>
</html>


</asp:Content>
