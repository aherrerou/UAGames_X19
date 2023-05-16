<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NoticiaWF.aspx.cs" Inherits="web.NoticiaWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
   <main>
        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <div class="list">
                    <div class="list-img">
                        <img src="<%#Eval("imagen") %>" alt="<%#Eval("titulo") %>" />
                    </div>
                    <div class="list-content">
                        <h1><%#Eval("titulo") %></h1>
                        <p><%#Eval("fecha_public") %></p>
                        <div class="list-button">
                            <a href="#" class="noticia-enlace">Leer más</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
  </main>

    <style>
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
</asp:Content>
