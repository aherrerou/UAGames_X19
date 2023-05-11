﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="web.Catalogo" %>

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

                <asp:DataPager runat="server" ID="DataPager" PageSize="8" style="text-align:center; font-size:20px; color:#0A2558; font-weight: 600;">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="False" ShowNextPageButton="False" ShowPreviousPageButton="True"
                            PreviousPageText=" < " FirstPageText=" << " />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="False" ShowLastPageButton="True" ShowNextPageButton="True" ShowPreviousPageButton="False"
                            NextPageText=" > " LastPageText=" >> " />
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
                        <asp:Hyperlink id="link" runat="server" NavigateUrl='<%#$"Videojuego.aspx?id={Eval("id")}" %>'>
			    <asp:image id="imagenCard" runat="server" imageurl='<%# Eval("imagen") %>' alt="Card image cap" CssClass="card-img-top"/>
                        </asp:hyperlink>
                        
                        <div class="card-body">
                            <asp:Hyperlink id="linkProductora" runat="server" Text='<%# Eval("productora") %>' NavigateUrl='<%#$"Productora.aspx?id={Eval("id")}" %>'/>
                            <a href="#">
                            <h6><%# Eval("categoria") %></h6>
                            </a>
                            <h6><%# Eval("plataforma") %></h6>
                            <h6><%# Eval("precio") %> €</h6>
                            <div class="botones text-center justify-content-between">
                                     <asp:ImageButton id="addCart" runat="server" AlternateText="Add Cart" ImageAlign="middle"
                                ImageUrl="assets/imagenes/iconos/cartAdd.png"/>
                                <asp:ImageButton id="addList" runat="server" AlternateText="Add List" ImageAlign="middle"
                                ImageUrl="assets/imagenes/iconos/addList.png"/>
                                
                                     <asp:ImageButton id="share" runat="server" AlternateText="Share" ImageAlign="middle"
                                ImageUrl="assets/imagenes/iconos/share.png"/>
                               
                            </div>
                        </div>
                    </div>
                </td>
            </ItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>Ups, no se han encontrado videojuegos.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:ListView>

    </main>
</asp:Content>
