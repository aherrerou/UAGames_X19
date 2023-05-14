<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Videojuego.aspx.cs" Inherits="web.Videojuego" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="container bg-light overflow-auto" style="min-height: 599px;">
        <div class="d-flex flex-row text-primary mt-3">
            <div class="mt-3">
                <asp:Image ID="videojuegoImagen" runat="server" Style="height: 500px; margin-right: 20px; object-fit: cover; object-position: left;" />
            </div>
            <div class="mt-2">
                <asp:Label ID="tituloLabel" runat="server" Style="font-size: 35px; font-weight: bold;"></asp:Label>
                <div class="border-top border-primary mt-2">
                    <h5 class="mt-3">Productora: </h5>
                    <asp:LinkButton ID="productoraLink" runat="server" CssClass="text-primary" />
                </div>
                <div>
                    <h5 class="mt-1">Categoria: </h5>
                    <asp:LinkButton ID="categoriaLink" runat="server" CssClass="text-primary" />
                </div>
                <div>
                    <h5 class="mt-1">Fecha lanzamiento: </h5>
                    <asp:Label ID="fechaLabel" runat="server" />
                </div>
                <div>
                    <h5 class="mt-1">Plataforma: </h5>
                    <asp:Label ID="plataformaLabel" runat="server" />
                </div>
                <div>
                    <h5 class="mt-1">Descripcion: </h5>
                    <asp:Label ID="descripcionLabel" runat="server" />
                </div>
                <div>
                    <h5 class="mt-1">Precio: </h5>
                    <asp:Label ID="precioLabel" runat="server" />
                </div>
                <!--BOTONES-->
                <div class="text-center d-flex flex-row mt-3">
                    <asp:ImageButton ID="addCart" runat="server" AlternateText="Add Cart" ImageAlign="middle" Style="height: 3rem;" CssClass="bg-primary mx-3 rounded"
                        ImageUrl="assets/imagenes/iconos/cartAdd.png" OnClientClick="clickAddCart" OnClick="clickAddCart" CommandArgument='<%# Eval("id") %>' />
                    <asp:ImageButton ID="addList" runat="server" AlternateText="Add List" ImageAlign="middle" Style="height: 3rem;" CssClass="bg-primary rounded"
                        ImageUrl="assets/imagenes/iconos/addList.png" OnClientClick="clickAddList" OnClick="clickAddList" CommandArgument='<%# Eval("id") %>' />
                </div>
            </div>
            <div class="mt-3 mx-5">
                <asp:ListView ID="ofertaDisplay" runat="server">
                    <EmptyDataTemplate>
                <span></span>
            </EmptyDataTemplate>
                    <LayoutTemplate>
                <div>
                    <table runat="server">
                        <tr runat="server" id="groupPlaceholder">
                        </tr>
                    </table>
                </div>
            </LayoutTemplate>
                    <GroupTemplate>
                <tr runat="server" id="ofertarow" class="mx-4">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td class="mx-4">
                    <div class="card bg-primary text-white mx-3 my-2 border-0">
                        <div class="row">
                            <div class="card-body mt-3">
                                <h1 class="card-title"><%# Eval("nombre") %></h1>
                                    <h3>Descuento: <%# Eval("descuento") %>%</h3>
                                    <h3>Desde: <%# Eval("fecha_inicio") %></h3>
                                    <h3>Hasta: <%# Eval("fecha_fin") %></h3>
                                    <h3> <asp:Label ID="nuevoPrecio" runat="server" ></asp:Label></h3>
                            </div>
                        </div>
                    </div>
                </td>
            </ItemTemplate>


                    </asp:ListView>
            </div>
        </div>

        <!--REVIEWS-->
        <div class="row mt-5">
            <h1>Valoraciones</h1>
        </div>

        <asp:ListView ID="listViewReviews" runat="server">
            <EmptyDataTemplate>
                <span>No hay valoraciones de este videojuego.</span>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <div>
                    <table runat="server">
                        <tr runat="server" id="groupPlaceholder">
                        </tr>
                    </table>
                    <div class="text-center">
                        <asp:DataPager runat="server" ID="DataPager" PageSize="8" HorizontalAlign="Center" CssClass="text-center text-primary">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="False" ShowPreviousPageButton="True" ButtonCssClass="btn btn-primary"
                                PreviousPageText=" < " FirstPageText=" << " />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="True" ShowPreviousPageButton="False" ButtonCssClass="btn btn-primary"
                                NextPageText=" > " LastPageText=" >> " />
                        </Fields>
                    </asp:DataPager>
                    </div>
                    
                </div>
            </LayoutTemplate>
            <GroupTemplate>
                <tr runat="server" id="videojuegoRow" class="mx-4">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <div class="row">
                    <div class="card col-md-8">

                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4><%# Eval("usuario") %>  </h4>
                                </div>
                                <div class="col-md-4">
                                    <h2><%# Eval("puntuacion") %></h2>
                                </div>
                                <div class="col-md-4">
                                    <%# Eval("fecha") %>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-md-12">
                                    <%# Eval("comentario") %>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-2"></div>
                </div>
                          
                            <div class="row">
                                <div class="col-md-8">
                                    <!--Borrar Comentario-->
                                </div>
                            </div>
                <br />
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
