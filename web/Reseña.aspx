<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reseña.aspx.cs" Inherits="web.Reseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="showGrid">
            <div class="reseña">
                <div class="reseña-contenido">
                    <h2 class="reseña-titulo">Battlefield 4 </h2>
                    <p class="reseña-descripcion">Comentario de la reseña</p>
                    <h3 class="reseña-descripcion">user </h3>
                    <span class="reseña-datosgen">Calificación: 8/10</span>
                    <span class="reseña-datosgen">Fecha: 03/05/2023</span>
                </div>

            </div>
            <asp:Button ID="CrearReseña" runat="server" OnClick="CrearReseña_Click" Text="Crear" />
            <div class="reseña">
                <asp:TextBox ID="Puntuacion" runat="server" OnTextChanged="Puntuacion_TextChanged"></asp:TextBox>
                <div class="reseña-contenido">
                    <h2 class="reseña-titulo">Fifa 2023 
                        
                    </h2>
                    <asp:TextBox ID="VideojuegoID" runat="server" OnTextChanged="VideojuegoID_TextChanged"></asp:TextBox>
                    <asp:TextBox ID="UsuarioID" runat="server" OnTextChanged="UsuarioID_TextChanged"></asp:TextBox>
                    <asp:TextBox ID="Comentario" runat="server" OnTextChanged="Comentario_TextChanged"></asp:TextBox>
                    <asp:TextBox ID="Fecha" runat="server" OnTextChanged="Fecha_TextChanged" ></asp:TextBox>
                    <p class="reseña-descripcion">Comentario de la reseña</p>
                    <h3 class="reseña-descripcion">user </h3>
                    <span class="reseña-datosgen">Calificación: 7/10</span>
                    <span class="reseña-datosgen">Fecha: 05/05/2023</span>
                </div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="reseña-foto">
                    <img class="img-reseña" />
                </div>
            </div>
            <div class="reseña">
                <div class="reseña-contenido">
                    <h2 class="reseña-titulo">Call of Duty: Modern Warfare 3</h2>
                    <p class="reseña-descripcion">Comentario de la reseña</p>
                    <h3 class="reseña-descripcion">user </h3>
                    <span class="reseña-datosgen">Calificación: 10/10</span>
                    <span class="reseña-datosgen">Fecha: 07/05/2023</span>
                </div>
                <div class="reseña-foto">
                    <img class="img-reseña" />
                </div>

                
                    
            </div>
             <asp:GridView ID="GridView1" runat="server" CssClass="grid"></asp:GridView>
         </div>
    </main>

    <style>
        body {
            margin: 0;
            padding: 0;
            background-color: #f8f8f8;
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
        ul#reseñas {
            list-style: none;
            margin: 0;
            padding: 0;
        }
        .reseña-contenido {
            width: 80%;
        }
       .img-reseña{
            height:150px;
            width: 150px;
            
        }
        .reseña {
            display: flex;
            padding: 20px;
            width: 100%;
            margin: 20px;
            background-color: #f8f8f8;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: 0px 2px 5px rgba(0, 0, 0, 0.1);
        }
        .reseña-titulo {
            font-size: 25px;
            font-weight: bold;
            margin: 20px 0 10px;
        }
        .reseña-descripcion {
            flex-grow: 1;
            margin: 5px;
            font-size: 18px;
            color: #666;
        }
        .reseña-datosgen {
            margin-top: 10px;
            font-size: 14px;
            color: #999;
        }
        h2 {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 10px;
        }
        h3 {
              font-size: 14px;
              font-weight:bold;
              margin-bottom: 10px;
            }
        p {
            font-size: 18px;
            margin-top: 10px;
            flex-grow: 1;
        }
        a {
            color: #0080FF;
            font-weight: bold;
            text-decoration: none;
            margin-top: 10px;
            align-self: flex-end;
        }
    </style>
</asp:Content>