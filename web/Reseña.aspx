<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reseña.aspx.cs" Inherits="web.Reseña" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <link rel="stylesheet" href="assets/css/Rating.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:ScriptManager ID="asm" runat="server" />
    <div class="container bg-light overflow-auto" style="min-height: 599px;">
        <div class="d-flex flex-row text-primary mt-3">
            <div class="mt-6 align-items-xxl-start">
                <asp:Button CssClass="btn btn-primary" ID="volver" Text="Volver" runat="server" OnClick="Volver_click" />
            </div>
            <div class="mt-5">
                <asp:Image ID="videojuegoImagen" runat="server" Style="height: 30rem; width: 30rem; margin-right: 40px; object-fit: cover; object-position: left;" />
            </div>
            <div class="mt-4">
                <div class="mt-2">
                    <asp:Label ID="tituloLabel" runat="server" Style="font-size: 45px; font-weight: bold;"></asp:Label>
                    <asp:Label ID="UsuarioLabel" runat="server" Style="font-size: 45px; font-weight: bold;" />
                    <div class="border-top border-primary mt-2">
                    </div>
                    <div>
                        <h4 class="mt-1">Fecha:
                        <asp:Label ID="fechaLabel" runat="server" /></h4>
                    </div>
                    <div>
                        <h4 class="mt-1  border-primary border-top">Reseña del usuario: </h4>
                        <asp:Label ID="comentarioLabel" runat="server" Font-Size="30px" />
                    </div>
                    <div>

                        <h4 class="mt-1 border-primary border-top">
                            <br />
                            <ajaxToolkit:Rating ID="Puntuacion" runat="server" MaxRating="5" Font-Size="45px"
                                EmptyStarCssClass="emptyRatingStar" FilledStarCssClass="filledRatingStar" StarCssClass="emptyRatingStar" WaitingStarCssClass="emptyRatingStar" ReadOnly="true" />
                        </h4>

                    </div>
                </div>
                <!--BOTONES-->
            </div>
            <div class="mt-6 mx-5 d-flex">
                <div class="mt-8 align-top">
                    <asp:Button CssClass="btn btn-primary" ID="Editar" Text="Editar" runat="server" OnClick="Editar_click" Visible="true" />
                    <asp:Button CssClass="btn btn-primary" ID="Eliminar" Text="Eliminar" runat="server" OnClick="Eliminar_click" Visible="true" />

                </div>
            </div>
            </>
        </div>
        <div class="mt-8 text-right">
            <br />
            <asp:TextBox ID="notaReview" runat="server" Visible="false" placeholder="Nota..." type="number" min="0" MaxLength="5" CssClass="mb-2" Style="width: 150px;"></asp:TextBox>
            <asp:TextBox ID="comentarioReview" runat="server" Visible="false" placeholder="Comentario..." CssClass="mb-2" Style="width: 300px;"></asp:TextBox>
            <asp:Button CssClass="btn btn-primary" ID="confirmar" Text="Confirmar" runat="server" Visible="true" OnClick="Confirmar_click" />
            <asp:Button CssClass="btn btn-primary" ID="cancelar" Text="Cancelar" runat="server" Visible="true" OnClick="Cancelar_click" />
            
        </div>
</asp:Content>
