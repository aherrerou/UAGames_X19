<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="misReseñas.aspx.cs" Inherits="web.misReseñas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>

        <div class="showGrid">
            <div class="textbox-container">
                Videojuego:
            <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox-aspnet"></asp:TextBox>
                <asp:Button ID="filtrarReview" runat="server" Text="Filtrar" OnClick="filtrarReview_Click" />
            </div>
        </div>
    </main>
    <main>
        <asp:ListView ID="ReviewListView" runat="server" GroupItemCount="4">
            <LayoutTemplate>
                <div class="listaReviews">
                    <h1 style="text-align: center">Reviews</h1>
                    <br />
                    <table cssclass="tableReviews" runat="server">
                        <tr runat="server" id="groupPlaceholder">
                        </tr>
                    </table>

                    <asp:DataPager runat="server" ID="DataPager" PageSize="8" style="text-align: center; font-size: 20px; color: #0A2558; font-weight: 800;">
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
                    <div>
                        <div>
                            <a>
                                <h3><%# Eval("nombrejuego") %></h3>
                            </a>
                            <a>
                                <h4><%# Eval("nombreUsuario") %></h4>
                            </a>

                        </div>
                        <asp:HyperLink ID="link" runat="server" NavigateUrl='<%#$"Review.aspx?id={Eval("id")}" %>'>
                            <div class="imagen-reseña">
                                <asp:Image ID="imagenCard" runat="server" ImageUrl='<%# Eval("imagen") %>' />
                            </div>
                        </asp:HyperLink>

                        <div>
                            <a>
                                <h6><%# Eval("puntuacion") %></h6>
                            </a>
                            <h6><%# Eval("comentario") %></h6>
                            <div class="botones">
                                <asp:ImageButton ID="deleteReview" runat="server" ImageAlign="Middle" ImageUrl="assets/imagenes/iconos/eraser.png"
                                    OnClick="deleteReview_Click" CommandArgument='<%# Eval("id") %>' />
                                <asp:ImageButton ID="editarReview" runat="server" ImageAlign="Middle" ImageUrl="assets/imagenes/iconos/edit.png"
                                    OnClick="editarReview_Click" CommandArgument='<%# Eval("id") %>' />
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
    <main>
        <div class="showGrid">
            <h2>Crear reseña</h2>
            <div class="crearFlex">
                <div class="flexIzq">
                    Nombre del Videojuego:
            <asp:TextBox ID="nombreVideojuego" runat="server"></asp:TextBox>
                    Puntuacion:
                    <asp:TextBox ID="puntuacion" runat="server"></asp:TextBox>
                </div>
                <div class="flexDer">
                    Comentario:
                    <asp:TextBox ID="comentario" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="crearReview" Text="Crear" runat="server" OnClick="crearReviewClick" />
                </div>
            </div>
        </div>
    </main>
</asp:Content>
