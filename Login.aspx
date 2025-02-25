<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplicationTicketSupport.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Iniciar Sesión</h2>

    <asp:Label runat="server" Text="Correo:" />
    <asp:TextBox ID="txtCorreo" runat="server" />

    <asp:Label runat="server" Text="Contraseña:" />
    <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" />

    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />

    <p><a href="Registro.aspx">Registrarse</a></p>
</asp:Content>


