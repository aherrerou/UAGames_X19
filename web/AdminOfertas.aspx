<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminOfertas.aspx.cs" Inherits="web.AdminOfertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="showGrid">
            <h2>Ofertas</h2>
            <asp:GridView ID="ofertasTable" runat="server" CssClass="grid" AutoGenerateColumns="False"
                DataKeyNames="id" PageSize="5" AllowPaging="True"
                EmptyDataText="Ups, no se han encontrado ofertas."
                OnPageIndexChanging="changePageOfertasTable"
                OnRowEditing="clickRowEditOferta"
                OnRowCancelingEdit="clickRowCancelOferta"
                OnRowUpdating="clickRowUpdateOferta"
                OnRowDeleting="clickRowDeleteOferta">

                <columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="videojuego" HeaderText="Videojuego" SortExpression="Videojuego" />
                    <asp:BoundField DataField="productora" HeaderText="Productora" SortExpression="Productora" />
                    <asp:BoundField DataField="descuento" HeaderText="Descuento" SortExpression="Descuento" />
                    <asp:BoundField DataField="fecha_inicio" HeaderText="Fecha Inicio" SortExpression="FechaInicio" />
                    <asp:BoundField DataField="fecha_fin" HeaderText="Fecha Fin" SortExpression="FechaFin" />
                    <asp:CommandField HeaderText="Acciones" ButtonType="Image" CancelImageUrl="~/assets/imagenes/iconos/cancel.png" EditImageUrl="~/assets/imagenes/iconos/edit.png"
                        ShowEditButton="True" ShowDeleteButton="True" ShowCancelButton="True" UpdateImageUrl="~/assets/imagenes/iconos/check.png"
                        DeleteImageUrl="~/assets/imagenes/iconos/trash.png">
                        <controlstyle height="20px" width="20px" cssclass="botones" />
                    </asp:CommandField>

                </columns>
                <footerstyle backcolor="#0A2558" forecolor="#fff" />
                <headerstyle backcolor="#0A2558" font-bold="True" forecolor="#fff" />
                <pagersettings mode="Numeric" position="Bottom" previouspagetext="True" />
                <pagerstyle horizontalalign="Center" forecolor="#0A2558" />
                <rowstyle forecolor="#0A2558" />
                <selectedrowstyle backcolor="#669999" font-bold="True" forecolor="White" />
                <sortedascendingcellstyle backcolor="#F1F1F1" />
                <sortedascendingheaderstyle backcolor="#007DBB" />
                <sorteddescendingcellstyle backcolor="#CAC9C9" />
                <sorteddescendingheaderstyle backcolor="#00547E" />
            </asp:GridView>
        </div>

    </main>

</asp:Content>
