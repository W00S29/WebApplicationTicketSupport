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

        <nav>
  <div class="nav nav-tabs" id="nav-tab" role="tablist">
    <button class="nav-link active" id="nav-home-tab" data-bs-toggle="tab" data-bs-target="#nav-home" type="button" role="tab" aria-controls="nav-home" aria-selected="true">Asignar</button>
     <button class="nav-link" id="nav-abierto-tab" data-bs-toggle="tab" data-bs-target="#nav-abierto" type="button" role="tab" aria-controls="nav-abierto" aria-selected="false">Abiertos</button>
    <button class="nav-link" id="nav-profile-tab" data-bs-toggle="tab" data-bs-target="#nav-profile" type="button" role="tab" aria-controls="nav-profile" aria-selected="false">En progreso</button>
    <button class="nav-link" id="nav-contact-tab" data-bs-toggle="tab" data-bs-target="#nav-contact" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Resueltos</button>
    <button class="nav-link" id="nav-disabled-tab" data-bs-toggle="tab" data-bs-target="#nav-disabled" type="button" role="tab" aria-controls="nav-disabled" aria-selected="false">Cerrados</button>
  </div>
</nav>
<div class="tab-content" id="nav-tabContent">
  <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab" tabindex="0">
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
  </div>
 <div class="tab-pane fade" id="nav-abierto" role="tabpanel" aria-labelledby="nav-abierto-tab" tabindex="0">
          <asp:GridView ID="TicketsAbierto" runat="server" AutoGenerateColumns="False" DataKeyNames="id_ticket" CssClass="table table-striped" >
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
        
    </Columns>
</asp:GridView>    

 </div>

  <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab" tabindex="0">
      <asp:GridView ID="TicketsEnprogreso" runat="server" AutoGenerateColumns="False" DataKeyNames="id_ticket" CssClass="table table-striped" >
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
         
     </Columns>
 </asp:GridView>    
  </div>
  <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab" tabindex="0">
           <asp:GridView ID="TicketsResuelto" runat="server" AutoGenerateColumns="False" DataKeyNames="id_ticket" CssClass="table table-striped" >
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
    </Columns>
</asp:GridView> 
  </div>
  <div class="tab-pane fade" id="nav-disabled" role="tabpanel" aria-labelledby="nav-disabled-tab" tabindex="0">
                 <asp:GridView ID="TicketsCerrado" runat="server" AutoGenerateColumns="False" DataKeyNames="id_ticket" CssClass="table table-striped" >
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
    </Columns>
</asp:GridView>
  </div>
</div>
        <div>
    
        <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="mt-3"></asp:Label>
        </div>


    </div>
</asp:Content>
