<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NoticiaWF.aspx.cs" Inherits="web.NoticiaWF" %>


<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
  <asp:ListView ID="ListView1" runat="server">
<ItemTemplate>
    <div class="list">
        <table>
           <tr><td><img src="<%#Eval("imagen") %>"></td></tr>
           <tr><td><h1><%#Eval("titulo") %></h1></td></tr>
           <tr><td><p><%#Eval("fecha_public") %>"</p></td></tr>

        </table>
    </div>
</ItemTemplate>




  </asp:ListView>
 
</asp:Content>