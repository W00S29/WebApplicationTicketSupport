<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="WebApplicationTicketSupport.Tickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Formulario para agregar nuevos tickets -->
    <div>
        <asp:Label runat="server" Text="Asunto:" />
        <asp:TextBox ID="txtAsunto" runat="server" />
        <asp:Label runat="server" Text="Descripción:" />
        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" />
        <asp:Label runat="server" Text="Prioridad:" />
        <asp:TextBox ID="txtPrioridad" runat="server" />
        <asp:Label runat="server" Text="Categoria:" />
        <asp:TextBox ID="txtCategoria" runat="server" />
        <asp:Label runat="server" Text="Estado:" />
        <asp:DropDownList ID="ddlEstado" runat="server">
            <asp:ListItem Text="Abierto" Value="Abierto" />
            <asp:ListItem Text="En Progreso" Value="En Progreso" />
            <asp:ListItem Text="Resuelto" Value="Resuelto" />
            <asp:ListItem Text="Cerrado" Value="Cerrado" />
        </asp:DropDownList>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Ticket" OnClick="btnAgregar_Click" />
    </div>

    <asp:GridView ID="gvTickets" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        ShowHeaderWhenEmpty="True" AutoGenerateEditButton="true" OnRowEditing="gvTickets_RowEditing"
        OnRowCancelingEdit="gvTickets_RowCancelingEdit" OnRowUpdating="gvTickets_RowUpdating"
        OnRowDeleting="gvTickets_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="Asunto" HeaderText="Asunto" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" />
            <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
