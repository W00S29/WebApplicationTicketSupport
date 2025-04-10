<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebApplicationTicketSupport.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Registro
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <link href="Estilos/Registro.css" rel="stylesheet" />
    <div class="register-container">
        <h2>Registro de Usuario</h2>

        <div class="input-group">
           
            <asp:TextBox ID="txtNombre" runat="server"  placeholder="Nombre"/>
        </div>

        <div class="input-group">
           
            <asp:TextBox ID="txtCorreo" runat="server"  placeholder="Correo"/>
        </div>

        <div class="input-group">
            
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" placeholder="Contraseña" />
        </div>
        <div class="input-group">
           
             <asp:TextBox ID="txtConfirmarContraseña" runat="server" TextMode="Password" placeholder="Confirmar Contraseña" />
        </div>

        <div class="input-group">
           <%-- <asp:Label runat="server" Text="Rol:" AssociatedControlID="ddlRol" />--%>
            <asp:DropDownList ID="ddlRol" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged" Visible="false">
                <asp:ListItem Text="Cliente" Value="3" />
                
            </asp:DropDownList>
        </div>

        <asp:Panel ID="panelEspecialidad" runat="server" Visible="false" CssClass="specialty-panel">
            <div class="input-group">
                <asp:Label runat="server" Text="Especialidad:" AssociatedControlID="txtEspecialidad" />
                <asp:TextBox ID="txtEspecialidad" runat="server" />
            </div>
        </asp:Panel>

        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" CssClass="register-button" />
         <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn btn-dark" />
       <div> <asp:Label ID="lblMensaje" runat="server" CssClass="error-message" /></div>
    </div>

</asp:Content>






