<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebApplicationTicketSupport.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registro de Usuario</h2>

    <asp:Label runat="server" Text="Nombre:" AssociatedControlID="txtNombre" />
    <asp:TextBox ID="txtNombre" runat="server" />

    <asp:Label runat="server" Text="Correo:" AssociatedControlID="txtCorreo" />
    <asp:TextBox ID="txtCorreo" runat="server" />

    <asp:Label runat="server" Text="Contraseña:" AssociatedControlID="txtContraseña" />
    <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" />

    <asp:Label runat="server" Text="Rol:" AssociatedControlID="ddlRol" />
    <asp:DropDownList ID="ddlRol" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged" >
        <asp:ListItem Text="Cliente" Value= "3" />
        <asp:ListItem Text="Tecnico" Value= "2" />
        <asp:ListItem Text="Administrador" Value= "1"/>
    </asp:DropDownList>

    <asp:Panel ID="panelEspecialidad" runat="server" Visible="false">
        <asp:Label runat="server" Text="Especialidad:" AssociatedControlID="txtEspecialidad" />
        <asp:TextBox ID="txtEspecialidad" runat="server" />
    </asp:Panel>

    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />

</asp:Content>






