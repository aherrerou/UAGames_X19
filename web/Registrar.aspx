﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="web.Registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <h1>Registrar nuevo usuario</h1>
    Nick&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TNick" runat="server"></asp:TextBox>
    <br />
    Nombre&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TNombre" runat="server"></asp:TextBox>
    <br />
    Apellidos&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TApellidos" runat="server"></asp:TextBox>
    <br />
    Email&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TEmail" runat="server"></asp:TextBox>
    <br />
    Password&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TPassword" runat="server"></asp:TextBox>
    <br />
    Fecha de nacimiento&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TFecha" runat="server"></asp:TextBox>
    <br />
    Teléfono&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TTelefono" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="BCrear" runat="server" Text="Crear" OnClick="Crear"/>
    <br />
    <br />
    <asp:Label ID="LResultado" runat="server" Text =" " />&nbsp;
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
</asp:Content>