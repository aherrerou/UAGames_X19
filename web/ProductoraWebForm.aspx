<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductoraWebForm.aspx.cs" Inherits="web.ProductoraWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
   <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml%22%3E>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Crear Productora</title>
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
                <label for="txtIdn">Id:</label>
                <asp:TextBox ID="txtId" runat="server" ></asp:TextBox>
            </div>
            <div>
                <label for="txtImg">Imagen:</label>
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
                <asp:TextBox ID="txtWeb" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </div>
            <div>
              <asp:Button ID="btnCrearProductora" runat="server" Text="Crear Productora" OnClick="onCrear" />
                 <asp:Button ID="btnLeerNombre" runat="server" Text="Leer Productora por nombre" OnClick="onLeerNombre" />
                <asp:Button ID="btnLeerID" runat="server" Text="Leer Productora por ID" OnClick="onLeerId" />
                 <asp:Button ID="btnBorrarProductora" runat="server" Text="Borrar Productora" OnClick="onBorrar" />
                <asp:Button ID="btnUpdateProductora" runat="server" Text="Actualizar Productora" OnClick="onUpdate" />

                 <asp:Button ID="btnLeerTodas" runat="server" Text="Mostrar todas las productoras" OnClick="onLeerTodas" />
            </div>
        </div>
    </form>
    <br />
            <asp:Label ID="PResultado" runat="server" Text =" " />&nbsp;
            <br />
    <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <div class="list">
                    <div class="list-img">
                        <img src="<%#Eval("imagen") %>"  />
                    </div>
                    <div class="list-content">
                        <h1><%#Eval("nombre") %></h1>
                        <h1><%#Eval("web") %></h1>
                        <p><%#Eval("descripcion") %></p>
                      
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </main>
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

        input[type=text],
        textarea {
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
            margin-right: 5px;
            margin-bottom: 10px;
        }

        input[type=submit]:hover {
            background-color: #45a049;
        }

        main {
            padding-top: 20px;
        }

        .list {
            display: flex;
            flex-direction: column;
            align-items: flex-start;
            margin-bottom: 20px;
        }

        .list-img {
            margin-right: 10px;
            margin-bottom: 10px;
        }

        .list-img img {
            max-width: 100%;
            height: auto;
        }

        .list-content {
            text-align: left;
        }

        .list-button {
            margin-top: 10px;
        }

        .noticia-enlace {
            font-size: 18px;
            font-weight: bold;
            color: #0080FF;
            text-decoration: none;
        }
    </style>

</html>

</asp:Content>