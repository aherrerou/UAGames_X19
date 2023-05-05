<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reseña.aspx.cs" Inherits="web.Reseña" %>


<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
        <style>
<style>
    body {
        margin: 0;
        padding: 0;
        background-color: #f8f8f8;
        font-family: Arial, sans-serif;
    }

    main {
        max-width: 1200px;
        margin: 0 auto;
        padding: 20px;
    }

    h1 {
        font-size: 3rem;
        margin: 0 0 30px;
        text-align: center;
        text-transform: uppercase;
        letter-spacing: 2px;
    }

    table {
        border-collapse: collapse;
        width: 100%;
        background-color: #fff;
        border: 1px solid #ccc;
        border-radius: 10px;
        box-shadow: 0px 5px 10px rgba(0, 0, 0, 0.1);
        overflow: hidden;
    }

    th {
        text-align: left;
        padding: 10px;
        background-color: #f2f2f2;
        color: #333;
        font-weight: bold;
        border-bottom: 2px solid #ddd;
    }

    td {
        text-align: left;
        padding: 10px;
        border-bottom: 1px solid #ddd;
    }

    tr:hover {
        background-color: #f5f5f5;
    }

    #tablaReseñas tr:first-child:hover {
        background-color: #fff;
    }

    #tablaReseñas tr:last-child td {
        border-bottom: 0;
    }
</style>

<main>
    <table CssClass="tablaReseñas" runat="server">
         <tr>
            <th colspan="3" class="title">Listado de Reseñas</th>
        </tr>
        <tr>
            <th>Producto</th>
            <th>Comentario</th>
            <th>Autor</th>
        </tr>
        <tr>
            <td>Producto A</td>
            <td>Muy bueno</td>
            <td>Juan Pérez</td>
        </tr>
        <tr>
            <td>Producto B</td>
            <td>Regular</td>
            <td>Ana Gómez</td>
        </tr>
        <tr>
            <td>Producto C</td>
            <td>Excelente</td>
            <td>Pedro García</td>
        </tr>
    </table>
</main>

    </asp:Content>