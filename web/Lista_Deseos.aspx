﻿<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Lista_Deseos.aspx.cs" Inherits="web.Lista_Deseos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="container bg-light overflow-auto" style="min-height:599px;">
        <div class="showGrid">
            <h2><asp:Label ID="LListado" runat="server" Text ="Lista de deseos" /></h2>
            <div class="table-responsive">
                <asp:GridView ID="GridView1" runat="server" CssClass="text-primary" AutoGenerateDeleteButton="true" selectedindex="1" OnRowDeleting="Gridview1_SelectedItemDeleted" HorizontalAlign="Center" CellPadding="5" PageSize="5" AllowPaging="True" OnPageIndexChanging="ChangePage">
                    <FooterStyle BackColor="White" ForeColor="#0d6efd" />
                    <HeaderStyle BackColor="#0d6efd" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Font-Underline="false" />
                    <PagerStyle BackColor="White" ForeColor="#0d6efd" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#0d6efd" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </div>
            <asp:Button ID="BRefresh" CssClass="btn btn-primary" runat="server" Text="Recargar Lista" OnClick="BRefresh_Click"/>
        </div>
    </div>
</asp:Content>