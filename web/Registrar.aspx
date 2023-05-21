<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="web.Registrar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="container bg-light overflow-auto" style="min-height:599px;">
        <div class="registro_inicio">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <h1>Registrar nuevo usuario</h1>
            Nick:&#9;&#9;
            <asp:TextBox ID="TNick" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            Nombre:&#9;&#9;
            <asp:TextBox ID="TNombre" runat="server" CausesValidation="True"></asp:TextBox>
            Apellidos:&#9;&#9;
            <asp:TextBox ID="TApellidos" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            Email:&#9;&#9;
            <asp:TextBox ID="TEmail" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            Fecha de nacimiento (yyyy-MM-dd):&#9;
            <asp:TextBox ID="TFecha" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            Teléfono:&#9;&#9;
            <asp:TextBox ID="TTelefono" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            Password:&#9;&#9;
            <asp:TextBox ID="TPassword" runat="server" CausesValidation="True"></asp:TextBox>
            <ajaxToolkit:PasswordStrength ID="PasswordStrength1" runat="server" Enabled="true" TargetControlID="TPassword" DisplayPosition="RightSide" StrengthIndicatorType="Text" 
                PreferredPasswordLength="10" PrefixText="Seguridad: " TextStrengthDescriptions="Débil; Media; Fuerte; Muy fuerte" MinimumSymbolCharacters="1" MinimumLowerCaseCharacters="2" MinimumUpperCaseCharacters="2" MinimumNumericCharacters="2"/>
            <br />
            Repita Password:&#9;&#9;
            <asp:TextBox ID="TRepitePassword" runat="server" CausesValidation="True"></asp:TextBox>
            <br />
            <asp:Button ID="BCrear" runat="server" Text="Crear" OnClick="Crear"/>
            <br />
            <asp:Label ID="LResultado" runat="server" Text =" " />&nbsp;
            <asp:RequiredFieldValidator ID="RequiredNick" ControlToValidate="TNick" runat="server" ErrorMessage="* Introduce el Nick"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredNombre" ControlToValidate="TNombre" runat="server" ErrorMessage="* Introduce el Nombre"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredApellidos" ControlToValidate="TApellidos" runat="server" ErrorMessage="* Introduce los Apellidos"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredEmail" ControlToValidate="TEmail" runat="server" ErrorMessage="* Introduce el Email"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularEmail" ControlToValidate="TEmail" runat="server" ErrorMessage="* Email incorrecto" ValidationExpression="\S+@\S+\.\S+"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFecha" ControlToValidate="TFecha" runat="server" ErrorMessage="* Introduce la Fecha de Nacimiento"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareFecha" runat="server" ControlToValidate="TFecha" ErrorMessage="* Formato de fecha incorrecto" Operator="DataTypeCheck" Type="Date" ValidationGroup="grpDate" />
            <asp:RequiredFieldValidator ID="RequiredTelefono" ControlToValidate="TTelefono" runat="server" ErrorMessage="* Introduce el Teléfono"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularTelefono" ControlToValidate="TTelefono" runat="server" ErrorMessage="* Teléfono incorrecto" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredPassword" ControlToValidate="TPassword" runat="server" ErrorMessage="* Introduce la Password"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredRepite" ControlToValidate="TRepitePassword" runat="server" ErrorMessage="* Repite la Password"></asp:RequiredFieldValidator>
        </div>
    </div>
</asp:Content>
