﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Catalogo2.aspx.cs" Inherits="web.Catalogo2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        
        <asp:ListView ID="VideojuegosListView" runat="server" GroupItemCount="4" >
            <LayoutTemplate>
                <div class="listaVideojuegos">
                    <h1 style="text-align:center">Videojuegos</h1>
                    <br />
                    <table CssClass="tableVideojuegos" runat="server">
                    <tr runat="server" id="groupPlaceholder">
                    </tr>
                </table>

                <asp:DataPager runat="server" ID="DataPager" PageSize="8" style="text-align:center; font-size:20px; color:#0A2558">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="False" ShowNextPageButton="False" ShowPreviousPageButton="True"
                            PreviousPageText="<-" FirstPageText="<<" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="False" ShowLastPageButton="True" ShowNextPageButton="True" ShowPreviousPageButton="False"
                            NextPageText="->" LastPageText=">>" />
                    </Fields>
                </asp:DataPager>
                </div>
                
            </LayoutTemplate>
            <GroupTemplate>
                <tr runat="server" id="videojuegoRow">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td>
                    <div class="card">
                        <img src='<%# Eval("imagen") %>' class="card-img-top" alt="Card image cap">
                        <div class="card-body">
                            <h6><%# Eval("productora") %></h6>
                            <h6><%# Eval("categoria") %></h6>
                            <h6><%# Eval("plataforma") %></h6>
                            <h6><%# Eval("precio") %> €</h6>
                            <a href="#" class="btn btn-primary">Comprar</a>
                        </div>
                    </div>
                </td>
            </ItemTemplate>
        </asp:ListView>

    </main>
</asp:Content>