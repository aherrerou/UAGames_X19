<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticiaWF.aspx" Inherits="WebNoticiaWF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="NoticiasListView" runat="server" ItemPlaceholderID="itemPlaceholder">
                <LayoutTemplate>
                    <div>
                        <h1>Noticias</h1>
                        <table>
                            <tr>
                                <th>Título</th>
                                <th>Imagen</th>
                                <th>Fecha de publicación</th>
                            </tr>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </table>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Titulo") %></td>
                        <td><asp:Image ID="NoticiaImagen" runat="server" ImageUrl='<%# Eval("ImagenUrl") %>' /></td>
                        <td><%# Eval("FechaPublicacion") %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
