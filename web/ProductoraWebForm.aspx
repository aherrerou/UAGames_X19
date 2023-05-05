<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductoraWebForm.aspx.cs" Inherits="web.ProductoraWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
   <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml%22%3E>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Crear Categoría</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .form-container {
            max-width: 500px;
            margin: auto;
            padding: 20px;
            background-color: #f2f2f2;
            border-radius: 5px;
        }
        label {
            display: inline-block;
            width: 100px;
            margin-bottom: 10px;
        }
        input[type=text], textarea {
            padding: 10px;
            width: 100%;
            border: none;
            border-radius: 3px;
            background-color: #eaeaea;
            margin-bottom: 20px;
            resize: vertical;
        }
        input[type=submit] {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }
        input[type=submit]:hover {
            background-color: #45a049;
        }
    </style>
<main>
   
    <form id="form1">
        <div class="form-container">
            <h2>Crear productoras</h2>
            <div>
                <label for="txtId">Imagen:</label>
                <asp:TextBox ID="txtImg" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtDescripcion">Descripción:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </div>
             <div>
                <label for="txtWebn">Web:</label>
                <asp:TextBox ID="TxtWeb" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnCrearProductora" runat="server" Text="Crear Categoría" OnClick="btnCrearProductora_Click" />
            </div>
        </div>
    </form>

</main>
</html>

</asp:Content>