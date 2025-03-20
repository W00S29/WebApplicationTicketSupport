<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="WebApplicationTicketSupport.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

       <style>
        .ticket-status p {
            font-size: 1.5em;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h1>Panel de Administración</h1>

    <div class="row">
        <div class="col-md-3">
            <div class="card bg-primary text-white">
                <div class="card-body">
                    <h5 class="card-title">Tickets Abiertos</h5>
                    <p class="card-text"><asp:Label ID="lblAbiertos" runat="server" Text="0" /></p>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card bg-info text-white">
                <div class="card-body">
                    <h5 class="card-title">Tickets En Progreso</h5>
                    <p class="card-text"><asp:Label ID="lblEnProgreso" runat="server" Text="0" /></p>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card bg-success text-white">
                <div class="card-body">
                    <h5 class="card-title">Tickets Resueltos</h5>
                    <p class="card-text"><asp:Label ID="lblResueltos" runat="server" Text="0" /></p>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card bg-danger text-white">
                <div class="card-body">
                    <h5 class="card-title">Tickets Cerrados</h5>
                    <p class="card-text"><asp:Label ID="lblCerrados" runat="server" Text="0" /></p>
                </div>
            </div>
        </div>
        <div>
              <asp:GridView ID="gvTickets" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="id_Ticket" OnRowCommand="gvTickets_RowCommand">
    <Columns>
        <asp:BoundField DataField="id_Ticket" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="asunto" HeaderText="Asunto" />
        <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
        <asp:BoundField DataField="prioridad" HeaderText="Prioridad" />
        <asp:BoundField DataField="categoria" HeaderText="Categoría" />
        <asp:BoundField DataField="estado" HeaderText="Estado" />
        <asp:TemplateField HeaderText="Técnico">
            <ItemTemplate>
                <asp:DropDownList ID="ddlTecnicos" runat="server" CssClass="form-control"></asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField CommandName="Asignar" Text="Asignar" />
    </Columns>
</asp:GridView>
        <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="mt-3"></asp:Label>
        </div>


    </div>
</asp:Content>
