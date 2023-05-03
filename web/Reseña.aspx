<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reseña.aspx.cs" Inherits="web.Reseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>UAGames</title>
    <link rel="stylesheet" type="text/css" href="~/assets/css/StyleSheet1.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="header">
                <a href="../Inicio.aspx" class="logo">UA Games</a>
                <div class="header-menu">
                    <asp:Menu ID="menu" runat="server" Orientation="Horizontal" CssClass="menu">
                        <StaticMenuItemStyle HorizontalPadding="20" />
                        <Items>
                            <asp:MenuItem Text="Videojuegos" NavigateUrl="/" />
                            <asp:MenuItem Text="Ofertas" NavigateUrl="/" />
                            <asp:MenuItem Text="Reseñas" NavigateUrl="/Reseña.aspx" />
                            <asp:MenuItem Text="Noticias" NavigateUrl="/" />
                            <asp:MenuItem Text="Foro" NavigateUrl="/" />
                        </Items>
                    </asp:Menu>
                </div>
                <div class="header-right">
                    <asp:Button ID="BtnIniciarSesion" CssClass="button" Text="Iniciar sesion" runat="server" />
                    <asp:Button ID="BtnRegistrarse" CssClass="button" Text="Registrarse" runat="server" />
                </div>
            </div>
        </header>
        <div class="main container">
            <h2 class="title">Reseñas de videojuegos</h2>
            <div class="row">
                <div class="col-md-4">
                    <div class="card mb-4 shadow-sm">
                        <div class="card-body">
                            <h5 class="card-title">Reseña de juego 1</h5>
                            <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus vitae velit eleifend, dignissim tortor ut, vehicula quam. Nullam faucibus tristique dolor, eget feugiat quam. </p>
                            <div class="d-flex justify-content-between align-items-center">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-sm btn-outline-secondary">Leer más</button>
                                    <button type="button" class="btn btn-sm btn-outline-secondary">Comprar</button>
                                </div>
                                <small class="text-muted">Valoración: 8/10</small>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card mb-4 shadow-sm">
                        <div class="card-body">
                            <h5 class="card-title">Reseña de juego 2</h5>
                            <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus vitae velit eleifend, dignissim tortor ut, vehicula quam. Nullam faucibus tristique dolor, eget feugiat quam. </p>
                            <div class="d-flex justify-content-between align-items-center">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-sm btn-outline-secondary">Leer más</button>
                                    <button type="button" class="btn btn-sm btn-outline-secondary">Comprar</button>
                                </div>
                                <small class="text-muted">Valoración: 9/10</small>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card mb-4 shadow-sm">
                        <div class="card-body">
                            <h5 class="card-title">Reseña de juego 3</h5>
                            <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus vitae velit eleifend, dignissim tortor ut, vehicula quam. Nullam faucibus tristique dolor, eget feugiat quam. </p>
                            <div class="d-flex justify-content-between align-items-center">
                                <div class="btn-group">
                                    <button type="button" class="btn btn-sm btn-outline-secondary">Leer más</button>
                                    <button type="button" class="btn btn-sm btn-outline-secondary">Comprar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <footer>
        <div class="content">
            <div class="link-boxes">
                <a href="#" class="logo">UA Games</a>
                <ul class="box">
                    <li class="link_name">Compañia</li>
                    <li><a href="#">Contacto</a></li>
                    <li><a href="#">Sobre nosotros</a></li>
                    <li><a href="#">Preguntas frecuentes</a></li>
                </ul>
                <ul class="box">
                    <li class="link_name">Servicios</li>
                    <li><a href="#">Comprar videojuegos</a></li>
                    <li><a href="#">Ofertas</a></li>
                    <li><a href="#">Lista más vendidos</a></li>
                </ul>
                <ul class="box">
                    <li class="link_name">Más servicios</li>
                    <li><a href="#">Noticias</a></li>
                    <li><a href="#">Foro</a></li>
                    <li><a href="#">:)</a></li>
                </ul>
            </div>
        </div>
        <div class="bottom-details">
            <div class="bottom_text">
                <span class="copyright_text">Copyright © 2023 <a href="#">UAGames.</a>Todos los derechos reservados</span>
                <span class="policy_terms">
                    <a href="#">Política de privacidad</a>
                    <a href="#">Términos y condiciones</a>
                </span>
            </div>
        </div>
    </footer>
</body>
</html>
