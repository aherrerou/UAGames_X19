<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="web.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Número de pedido" DataSourceID="UAGAMES" GridLines="Vertical" CssClass="GridViewFullWidth">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />
                <asp:BoundField DataField="Fecha compra" HeaderText="Fecha compra" SortExpression="Fecha compra" />
                <asp:BoundField DataField="Número de pedido" HeaderText="Número de pedido" InsertVisible="False" ReadOnly="True" SortExpression="Número de pedido" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#0A2558" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
    <asp:SqlDataSource ID="UAGAMES" runat="server" ConnectionString="<%$ ConnectionStrings:miconexion %>" SelectCommand="SELECT Usuario.nick AS 'Usuario', Compra.fecha AS 'Fecha compra', Compra.id AS 'Número de pedido' FROM Compra INNER JOIN Usuario ON Compra.usuarioID = Usuario.id"></asp:SqlDataSource>
    </main>
</asp:Content>



