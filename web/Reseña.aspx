<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reseña.aspx.cs" Inherits="web.Reseña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <asp:ListView ID="ReviewListView" runat="server" GroupItemCount="4" >
            <LayoutTemplate>
                <div class="listaReviews">
                    <h1 style="text-align:center">Reviews</h1>
                    <br />
                    <table CssClass="tableReviews" runat="server">
                    <tr runat="server" id="groupPlaceholder">
                    </tr>
                </table>

                <asp:DataPager runat="server" ID="DataPager" PageSize="8" style="text-align:center; font-size:20px; color:#0A2558; font-weight: 800;">
                    <Fields>
                    </Fields>
                </asp:DataPager>
                </div>
                
            </LayoutTemplate>
            <GroupTemplate>
                <tr runat="server" id="reviewRow">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td>
                    <div class="card">
                        <asp:Hyperlink id="link" runat="server" NavigateUrl='<%#$"Review.aspx?id={Eval("id")}" %>'>
			    <asp:image id="imagenCard" runat="server" imageurl='<%# Eval("imagen") %>' alt="Card image cap" CssClass="card-img-top"/>
                        </asp:hyperlink>
                        
                        <div class="card-body">
                            <%--<asp:Hyperlink id="linkProductora" runat="server" Text='<%# Eval("productora") %>' NavigateUrl='<%#$"Productora.aspx?id={Eval("id")}" %>'/>--%>
                            <a href="#">
                            <h6><%# Eval("puntuacion") %></h6>
                            </a>
                            <h6><%# Eval("comentario") %></h6>
                            <div class="botones">
                                <%--<asp:ImageButton id="addCart" runat="server" AlternateText="Add Cart" ImageAlign="middle"
                                ImageUrl="assets/imagenes/iconos/cartAdd.png"/>
                                <asp:ImageButton id="addList" runat="server" AlternateText="Add List" ImageAlign="middle"
                                ImageUrl="assets/imagenes/iconos/addList.png"/>--%>
                            </div>
                        </div>
                    </div>
                </td>
            </ItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>Ups, no se han encontrado reseñas.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:ListView>
    </main>
</asp:Content>