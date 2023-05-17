<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reserva.aspx.cs" Inherits="web.Reserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <main>
        <div class="showGrid">
            <h2>Reservas</h2>
            <asp:GridView ID="reservasTable" runat="server" CssClass="grid" AutoGenerateColumns="False"
                DataKeyNames="id" PageSize="5" AllowPaging="True"
                EmptyDataText="Ups, no se han encontrado reservas.">
                

                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="videojuego" HeaderText="Videojuego" SortExpression="Videojuego" />
                    <asp:BoundField DataField="pagado" HeaderText="Pagado" SortExpression="Pagado" />
                    <asp:BoundField DataField="fechaEntrega" HeaderText="Fecha de entrega" SortExpression="FechaEntrega" />
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="Fecha" />
                    <asp:CommandField HeaderText="Acciones" ButtonType="Image" CancelImageUrl="~/assets/imagenes/iconos/cancel.png" EditImageUrl="~/assets/imagenes/iconos/edit.png"
                        ShowEditButton="True" ShowDeleteButton="True" ShowCancelButton="True" UpdateImageUrl="~/assets/imagenes/iconos/check.png"
                        DeleteImageUrl="~/assets/imagenes/iconos/trash.png">
                        <ControlStyle Height="20px" Width="20px" CssClass="botones" />
                    </asp:CommandField>

                </Columns>
                <FooterStyle BackColor="#0A2558" ForeColor="#fff" />
                <HeaderStyle BackColor="#0A2558" Font-Bold="True" ForeColor="#fff" />
                <PagerSettings Mode="Numeric" Position="Bottom" PreviousPageText="True" />
                <PagerStyle HorizontalAlign="Center" ForeColor="#0A2558" />
                <RowStyle ForeColor="#0A2558" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
    </main>

</asp:Content>


<%--OnRowEditing="editReserva_click"
                OnRowCancelingEdit="quitarEditReserva_click"
                OnRowUpdating="updateReserva_click"
                OnRowDeleting="clickRowDeletereserva">--%>