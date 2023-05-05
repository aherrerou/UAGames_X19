<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NoticiaWF.aspx.cs" Inherits="web.NoticiaWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <main>
    <div class="noticias-container">
       <div class="noticia">
  <img class="noticia-imagen" src="https://via.placeholder.com/650x300" alt="Imagen de la noticia">
  <div class="noticia-contenido">
    <h2 class="noticia-titulo">Título de la noticia </h2>
    <p class="noticia-descripcion">Descripción de la noticia</p>
    <span class="noticia-productora">Productora: Nombre de la productora</span>
    <span class="noticia-fecha">Fecha: 01/05/2023</span>
  </div>
  <a href="#" class="noticia-enlace">Leer más</a>
</div>
         <div class="noticia">
  <img class="noticia-imagen" src="https://via.placeholder.com/650x300" alt="Imagen de la noticia">
  <div class="noticia-contenido">
    <h2 class="noticia-titulo">Título de la noticia </h2>
    <p class="noticia-descripcion">Descripción de la noticia</p>
    <span class="noticia-productora">Productora: Nombre de la productora</span>
    <span class="noticia-fecha">Fecha: 01/05/2023</span>
  </div>
  <a href="#" class="noticia-enlace">Leer más</a>
</div>
         <div class="noticia">
  <img class="noticia-imagen" src="https://via.placeholder.com/650x300" alt="Imagen de la noticia">
  <div class="noticia-contenido">
    <h2 class="noticia-titulo">Título de la noticia </h2>
    <p class="noticia-descripcion">Descripción de la noticia</p>
    <span class="noticia-productora">Productora: Nombre de la productora</span>
    <span class="noticia-fecha">Fecha: 01/05/2023</span>
  </div>
  <a href="#" class="noticia-enlace">Leer más</a>
</div>
         <div class="noticia">
  <img class="noticia-imagen" src="https://via.placeholder.com/650x300" alt="Imagen de la noticia">
  <div class="noticia-contenido">
    <h2 class="noticia-titulo">Título de la noticia </h2>
    <p class="noticia-descripcion">Descripción de la noticia</p>
    <span class="noticia-productora">Productora: Nombre de la productora</span>
    <span class="noticia-fecha">Fecha: 01/05/2023</span>
  </div>
  <a href="#" class="noticia-enlace">Leer más</a>
</div>
         <div class="noticia">
  <img class="noticia-imagen" src="https://via.placeholder.com/650x300" alt="Imagen de la noticia">
  <div class="noticia-contenido">
    <h2 class="noticia-titulo">Título de la noticia </h2>
    <p class="noticia-descripcion">Descripción de la noticia</p>
    <span class="noticia-productora">Productora: Nombre de la productora</span>
    <span class="noticia-fecha">Fecha: 01/05/2023</span>
  </div>
  <a href="#" class="noticia-enlace">Leer más</a>
</div>
         <div class="noticia">
  <img class="noticia-imagen" src="https://via.placeholder.com/650x300" alt="Imagen de la noticia">
  <div class="noticia-contenido">
    <h2 class="noticia-titulo">Título de la noticia </h2>
    <p class="noticia-descripcion">Descripción de la noticia</p>
    <span class="noticia-productora">Productora: Nombre de la productora</span>
    <span class="noticia-fecha">Fecha: 01/05/2023</span>
  </div>
  <a href="#" class="noticia-enlace">Leer más</a>
</div>
         <div class="noticia">
  <img class="noticia-imagen" src="https://via.placeholder.com/650x300" alt="Imagen de la noticia">
  <div class="noticia-contenido">
    <h2 class="noticia-titulo">Título de la noticia </h2>
    <p class="noticia-descripcion">Descripción de la noticia</p>
    <span class="noticia-productora">Productora: Nombre de la productora</span>
    <span class="noticia-fecha">Fecha: 01/05/2023</span>
  </div>
  <a href="#" class="noticia-enlace">Leer más</a>
</div>
         <div class="noticia">
  <img class="noticia-imagen" src="https://via.placeholder.com/650x300" alt="Imagen de la noticia">
  <div class="noticia-contenido">
    <h2 class="noticia-titulo">Título de la noticia </h2>
    <p class="noticia-descripcion">Descripción de la noticia</p>
    <span class="noticia-productora">Productora: Nombre de la productora</span>
    <span class="noticia-fecha">Fecha: 01/05/2023</span>
  </div>
  <a href="#" class="noticia-enlace">Leer más</a>
</div>
         <div class="noticia">
  <img class="noticia-imagen" src="https://via.placeholder.com/650x300" alt="Imagen de la noticia">
  <div class="noticia-contenido">
    <h2 class="noticia-titulo">Título de la noticia </h2>
    <p class="noticia-descripcion">Descripción de la noticia</p>
    <span class="noticia-productora">Productora: Nombre de la productora</span>
    <span class="noticia-fecha">Fecha: 01/05/2023</span>
  </div>
  <a href="#" class="noticia-enlace">Leer más</a>
</div>
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

       

        ul#noticias {
            list-style: none;
            margin: 0;
            padding: 0;
        }

        .noticias-container {
            display: flex;
            flex-wrap: wrap;
            margin: 0 -20px;
        }

        

        

       

        

      

      

       
        .noticias-container {
          display: flex;
          flex-wrap: wrap;
          margin-bottom: 60px;
          background-color: #fff;
          border: 1px solid #ccc;
          border-radius: 10px;
          box-shadow: 0px 5px 10px rgba(0, 0, 0, 0.1);
          overflow: hidden;
          width: 100%;
        }

           .noticia {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  padding: 20px;
  width: 45%;
  margin: 20px;
  background-color: #f8f8f8;
  border: 1px solid #ddd;
  border-radius: 5px;
  box-shadow: 0px 2px 5px rgba(0, 0, 0, 0.1);
}



.noticia-titulo {
  font-size: 24px;
  font-weight: bold;
  margin: 20px 0 10px;
}

.noticia-descripcion {
  flex-grow: 1;
  margin: 0;
  font-size: 18px;
  color: #666;
}

.noticia-productora {
  margin-top: 10px;
  font-size: 14px;
  color: #999;
}

.noticia-fecha {
  margin-top: 10px;
  font-size: 14px;
  color: #999;
}

.noticia-enlace {
  color: #0080FF;
  font-weight: bold;
  text-decoration: none;
  margin-top: 10px;
  align-self: flex-end;
}



             h2 {
              font-size: 24px;
              font-weight: bold;
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