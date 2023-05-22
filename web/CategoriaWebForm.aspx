<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CategoriaWebForm.aspx.cs" Inherits="web.CategoriaWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
 <main>
        <div class="showGrid">
            <div class="izq">
            <h2>Categorias</h2>
            <asp:GridView ID="categoriasTable" runat="server" CssClass="grid" AutoGenerateColumns="False"
                DataKeyNames="id" PageSize="5" AllowPaging="True"
                EmptyDataText="Ups, no se han encontrado categorias."
                OnPageIndexChanging="changePageCategoriasTable"
                OnRowEditing="clickRowEditCategorias"
                OnRowCancelingEdit="clickRowCancelCategorias"
                OnRowUpdating="clickRowUpdateCategorias"
                OnRowDeleting="clickRowDeleteCategorias">

                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
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
            <br />

            <h2>Crear Categoria</h2>  
            <div class="crearFlex">
                 <div class="izq">              
                    Nombre: 
                     <asp:TextBox ID="Nombre" runat="server"></asp:TextBox>      
                 </div>
                <div class="der">
                    Descripción: 
                    <asp:TextBox ID="Descripcion" runat="server"></asp:TextBox>
                </div>

                 <asp:Button id="crearCategoria" Text="Crear" runat="server" OnClick="crearCategoriaClick"/>

                <asp:Label ID="Resultado" runat="server" Text =" " />&nbsp;

            </div>
        </div>
     </main>
</asp:Content>


