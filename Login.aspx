<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplicationTicketSupport.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Estilos/Login.css" rel="stylesheet" />
  <div class="login-container">
        <h2>Iniciar Sesión</h2>

        <div class="input-group">
            <asp:Label runat="server" Text="Correo:" />
            <asp:TextBox ID="txtCorreo" runat="server" />
        </div>

        <div class="input-group">
            <asp:Label runat="server" Text="Contraseña:" />
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" />
        </div>

        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" CssClass="login-button" />

        <asp:Label ID="lblMensaje" runat="server" CssClass="error-message" />

        <p><a href="Registro.aspx" class="signup-link">Registrarse</a></p>
    </div>
</asp:Content>


