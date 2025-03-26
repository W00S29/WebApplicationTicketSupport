<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="WebApplicationTicketSupport.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Panel de Administración</h1>

    <div class="row">
        <div class="col-md-3">
            <div class="card bg-primary text-white">
                <div class="card-body">
                    <h5 class="card-title">Administradores</h5>
                    <p class="card-text"><asp:Label ID="lblAdministradores" runat="server" Text="0" /></p>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card bg-info text-white">
                <div class="card-body">
                    <h5 class="card-title">Tecnicos</h5>
                    <p class="card-text"><asp:Label ID="lblTecnicos" runat="server" Text="0" /></p>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card bg-success text-white">
                <div class="card-body">
                    <h5 class="card-title">Clientes</h5>
                    <p class="card-text"><asp:Label ID="lblClientes" runat="server" Text="0" /></p>
                </div>
            </div>
        </div>
     </div>
     
      <div class="btnamarillo">
          <asp:Button ID="btnAmarillo" runat="server" Text="Agregar Usuario" CssClass="btn btn-warning" OnClick="btnAmarillo_Click" />
     </div>
        
    <div class="container mt-5">
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="id_usuario" OnRowCommand="gvUsuarios_RowCommand">
            <Columns>
                <asp:BoundField DataField="id_usuario" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="correo" HeaderText="Usuario" />
                <asp:TemplateField HeaderText="Contraseña">
                  <ItemTemplate>
                      <i class="bi bi-lock-fill"></i>
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id_rol" HeaderText="Rol ID" />
                <asp:BoundField DataField="fecha_registro" HeaderText="Fecha de registro" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEliminar" runat="server" CommandName="EliminarUsuario" CommandArgument='<%# Eval("id_usuario") %>' Text="Eliminar" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('¿Está seguro que desea eliminar este usuario?');" />
                        <asp:LinkButton ID="lnkActualizar" runat="server" CommandName="ActualizarUsuario" CommandArgument='<%# Eval("id_usuario") %>' Text="Actualizar" CssClass="btn btn-primary btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>


