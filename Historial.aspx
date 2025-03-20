<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="WebApplicationTicketSupport.Historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container mt-5">
        <h2>Historial de Tickets</h2>

        <div class="row mb-3">
            <div class="col-md-3">
                <label>ID Ticket:</label>
                <asp:TextBox ID="txtIdTicket" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label>Fecha Creación Desde:</label>
                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="col-md-3">
                <label>Fecha Creación Hasta:</label>
                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary mt-4" OnClick="btnFiltrar_Click" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-secondary mt-4" OnClick="btnLimpiar_Click" />
            </div>
        </div>

        <asp:GridView ID="gvHistorial" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="id_historial">
            <Columns>
                <asp:BoundField DataField="id_historial" HeaderText="ID Historial" ReadOnly="True" />
                <asp:BoundField DataField="id_ticket" HeaderText="ID Ticket" />
                <asp:BoundField DataField="id_usuario" HeaderText="ID Usuario" />
                <asp:BoundField DataField="asunto" HeaderText="Asunto" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="prioridad" HeaderText="Prioridad" />
                <asp:BoundField DataField="categoria" HeaderText="Categoría" />
                <asp:BoundField DataField="estado" HeaderText="Estado" />
                <asp:BoundField DataField="fecha_creacion" HeaderText="Fecha Creación" DataFormatString="{0:g}" />
                <asp:BoundField DataField="fecha_cierre" HeaderText="Fecha Cierre" DataFormatString="{0:g}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
