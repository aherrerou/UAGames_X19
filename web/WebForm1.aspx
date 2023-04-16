<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Crear Cabecera_Compra" />
        <p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Eliminar Cabecera_Compra" />
        </p>
        <p>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Actualizar Cabecera_Compra" />
        </p>
        <p>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Leer Cabecera_Compra" />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <asp:TextBox ID="Resultado" runat="server"></asp:TextBox>
    </form>
</body>
</html>
