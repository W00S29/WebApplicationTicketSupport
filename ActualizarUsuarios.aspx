<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ActualizarUsuarios.aspx.cs" Inherits="WebApplicationTicketSupport.ActualizarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Actualizar Usuarios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div class="container mt-5">
        <h2>Actualizar Usuario</h2>

        <div class="form-group">
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtCorreo">Correo:</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtContraseña">Contraseña:</label>
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="ddlRol">Rol:</label>
            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="btnActualizar_Click" />
    </div>
</asp:Content>
