<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Videojuego.aspx.cs" Inherits="web.Videojuego" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="container bg-light overflow-auto" style="min-height: 599px;">
        <div class="d-flex flex-row text-primary mt-3" style="object-fit:cover;">
            <div class="mt-3">
                <asp:Image ID="videojuegoImagen" runat="server" Style="height: 500px; margin-right: 20px; object-fit: cover; object-position: left;" />
            </div>
            <div class="mt-2">
                <asp:Label ID="tituloLabel" runat="server" style="font-size:35px; font-weight:bold;" ></asp:Label>
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
        </div>

        <!--REVIEWS-->
        <div class="row mt-5">
            <h1>Valoraciones</h1>
        </div>
        
        <asp:ListView ID="listViewReviews" runat="server">
                <EmptyDataTemplate>
                    <span>No hay valoraciones de este videojuego.</span>
                </EmptyDataTemplate>              
                      <ItemTemplate>
                          <div class="row">
                          <div class="col-md-2"></div>                         
                          <div class="card col-md-8">
                              
                              <div class="card-body">
                                  <div class="row">
                                      <div class="col-md-6">
                                          <h4>
                                              <%# Eval("usuario") %>
                                          </h4>                                         
                                      </div>
                                      <div class="col-md-6">
                                           <%# Eval("fecha") %>
                                      </div>
                                      <div class="col-md-6">
                                         <h1 style="color:#e5e534;font-weight:100;float:right"><%# Eval("puntuacion") %></h1> 
                                      </div>
                                      <div class="col-md-12">
                                          <%# Eval("comentario") %>
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
