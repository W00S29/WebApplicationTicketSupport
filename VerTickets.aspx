<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VerTickets.aspx.cs" Inherits="WebApplicationTicketSupport.VerTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Lista de Tickets</h2>
        <asp:GridView ID="gvTickets" runat="server" AutoGenerateColumns="False" DataKeyNames="id_ticket" CssClass="table table-striped" OnRowCommand="gvTickets_RowCommand">
            <Columns>
                <asp:BoundField DataField="id_ticket" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="id_usuario" HeaderText="Usuario ID" />
                <asp:BoundField DataField="asunto" HeaderText="Asunto" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="prioridad" HeaderText="Prioridad" />
                <asp:BoundField DataField="categoria" HeaderText="Categoría" />
                <asp:BoundField DataField="estado" HeaderText="Estado" />
                <asp:BoundField DataField="fecha_creacion" HeaderText="Fecha Creación" DataFormatString="{0:g}" />
                <asp:BoundField DataField="fecha_cierre" HeaderText="Fecha Cierre" DataFormatString="{0:g}" />
                <asp:ButtonField CommandName="Eliminar" Text="Eliminar" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-dark" OnClick="btnVolver_Click" />
    </div>
</asp:Content>
