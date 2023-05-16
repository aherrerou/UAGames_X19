<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ThankYouPage.aspx.cs" Inherits="web.ThankYouPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Agradecimiento por tu compra</title>
    <link rel="stylesheet" href="estilos.css">
</head>
<body>
    <main>
        <div class="container">
            <h1>¡Gracias por tu compra!</h1>
            <p>Tu compra ha sido procesada con éxito.</p>
            <p>Recibirás un correo electrónico con los detalles de tu compra en breve.</p>
            <a class="btn" href="Inicio.aspx">Volver a la página principal</a>
        </div>
    </main>
</body>
</html>

    <style>

    body {
    font-family: Arial, sans-serif;
    background-color: #f2f2f2;
    padding: 50px;
    margin: 0;
}

.container {
    max-width: 600px;
    margin: 0 auto;
    background-color: #fff;
    padding: 30px;
    border-radius: 5px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

h1 {
    color: #333;
    font-size: 30px;
    margin-bottom: 20px;
}

p {
    color: #666;
    font-size: 18px;
    margin-bottom: 30px;
}

.btn {
    display: inline-block;
    padding: 10px 20px;
    background-color: #007bff;
    color: #fff;
    text-decoration: none;
    border-radius: 4px;
    transition: background-color 0.3s;
}

.btn:hover {
    background-color: #0056b3;
}

        </style>

</asp:Content>
