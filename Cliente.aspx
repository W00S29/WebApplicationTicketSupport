<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="WebApplicationTicketSupport.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6">
                <div class="card mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Agregar Nuevo Ticket</h5>
                        <p class="card-text">
                            Utilice este botón para crear un nuevo ticket y reportar un problema o solicitar asistencia.
                        </p>
                        <asp:Button ID="btnAgregarTicket" runat="server" Text="Agregar Ticket" CssClass="btn btn-primary" OnClick="btnAgregarTicket_Click" />
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="card mb-4">
                    <div class="card-body">
                        <h5 class="card-title">Ver Mis Tickets</h5>
                        <p class="card-text">
                            Consulte el estado y detalles de los tickets que ha enviado.
                        </p>
                        <asp:Button ID="btnVerTickets" runat="server" Text="Ver Tickets" CssClass="btn btn-secondary" OnClick="btnVerTickets_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

