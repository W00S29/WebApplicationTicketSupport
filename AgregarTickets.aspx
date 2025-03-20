<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarTickets.aspx.cs" Inherits="WebApplicationTicketSupport.AgregarTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div class="container mt-5">
        <h2>Agregar Nuevo Ticket</h2>
        <div class="form-group">
            <label>Asunto:</label>
            <asp:TextBox ID="txtAsunto" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Descripción:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Prioridad:</label>
            <asp:DropDownList ID="ddlPrioridad" runat="server" CssClass="form-control">
                <asp:ListItem Value="baja">Baja</asp:ListItem>
                <asp:ListItem Value="media">Media</asp:ListItem>
                <asp:ListItem Value="alta">Alta</asp:ListItem>
                <asp:ListItem Value="critica">Crítica</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label>Categoría:</label>
            <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Estado:</label>
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                <asp:ListItem Value="abierto">Abierto</asp:ListItem>
                <asp:ListItem Value="en progreso">En Progreso</asp:ListItem>
                <asp:ListItem Value="resuelto">Resuelto</asp:ListItem>
                <asp:ListItem Value="cerrado">Cerrado</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Ticket" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-dark" OnClick="btnVolver_Click" />
    </div>

</asp:Content>
