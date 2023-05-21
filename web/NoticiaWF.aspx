<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NoticiaWF.aspx.cs" Inherits="web.NoticiaWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <div class="container bg-light overflow-auto" style="min-height:599px;">
        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <div class="list">
                    <div class="list-img">
                        <img src='<%#Eval("imagen") %>'  />
                    </div>
                    <div class="list-content">
                        <h1><%#Eval("titulo") %></h1>
                        <p><%#Eval("fecha_public") %></p>
                        <div class="list-button">
                            <a href='<%#"NoticiaCompleta.aspx?id=" + Eval("id") %>' class="noticia-enlace" onmouseover="enlargeLink(this)" onmouseout="resetLink(this)">Leer más</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
<style>
    .list-container {
        display: flex;
        flex-wrap: wrap;
        justify-content: space-between;
        margin-bottom: 20px;
    }

    .list {
        width: calc(50% - 10px);
        margin-bottom: 20px;
        border: 1px solid #ccc;
        padding: 20px;
        border-radius: 5px;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        display: flex;
        align-items: flex-start;
    }

    .list-img {
        margin-right: 10px;
        width: 200px;
    }

    .list-img img {
        max-width: 100%;
        height: auto;
        border-radius: 5px;
    }

    .list-content {
        text-align: left;
    }

    .list-content h1 {
        font-size: 24px;
        font-weight: bold;
        margin-bottom: 10px;
    }

    .list-content p {
        font-size: 14px;
        margin-bottom: 10px;
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
<script>
    function enlargeLink(link) {
        link.style.transform = "scale(1.1)";
    }

    function resetLink(link) {
        link.style.transform = "scale(1)";
    }
</script>
</asp:Content>
